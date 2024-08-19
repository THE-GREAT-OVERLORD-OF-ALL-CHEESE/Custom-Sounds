using UnityEngine;

namespace CheeseMods.CustomSounds.Components
{
    class IRMissileWarningReplacer : MonoBehaviour
    {
        private void Start()
        {
            if (Main.instance.bettyVoices.currentBetty != null)
            {
                CustomBetty.Betty voiceProfile = Main.instance.bettyVoices.currentBetty;

                Debug.Log("Replacing IR missile warning");
                if (voiceProfile.irMissileIncoming != null)
                {
                    GetComponent<IRMissileIncomingWarning>().audioSource.clip = voiceProfile.irMissileIncoming;
                }
            }
        }
    }
}