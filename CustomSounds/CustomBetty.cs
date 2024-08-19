using System;
using System.Collections.Generic;
using UnityEngine;

namespace CheeseMods.CustomSounds
{
    public class CustomBetty : CustomSoundsBase
    {
        public enum CommonWarnings2
        {
            EngineFailure,
            LeftEngineFailure,
            RightEngineFailure,
            APUFailure,
            HydraulicsFailure,
            Chaff,
            ChaffLow,
            ChaffEmpty,
            Flare,
            FlareLow,
            FlareEmpty,
            BingoFuel,
            Altitude,
            PullUp,
            OverG,
            MissileLaunch,
            Missile,
            Shoot,
            Pitbull,
            Warning,
            Fire,
            FuelLeak,
            FuelDump,
            LandingGear,
            AutopilotOff,
            WingFold,

            RWRBlip,
            RWRIRMissileIncoming,
            RWRLockBlip,
            RWRMissileLoopLock,
            RWRNewContactBlip,
            RWRSarhLockBlip,

            HUDCollisionWarning,
            HUDStallWarning
        }

        public class Betty {
            public Betty()
            {
                commonWarnings = new FlightWarnings.CommonWarningsClips();
            }

            public string name;

            public FlightWarnings.CommonWarningsClips commonWarnings = new FlightWarnings.CommonWarningsClips();

            public AudioClip blip;
            public AudioClip irMissileIncoming;
            public AudioClip lockBlip;
            public AudioClip missileLoopLock;
            public AudioClip newContactBlip;
            public AudioClip sarhLockBlip;

            public AudioClip collisionWarning;
            public AudioClip stallWarning;
        }

        public Betty currentBetty;
        public List<Betty> bettys = new List<Betty>();

        protected override void ApplyAudio()
        {
            for (int i = 0; i < audioProfiles.Count; i++)
            {
                bettys.Add(GenerateBettyVoiceProfile(audioProfiles[i]));
            }
        }

        public Betty GenerateBettyVoiceProfile(AudioProfile profile)
        {
            Betty betty = new Betty();
            betty.name = profile.name;
            foreach (AudioProfileLineType lines in profile.lineTypes)
            {
                AudioClip temp = GenerateMessageAudio(lines)[0];
                switch (MessageType(lines.type))
                {
                    case CommonWarnings2.EngineFailure:
                        betty.commonWarnings.EngineFailure = temp;
                        break;
                    case CommonWarnings2.LeftEngineFailure:
                        betty.commonWarnings.LeftEngineFailure = temp;
                        break;
                    case CommonWarnings2.RightEngineFailure:
                        betty.commonWarnings.RightEngineFailure = temp;
                        break;
                    case CommonWarnings2.APUFailure:
                        betty.commonWarnings.APUFailure = temp;
                        break;
                    case CommonWarnings2.HydraulicsFailure:
                        betty.commonWarnings.HydraulicsFailure = temp;
                        break;
                    case CommonWarnings2.Chaff:
                        betty.commonWarnings.Chaff = temp;
                        break;
                    case CommonWarnings2.ChaffLow:
                        betty.commonWarnings.ChaffLow = temp;
                        break;
                    case CommonWarnings2.ChaffEmpty:
                        betty.commonWarnings.ChaffEmpty = temp;
                        break;
                    case CommonWarnings2.Flare:
                        betty.commonWarnings.Flare = temp;
                        break;
                    case CommonWarnings2.FlareLow:
                        betty.commonWarnings.FlareLow = temp;
                        break;
                    case CommonWarnings2.FlareEmpty:
                        betty.commonWarnings.FlareEmpty = temp;
                        break;
                    case CommonWarnings2.BingoFuel:
                        betty.commonWarnings.BingoFuel = temp;
                        break;
                    case CommonWarnings2.Altitude:
                        betty.commonWarnings.Altitude = temp;
                        break;
                    case CommonWarnings2.PullUp:
                        betty.commonWarnings.PullUp = temp;
                        break;
                    case CommonWarnings2.OverG:
                        betty.commonWarnings.OverG = temp;
                        break;
                    case CommonWarnings2.MissileLaunch:
                        betty.commonWarnings.MissileLaunch = temp;
                        break;
                    case CommonWarnings2.Missile:
                        betty.commonWarnings.Missile = temp;
                        break;
                    case CommonWarnings2.Shoot:
                        betty.commonWarnings.Shoot = temp;
                        break;
                    case CommonWarnings2.Pitbull:
                        betty.commonWarnings.Pitbull = temp;
                        break;
                    case CommonWarnings2.Warning:
                        betty.commonWarnings.Warning = temp;
                        break;
                    case CommonWarnings2.Fire:
                        betty.commonWarnings.Fire = temp;
                        break;
                    case CommonWarnings2.FuelLeak:
                        betty.commonWarnings.FuelLeak = temp;
                        break;
                    case CommonWarnings2.FuelDump:
                        betty.commonWarnings.FuelDump = temp;
                        break;
                    case CommonWarnings2.LandingGear:
                        betty.commonWarnings.LandingGear = temp;
                        break;
                    case CommonWarnings2.AutopilotOff:
                        betty.commonWarnings.AutopilotOff = temp;
                        break;
                    case CommonWarnings2.WingFold:
                        betty.commonWarnings.WingFold = temp;
                        break;


                    case CommonWarnings2.RWRBlip:
                        betty.blip = temp;
                        break;
                    case CommonWarnings2.RWRIRMissileIncoming:
                        betty.irMissileIncoming = temp;
                        break;
                    case CommonWarnings2.RWRLockBlip:
                        betty.lockBlip = temp;
                        break;
                    case CommonWarnings2.RWRMissileLoopLock:
                        betty.missileLoopLock = temp;
                        break;
                    case CommonWarnings2.RWRNewContactBlip:
                        betty.newContactBlip = temp;
                        break;
                    case CommonWarnings2.RWRSarhLockBlip:
                        betty.sarhLockBlip = temp;
                        break;


                    case CommonWarnings2.HUDCollisionWarning:
                        betty.collisionWarning = temp;
                        break;
                    case CommonWarnings2.HUDStallWarning:
                        betty.stallWarning = temp;
                        break;
                    default:
                        break;
                }
            }
            return betty;
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
            bool commonWarnings = false;
            foreach (CommonWarnings2 type in Enum.GetValues(typeof(CommonWarnings2)))
            {
                if (name == type.ToString())
                {
                    commonWarnings = true;
                }
            }
            return commonWarnings;
        }

        public static CommonWarnings2 MessageType(string name)
        {
            CommonWarnings2 commonWarnings = CommonWarnings2.EngineFailure;
            foreach (CommonWarnings2 type in Enum.GetValues(typeof(CommonWarnings2)))
            {
                if (name == type.ToString())
                {
                    commonWarnings = type;
                }
            }
            return commonWarnings;
        }
    }
}
