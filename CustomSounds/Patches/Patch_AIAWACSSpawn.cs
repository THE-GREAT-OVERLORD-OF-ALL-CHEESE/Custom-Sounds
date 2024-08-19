using HarmonyLib;
using UnityEngine;

namespace CheeseMods.CustomSounds.Patches
{
    [HarmonyPatch(typeof(AIAWACSSpawn), "OnPreSpawnUnit")]
    class Patch_AIAWACSSpawn_OnPreSpawnUnit
    {
        [HarmonyPostfix]
        static void Postfix(AIAWACSSpawn __instance)
        {
            if (Main.instance.awacsVoices.awacsVoiceProfiles != null && Main.instance.awacsVoices.awacsVoiceProfiles.Count > 0)
            {
                AWACSVoiceProfile awacsVoice = Main.instance.awacsVoices.awacsVoiceProfiles[UnityEngine.Random.Range(0, Main.instance.awacsVoices.awacsVoiceProfiles.Count)];

                Debug.Log($"Replacing AWACS with {awacsVoice.name}");
                __instance.awacsVoiceProfile = awacsVoice;
            }
        }
    }
}