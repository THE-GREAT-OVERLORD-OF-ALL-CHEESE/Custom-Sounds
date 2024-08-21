using System;
using System.Collections.Generic;
using UnityEngine;

namespace CheeseMods.CustomSounds
{
    public class CustomAWACS : CustomSoundsBase
    {
        public enum AWACSLines
        {
            Cardinal,
            Clean,
            Cold,
            CompoundDigits,
            Fast,
            GoingDown,
            GrandSlam,
            GroupBraa,
            GroupBullseye,
            HighAltitude,
            HomeplateBraa,
            HostileBraa,
            HostileBullseye,
            Hot,
            LeansOn,
            Low,
            Merged,
            Overlord,
            PhoneticAlphabet,
            Picture,
            Popup,
            Range,
            RTB,
            Thousand,
            Unable
        }

        public List<AWACSVoiceProfile> awacsVoiceProfiles = new List<AWACSVoiceProfile>();

        protected override void ApplyAudio()
        {
            awacsVoiceProfiles.Clear();

            for (int i = 0; i < audioProfiles.Count; i++)
            {
                awacsVoiceProfiles.Add(GenerateAWACSVoiceProfile(audioProfiles[i]));
            }
        }

        public override void UnloadAudioProfiles()
        {
            base.UnloadAudioProfiles();

            awacsVoiceProfiles.Clear();
        }

        public AWACSVoiceProfile GetDefaultVoiceProfileClone()
        {
            AWACSVoiceProfile defaultProfile = VTResources.GetAllAWACSVoices()[0];
            AWACSVoiceProfile newProfile = ScriptableObject.CreateInstance<AWACSVoiceProfile>();

            newProfile.cardinalClips = defaultProfile.cardinalClips;
            newProfile.cleanClips = defaultProfile.cleanClips;
            newProfile.coldClips = defaultProfile.coldClips;
            newProfile.compoundDigits = defaultProfile.compoundDigits;
            newProfile.fastClips = defaultProfile.fastClips;
            newProfile.goingDownClips = defaultProfile.goingDownClips;
            newProfile.grandSlamClips = defaultProfile.grandSlamClips;
            newProfile.groupBraaClips = defaultProfile.groupBraaClips;
            newProfile.groupBullseyeClips = defaultProfile.groupBullseyeClips;
            newProfile.highAltitudeClips = defaultProfile.highAltitudeClips;
            newProfile.homeplateBraaClips = defaultProfile.homeplateBraaClips;
            newProfile.hostileBraaClips = defaultProfile.hostileBraaClips;
            newProfile.hostileBullseyeClips = defaultProfile.hostileBullseyeClips;
            newProfile.hotClips = defaultProfile.hotClips;
            newProfile.leansOnClips = defaultProfile.leansOnClips;
            newProfile.lowClips = defaultProfile.lowClips;
            newProfile.mergedClips = defaultProfile.mergedClips;
            newProfile.overlordClips = defaultProfile.overlordClips;
            newProfile.phoneticAlphabet = defaultProfile.phoneticAlphabet;
            newProfile.pictureClips = defaultProfile.pictureClips;
            newProfile.popupClips = defaultProfile.popupClips;
            newProfile.rangeClips = defaultProfile.rangeClips;
            newProfile.rtbClips = defaultProfile.rtbClips;
            newProfile.thousandClips = defaultProfile.thousandClips;
            newProfile.unableClips = defaultProfile.unableClips;
            return newProfile;
        }

        public AWACSVoiceProfile GenerateAWACSVoiceProfile(AudioProfile profile)
        {
            AWACSVoiceProfile output = GetDefaultVoiceProfileClone();
            output.name = profile.name;
            foreach (AudioProfileLineType lines in profile.lineTypes)
            {
                AudioClip[] temp = GenerateMessageAudio(lines).ToArray();
                switch (MessageType(lines.type))
                {
                    case AWACSLines.Cardinal:
                        output.cardinalClips = temp;
                        break;
                    case AWACSLines.Clean:
                        output.cleanClips = temp;
                        break;
                    case AWACSLines.Cold:
                        output.coldClips = temp;
                        break;
                    case AWACSLines.CompoundDigits:
                        output.compoundDigits = temp;
                        break;
                    case AWACSLines.Fast:
                        output.fastClips = temp;
                        break;
                    case AWACSLines.GoingDown:
                        output.goingDownClips = temp;
                        break;
                    case AWACSLines.GrandSlam:
                        output.grandSlamClips = temp;
                        break;
                    case AWACSLines.GroupBraa:
                        output.groupBraaClips = temp;
                        break;
                    case AWACSLines.GroupBullseye:
                        output.groupBullseyeClips = temp;
                        break;
                    case AWACSLines.HighAltitude:
                        output.highAltitudeClips = temp;
                        break;
                    case AWACSLines.HomeplateBraa:
                        output.homeplateBraaClips = temp;
                        break;
                    case AWACSLines.HostileBraa:
                        output.hostileBraaClips = temp;
                        break;
                    case AWACSLines.HostileBullseye:
                        output.hostileBullseyeClips = temp;
                        break;
                    case AWACSLines.Hot:
                        output.hotClips = temp;
                        break;
                    case AWACSLines.LeansOn:
                        output.leansOnClips = temp;
                        break;
                    case AWACSLines.Low:
                        output.lowClips = temp;
                        break;
                    case AWACSLines.Merged:
                        output.mergedClips = temp;
                        break;
                    case AWACSLines.Overlord:
                        output.overlordClips = temp;
                        break;
                    case AWACSLines.PhoneticAlphabet:
                        output.phoneticAlphabet = temp;
                        break;
                    case AWACSLines.Picture:
                        output.pictureClips = temp;
                        break;
                    case AWACSLines.Popup:
                        output.popupClips = temp;
                        break;
                    case AWACSLines.Range:
                        output.rangeClips = temp;
                        break;
                    case AWACSLines.RTB:
                        output.rtbClips = temp;
                        break;
                    case AWACSLines.Thousand:
                        output.thousandClips = temp;
                        break;
                    case AWACSLines.Unable:
                        output.unableClips = temp;
                        break;
                    default:
                        break;
                }
            }
            return output;
        }

        public List<AudioClip> GenerateMessageAudio(AudioProfileLineType lines)
        {
            List<AudioClip> output = new List<AudioClip>();
            for (int i = 0; i < lines.lines.Count; i++)
            {
                output.Add(lines.lines[i].clip);
            }
            return output;
        }

        public static bool IsMessageType(string name)
        {
            bool output = false;
            foreach (AWACSLines type in Enum.GetValues(typeof(AWACSLines)))
            {
                if (name == type.ToString())
                {
                    output = true;
                }
            }
            return output;
        }

        public static AWACSLines MessageType(string name)
        {
            AWACSLines output = AWACSLines.Cardinal;
            foreach (AWACSLines type in Enum.GetValues(typeof(AWACSLines)))
            {
                if (name == type.ToString())
                {
                    output = type;
                }
            }
            return output;
        }
    }
}
