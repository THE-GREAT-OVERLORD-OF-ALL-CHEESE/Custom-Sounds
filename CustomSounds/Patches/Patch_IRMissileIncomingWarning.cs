using CheeseMods.CustomSounds.Components;
using HarmonyLib;

namespace CheeseMods.CustomSounds.Patches
{
    [HarmonyPatch(typeof(IRMissileIncomingWarning), "Update")]
    class Patch_IRMissileIncomingWarning_Update
    {
        [HarmonyPostfix]
        static void Postfix(IRMissileIncomingWarning __instance)
        {
            if (__instance.gameObject.GetComponent<IRMissileWarningReplacer>() == null)
            {
                __instance.gameObject.AddComponent<IRMissileWarningReplacer>();
            }
        }
    }
}