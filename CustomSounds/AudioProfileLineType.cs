using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CheeseMods.CustomSounds
{
    public class AudioProfileLineType
    {
        public string filePath;
        public string type;
        public List<AudioProfileLine> lines = new List<AudioProfileLine>();

        public void GetFilePaths()
        {
            lines.Clear();

            Debug.Log("Checking for: " + filePath);

            if (Directory.Exists(filePath))
            {
                Debug.Log(filePath + " exists!");
                DirectoryInfo info = new DirectoryInfo(filePath);
                foreach (FileInfo item in info.GetFiles("*.wav"))
                {
                    Debug.Log("Found line: " + item.Name);
                    AudioProfileLine temp = new AudioProfileLine();
                    temp.filePath = item.FullName;
                    lines.Add(temp);
                    Debug.Log("\n");
                }
            }
            else
            {
                Debug.Log(filePath + " doesn't exist.");
            }
        }

        public void Unload()
        {
            foreach (AudioProfileLine line in lines)
            {
                line.Unload();
            }

            lines.Clear();
        }
    }
}
