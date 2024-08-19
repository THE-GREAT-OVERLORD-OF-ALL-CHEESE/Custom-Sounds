using HarmonyLib;
using UnityEngine;

namespace CheeseMods.CustomSounds.Patches
{
    [HarmonyPatch(typeof(HUDStallWarning), "Start")]
    class Patch_HUDStallWarning_Start
    {
        [HarmonyPostfix]
        static void Postfix(HUDStallWarning __instance)
        {
            if (Main.instance.bettyVoices.currentBetty != null)
            {
                CustomBetty.Betty voiceProfile = Main.instance.bettyVoices.currentBetty;

                Debug.Log("Replacing stall warning");
                if (voiceProfile.stallWarning != null)
                {
                    __instance.warningClip = voiceProfile.stallWarning;
                }
            }
        }
    }
}