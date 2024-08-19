using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CheeseMods.CustomSounds
{
    public class AudioProfile
    {
        public string filePath;
        public string name;
        public List<AudioProfileLineType> lineTypes = new List<AudioProfileLineType>();

        public void GetFilePaths(string[] lineTypeStrings)
        {
            lineTypes.Clear();

            Debug.Log("Checking for: " + filePath);

            if (Directory.Exists(filePath))
            {
                Debug.Log(filePath + " exists!");
                DirectoryInfo info = new DirectoryInfo(filePath);
                foreach (string lineTypeString in lineTypeStrings)
                {
                    Debug.Log("Checking for: " + lineTypeString);
                    if (Directory.Exists(Path.Combine(filePath, lineTypeString)))
                    {
                        Debug.Log("Found: " + lineTypeString);
                        AudioProfileLineType temp = new AudioProfileLineType();
                        temp.filePath = Path.Combine(filePath, lineTypeString);
                        temp.type = lineTypeString;
                        temp.GetFilePaths();
                        lineTypes.Add(temp);
                        Debug.Log("\n");
                    }
                    else
                    {
                        Debug.Log(Path.Combine(filePath, lineTypeString) + " doesn't exist, please add it or the voicepack will not work as intended.");
                    }
                }
            }
            else
            {
                Debug.Log(filePath + " doesn't exist.");
            }
        }

        public void Unload()
        {
            foreach (AudioProfileLineType lineType in lineTypes)
            {
                lineType.Unload();
            }

            lineTypes.Clear();
        }
    }
}
