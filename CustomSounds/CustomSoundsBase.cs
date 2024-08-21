using CheeseMods.VTOLTaskProgressUI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

namespace CheeseMods.CustomSounds
{
    public class CustomSoundsBase : MonoBehaviour
    {
        public List<AudioProfile> audioProfiles = new List<AudioProfile>();
        public List<TaskInfo> tasksInProgress = new List<TaskInfo>();

        public void LoadAudioProfiles(string directoryPath, string profileType, string[] lineTypes)
        {
            Debug.Log("Checking for: " + directoryPath);

            if (Directory.Exists(directoryPath))
            {
                Debug.Log(directoryPath + " exists!");
                DirectoryInfo info = new DirectoryInfo(directoryPath);
                foreach (DirectoryInfo item in info.GetDirectories())
                {
                    try
                    {
                        Debug.Log("Checking for: " + Path.Combine(directoryPath, item.Name, $"{profileType}.txt"));
                        string temp = File.ReadAllText(Path.Combine(directoryPath, item.Name, $"{profileType}.txt"));
                        Debug.Log("Found voice pack: " + temp);

                        if (audioProfiles.Any(p => p.name == temp))
                        {
                            Debug.Log($"We already have a {temp}, skipping...");
                            continue;
                        }

                        AudioProfile tempProfile = new AudioProfile();
                        tempProfile.name = temp;
                        tempProfile.filePath = Path.Combine(directoryPath, item.Name);
                        tempProfile.GetFilePaths(lineTypes);
                        audioProfiles.Add(tempProfile);
                    }
                    catch
                    {
                        Debug.Log(item.Name + " is not a voice pack.");
                    }
                    Debug.Log("\n");
                }
            }
            else
            {
                Debug.Log(directoryPath + " doesn't exist.");
            }
            Debug.Log("Loading audioClips");
            StartCoroutine(LoadAudioFile(audioProfiles));
        }

        private IEnumerator LoadAudioFile(List<AudioProfile> profiles)
        {
            TaskInfo mainTask = VTOLTaskProgressManager.RegisterTask(Main.instance, $"{GetType().Name}: loading all sounds");
            tasksInProgress.Add(mainTask);

            for (int y = 0; y < profiles.Count; y++)
            {
                mainTask.SetStatus($"Loading profile: {profiles[y].name}");

                TaskInfo profileTask = VTOLTaskProgressManager.RegisterTask(Main.instance, $"{GetType().Name}: loading profile: {profiles[y].name}");
                tasksInProgress.Add(profileTask);
                for (int x = 0; x < profiles[y].lineTypes.Count; x++)
                {
                    profileTask.SetStatus($"Loading line type: {profiles[y].lineTypes[x].type}");

                    TaskInfo lineTypeTask = VTOLTaskProgressManager.RegisterTask(Main.instance, $"{GetType().Name}: loading line type {profiles[y].lineTypes[x].type}");
                    tasksInProgress.Add(lineTypeTask);
                    for (int i = 0; i < profiles[y].lineTypes[x].lines.Count; i++)
                    {
                        lineTypeTask.SetStatus($"Loading {Path.GetFileName(profiles[y].lineTypes[x].lines[i].filePath)}");

                        //TaskInfo fileTask = VTOLTaskProgressManager.RegisterTask(Main.instance, $"{GetType().Name}: loading sound {Path.GetFileName(profiles[y].lineTypes[x].lines[i].filePath)}");
                        //tasksInProgress.Add(fileTask);
                        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(profiles[y].lineTypes[x].lines[i].filePath, AudioType.WAV))
                        {
                            yield return www.Send();

                            if (www.isNetworkError)
                            {
                                Debug.Log(www.error);
                            }
                            else
                            {
                                profiles[y].lineTypes[x].lines[i].clip = DownloadHandlerAudioClip.GetContent(www);
                            }
                        }
                        //tasksInProgress.Remove(fileTask);
                        //fileTask.FinishTask();

                        lineTypeTask.SetProgress((float)i / (float)profiles[y].lineTypes[x].lines.Count);
                    }
                    tasksInProgress.Remove(lineTypeTask);
                    lineTypeTask.FinishTask();

                    profileTask.SetProgress((float)x / (float)profiles[y].lineTypes.Count);
                }
                tasksInProgress.Remove(profileTask);
                profileTask.FinishTask();

                mainTask.SetProgress((float)y / (float)profiles.Count);
            }
            ApplyAudio();

            tasksInProgress.Remove(mainTask);
            mainTask.FinishTask();
        }

        protected virtual void ApplyAudio()
        {

        }

        public virtual void UnloadAudioProfiles()
        {
            StopAllCoroutines();

            foreach (TaskInfo taskInfo in tasksInProgress)
            {
                taskInfo.FinishTask("Mod unloaded");
            }
            tasksInProgress.Clear();

            foreach (AudioProfile profile in audioProfiles)
            {
                profile.Unload();
            }
            audioProfiles.Clear();
        }
    }
}
