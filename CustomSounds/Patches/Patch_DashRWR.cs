using HarmonyLib;
using UnityEngine;

namespace CheeseMods.CustomSounds.Patches
{
    [HarmonyPatch(typeof(DashRWR), "Start")]
    class Patch_DashRWR_Start
    {
        [HarmonyPostfix]
        static void Postfix(DashRWR __instance)
        {
            if (Main.instance.bettyVoices.currentBetty != null)
            {
                CustomBetty.Betty voiceProfile = Main.instance.bettyVoices.currentBetty;

                Debug.Log("Replacing RWR");
                if (voiceProfile.blip != null)
                {
                    __instance.radarBlip = voiceProfile.blip;
                }
                if (voiceProfile.irMissileIncoming != null)
                {
                    __instance.lockBlip = voiceProfile.lockBlip;
                }
                if (voiceProfile.missileLoopLock != null)
                {
                    __instance.missileLockLoopAudioSource.clip = voiceProfile.missileLoopLock;
                }
                if (voiceProfile.newContactBlip != null)
                {
                    __instance.newContactBlip = voiceProfile.newContactBlip;
                }
                if (voiceProfile.sarhLockBlip != null)
                {
                    __instance.sarhLockBlip = voiceProfile.sarhLockBlip;
                }
            }
        }
    }
}