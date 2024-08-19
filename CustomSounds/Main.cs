using ModLoader.Framework;
using ModLoader.Framework.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VTOLAPI;
using static CheeseMods.CustomSounds.CustomATC;
using static CheeseMods.CustomSounds.CustomAWACS;
using static CheeseMods.CustomSounds.CustomBetty;

namespace CheeseMods.CustomSounds
{
    [ItemId("cheese.customSounds")]
    public class Main : VtolMod
    {
        public static Main instance;

        public CustomWingmen wingmenVoices;
        public CustomATC atcVoices;
        public CustomAWACS awacsVoices;
        public CustomBetty bettyVoices;

        public void Awake()
        {
            instance = this;

            wingmenVoices = gameObject.AddComponent<CustomWingmen>();

            atcVoices = gameObject.AddComponent<CustomATC>();

            awacsVoices = gameObject.AddComponent<CustomAWACS>();

            bettyVoices = gameObject.AddComponent<CustomBetty>();

            LoadAudioProfiles();

            VTAPI.SceneLoaded += SceneLoaded;

            Debug.Log("Custom Sounds: Ready!");
        }

        public override void UnLoad()
        {
            wingmenVoices.UnloadAudioProfiles();
            atcVoices.UnloadAudioProfiles();
            awacsVoices.UnloadAudioProfiles();
            bettyVoices.UnloadAudioProfiles();

            Debug.Log("Custom Sounds: Unloaded!");
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R))
            {
                UnloadAudioProfiles();
                LoadAudioProfiles();
            }
        }

        private void UnloadAudioProfiles()
        {
            wingmenVoices.UnloadAudioProfiles();
            atcVoices.UnloadAudioProfiles();
            awacsVoices.UnloadAudioProfiles();
            bettyVoices.UnloadAudioProfiles();
        }

        private void LoadAudioProfiles()
        {
            UnloadAudioProfiles();

            string localModsDir = Path.Combine(Directory.GetCurrentDirectory(), "@Mod Loader", @"Mods");

            wingmenVoices.LoadAudioProfiles(localModsDir, "voiceinfo", GetEnumValueNames(typeof(WingmanVoiceProfile.Messages)));
            atcVoices.LoadAudioProfiles(localModsDir, "atcvoiceinfo", GetEnumValueNames(typeof(ATCLines)));
            awacsVoices.LoadAudioProfiles(localModsDir, "awacsvoiceinfo", GetEnumValueNames(typeof(AWACSLines)));
            bettyVoices.LoadAudioProfiles(localModsDir, "bettyvoiceinfo", GetEnumValueNames(typeof(CommonWarnings2)));

            string workshopModsDir = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\workshop\content\3018410");

            wingmenVoices.LoadAudioProfiles(workshopModsDir, "voiceinfo", GetEnumValueNames(typeof(WingmanVoiceProfile.Messages)));
            atcVoices.LoadAudioProfiles(workshopModsDir, "atcvoiceinfo", GetEnumValueNames(typeof(ATCLines)));
            awacsVoices.LoadAudioProfiles(workshopModsDir, "awacsvoiceinfo", GetEnumValueNames(typeof(AWACSLines)));
            bettyVoices.LoadAudioProfiles(workshopModsDir, "bettyvoiceinfo", GetEnumValueNames(typeof(CommonWarnings2)));
        }

        private string[] GetEnumValueNames(Type enumToSearch)
        {
            List<string> names = new List<string>();
            foreach (int messageType in Enum.GetValues(enumToSearch))
            {
                names.Add(Enum.GetName(enumToSearch, messageType).ToString());
            }
            return names.ToArray();
        }

        private void SceneLoaded(VTScenes scene)
        {
            switch (scene)
            {
                case VTScenes.ReadyRoom:
                case VTScenes.VehicleConfiguration:
                    if (bettyVoices.bettys.Count > 0)
                    {
                        Debug.Log("Replacing betty!");
                        bettyVoices.currentBetty = bettyVoices.bettys[UnityEngine.Random.Range(0, bettyVoices.bettys.Count)];
                    }
                    else
                    {
                        Debug.Log("There are no betty voice packs, cannot replace betty...");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}