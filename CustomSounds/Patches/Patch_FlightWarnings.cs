using HarmonyLib;
using UnityEngine;

namespace CheeseMods.CustomSounds.Patches
{
    [HarmonyPatch(typeof(FlightWarnings), "Awake")]
    class Patch_FlightWarnings_Awake
    {
        [HarmonyPostfix]
        static void Postfix(FlightWarnings __instance)
        {
            if (Main.instance.bettyVoices.currentBetty != null)
            {
                Debug.Log($"Replacing flight warnings with {Main.instance.bettyVoices.currentBetty.name}");
                Traverse traverse = new Traverse(__instance);

                __instance.commonWarningsClips = Main.instance.bettyVoices.currentBetty.commonWarnings;
                traverse.Field("cwp").SetValue(__instance.commonWarningsClips.ToArray());
            }
        }
    }
}