using HarmonyLib;
using UnityEngine;

namespace CheeseMods.CustomSounds.Patches
{
    [HarmonyPatch(typeof(HUDCollisionWarning), "Start")]
    class Patch_HUDCollisionWarning_Start
    {
        [HarmonyPostfix]
        static void Postfix(HUDCollisionWarning __instance)
        {
            if (Main.instance.bettyVoices.currentBetty != null)
            {
                CustomBetty.Betty voiceProfile = Main.instance.bettyVoices.currentBetty;

                Debug.Log("Replacing collision warning");
                if (voiceProfile.collisionWarning != null)
                {
                    __instance.warningSound = voiceProfile.collisionWarning;
                }
            }
        }
    }
}