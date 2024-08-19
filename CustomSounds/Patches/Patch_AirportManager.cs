using HarmonyLib;
using UnityEngine;

namespace CheeseMods.CustomSounds.Patches
{
    [HarmonyPatch(typeof(AirportManager), "Start")]
    class Patch_AirportManager_Start
    {
        [HarmonyPostfix]
        static void Postfix(AirportManager __instance)
        {
            if (Main.instance.atcVoices.atcVoiceProfiles != null && Main.instance.atcVoices.atcVoiceProfiles.Count > 0)
            {
                ATCVoiceProfile atcVoice = Main.instance.atcVoices.atcVoiceProfiles[UnityEngine.Random.Range(0, Main.instance.atcVoices.atcVoiceProfiles.Count)];

                Debug.Log($"Replacing ATC with {atcVoice.name}");
                __instance.voiceProfile = atcVoice;
            }
        }
    }
}