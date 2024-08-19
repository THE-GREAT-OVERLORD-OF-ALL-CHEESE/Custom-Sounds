using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CheeseMods.CustomSounds
{
    public class CustomWingmen : CustomSoundsBase
    {
        protected override void ApplyAudio()
        {
            Debug.Log("Loading wingmen just to be sure");
            VTResources.LoadVoiceProfiles();

            Debug.Log("Getting stock wingmen");

            Traverse traverse = Traverse.Create(typeof(VTResources));
            Dictionary<string, WingmanVoiceProfile> stockWingmen = (Dictionary<string, WingmanVoiceProfile>)traverse.Field("wingmanVoices").GetValue();

            foreach (AudioProfile profile in Main.instance.wingmenVoices.audioProfiles)
            {
                if (!stockWingmen.ContainsKey(profile.name))
                {
                    Debug.Log("Adding " + profile.name + " to the stock wingmen");
                    stockWingmen.Add(profile.name, GenerateWingmanVoiceProfile(profile));
                }
                else
                {
                    Debug.Log("Skipped " + profile.name + " as theres already a wingman with that name");
                }
            }

            Debug.Log("Adding new list of wingmen back to the game!");

            traverse.Field("wingmanVoices").SetValue(stockWingmen);

            Debug.Log("Yay, it worked!");
        }

        public WingmanVoiceProfile GetDefaultVoiceProfileClone()
        {
            WingmanVoiceProfile defaultProfile = CommRadioManager.instance.defaultWingmanVoice;
            WingmanVoiceProfile newProfile = ScriptableObject.CreateInstance<WingmanVoiceProfile>();

            newProfile.messageProfiles = new WingmanVoiceProfile.MessageAudio[defaultProfile.messageProfiles.Length];

            for (int i = 0; i < defaultProfile.messageProfiles.Length; i++)
            {
                newProfile.messageProfiles[i] = defaultProfile.messageProfiles[i];
            }
            return newProfile;
        }

        public WingmanVoiceProfile GenerateWingmanVoiceProfile(AudioProfile profile)
        {
            WingmanVoiceProfile output = GetDefaultVoiceProfileClone();
            output.enabled = true;
            output.name = profile.name;
            for (int i = 0; i < profile.lineTypes.Count; i++)
            {
                WingmanVoiceProfile.MessageAudio target = output.messageProfiles.First(p => p.messageType.ToString() == profile.lineTypes[i].type);
                int targetIndex = output.messageProfiles.IndexOf(target);
                output.messageProfiles[targetIndex] = GenerateMessageAudio(profile.lineTypes[i]);
            }
            return output;
        }

        public WingmanVoiceProfile.MessageAudio GenerateMessageAudio(AudioProfileLineType lines)
        {
            WingmanVoiceProfile.MessageAudio output = new WingmanVoiceProfile.MessageAudio();
            output.messageType = MessageType(lines.type);
            output.clips = new AudioClip[lines.lines.Count];
            for (int i = 0; i < output.clips.Length; i++)
            {
                output.clips[i] = lines.lines[i].clip;
            }
            return output;
        }

        public static bool IsMessageType(string name)
        {
            bool output = false;
            foreach (WingmanVoiceProfile.Messages type in Enum.GetValues(typeof(WingmanVoiceProfile.Messages)))
            {
                if (name == type.ToString())
                {
                    output = true;
                }
            }
            return output;
        }

        public static WingmanVoiceProfile.Messages MessageType(string name)
        {
            WingmanVoiceProfile.Messages output = WingmanVoiceProfile.Messages.AirMiss;
            foreach (WingmanVoiceProfile.Messages type in Enum.GetValues(typeof(WingmanVoiceProfile.Messages)))
            {
                if (name == type.ToString())
                {
                    output = type;
                }
            }
            return output;
        }
    }
}
