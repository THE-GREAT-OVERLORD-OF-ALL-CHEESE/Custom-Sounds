using UnityEngine;

namespace CheeseMods.CustomSounds
{
    public class AudioProfileLine
    {
        public string filePath;
        public AudioClip clip;

        public void Unload()
        {
            AudioClip.Destroy(clip);
        }
    }
}
