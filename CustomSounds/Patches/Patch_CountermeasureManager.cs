using HarmonyLib;
using UnityEngine;

namespace CheeseMods.CustomSounds.Patches
{
    [HarmonyPatch(typeof(CountermeasureManager), "Start")]
    class Patch_CountermeasureManager_Start
    {
        [HarmonyPostfix]
        static void Postfix(CountermeasureManager __instance)
        {
            if (Main.instance.bettyVoices.currentBetty != null)
            {
                CustomBetty.Betty voiceProfile = Main.instance.bettyVoices.currentBetty;

                Debug.Log("Replacing cm sounds");
                __instance.chaffAnnounceClip = voiceProfile.commonWarnings.Chaff;
                __instance.flareAnnounceClip = voiceProfile.commonWarnings.Flare;
            }
        }
    }
}