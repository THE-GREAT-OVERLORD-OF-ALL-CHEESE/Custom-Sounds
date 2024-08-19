using System;
using System.Collections.Generic;
using UnityEngine;

namespace CheeseMods.CustomSounds
{
    public class CustomATC : CustomSoundsBase
    {
        public enum ATCLines
        {
            Bolter,
            CallTheBall,
            CancelRequest,
            CatapultReady,
            ClearedForTakeoffRunway,
            ClearedVerticalLanding,
            ClearedVerticalTakeoff,
            ComeLeft,
            ContactedWrongTower,
            ExpectRunway,
            FoulDeck,
            HoldShortAtRunway,
            LandedBeforeClearance,
            LandedElsewhere,
            LandingClearedAtCarrier,
            LandingClearedAtRunway,
            LandingPatternFull,
            LandingRequestFlyHeading,
            Letters,
            LinedUp,
            Numbers,
            ParallelDesignation,
            PowerLow,
            PreCatapult,
            RightLineup,
            RogerBall,
            TaxiToCatapult,
            TaxiToParkingZone,
            TaxiToRunway,
            Tower,
            Unable,
            WaitForCatapultClearance,
            WaveOff,
            XWire,
            YoureHigh
        }

        public List<ATCVoiceProfile> atcVoiceProfiles = new List<ATCVoiceProfile>();

        protected override void ApplyAudio()
        {
            for (int i = 0; i < audioProfiles.Count; i++)
            {
                atcVoiceProfiles.Add(GenerateATCVoiceProfile(audioProfiles[i]));
            }
        }

        public ATCVoiceProfile GenerateATCVoiceProfile(AudioProfile profile)
        {
            ATCVoiceProfile output = ScriptableObject.CreateInstance<ATCVoiceProfile>();
            output.name = profile.name;
            foreach (AudioProfileLineType lines in profile.lineTypes)
            {
                List<AudioClip> temp = GenerateMessageAudio(lines);
                switch (MessageType(lines.type))
                {
                    case ATCLines.Bolter:
                        output.bolterClips = temp;
                        break;
                    case ATCLines.CallTheBall:
                        output.callTheBallClips = temp;
                        break;
                    case ATCLines.CancelRequest:
                        output.cancelRequestClips = temp;
                        break;
                    case ATCLines.CatapultReady:
                        output.catapultReadyClips = temp;
                        break;
                    case ATCLines.ClearedForTakeoffRunway:
                        output.clearedForTakeoffRunwayClips = temp;
                        break;
                    case ATCLines.ClearedVerticalTakeoff:
                        output.clearedVerticalTakeoffClips = temp;
                        break;
                    case ATCLines.ClearedVerticalLanding:
                        output.clearedVerticalLandingClips = temp;
                        break;
                    case ATCLines.ComeLeft:
                        output.comeLeftClips = temp;
                        break;
                    case ATCLines.ContactedWrongTower:
                        output.contactedWrongTowerClips = temp;
                        break;
                    case ATCLines.ExpectRunway:
                        output.expectRunwayClips = temp;
                        break;
                    case ATCLines.FoulDeck:
                        output.foulDeckClips = temp;
                        break;
                    case ATCLines.HoldShortAtRunway:
                        output.holdShortAtRunwayClips = temp;
                        break;
                    case ATCLines.LandedBeforeClearance:
                        output.landedBeforeClearanceClips = temp;
                        break;
                    case ATCLines.LandedElsewhere:
                        output.landedElsewhereClips = temp;
                        break;
                    case ATCLines.LandingClearedAtCarrier:
                        output.landingClearedAtCarrierClips = temp;
                        break;
                    case ATCLines.LandingClearedAtRunway:
                        output.landingClearedAtRunwayClips = temp;
                        break;
                    case ATCLines.LandingPatternFull:
                        output.landingPatternFullClips = temp;
                        break;
                    case ATCLines.LandingRequestFlyHeading:
                        output.landingRequestFlyHeadingClips = temp;
                        break;
                    case ATCLines.Letters:
                        output.letterClips = temp;
                        break;
                    case ATCLines.LinedUp:
                        output.linedUpClips = temp;
                        break;
                    case ATCLines.Numbers:
                        output.numberClips = temp;
                        break;
                    case ATCLines.ParallelDesignation:
                        output.parallelDesignationClips = temp;
                        break;
                    case ATCLines.PowerLow:
                        output.powerLowClips = temp;
                        break;
                    case ATCLines.PreCatapult:
                        output.preCatapultClips = temp;
                        break;
                    case ATCLines.RightLineup:
                        output.rightLineupClips = temp;
                        break;
                    case ATCLines.RogerBall:
                        output.rogerBallClips = temp;
                        break;
                    case ATCLines.TaxiToCatapult:
                        output.taxiToCatapultClips = temp;
                        break;
                    case ATCLines.TaxiToParkingZone:
                        output.taxiToParkingZoneClips = temp;
                        break;
                    case ATCLines.TaxiToRunway:
                        output.taxiToRunwayClips = temp;
                        break;
                    case ATCLines.Tower:
                        output.towerClips = temp;
                        break;
                    case ATCLines.Unable:
                        output.unableClips = temp;
                        break;
                    case ATCLines.WaitForCatapultClearance:
                        output.waitForCatapultClearanceClips = temp;
                        break;
                    case ATCLines.WaveOff:
                        output.waveOffClips = temp;
                        break;
                    case ATCLines.XWire:
                        output.xWireClips = temp;
                        break;
                    case ATCLines.YoureHigh:
                        output.youreHighClips = temp;
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
            foreach (ATCLines type in Enum.GetValues(typeof(ATCLines)))
            {
                if (name == type.ToString())
                {
                    output = true;
                }
            }
            return output;
        }

        public static ATCLines MessageType(string name)
        {
            ATCLines output = ATCLines.Bolter;
            foreach (ATCLines type in Enum.GetValues(typeof(ATCLines)))
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
