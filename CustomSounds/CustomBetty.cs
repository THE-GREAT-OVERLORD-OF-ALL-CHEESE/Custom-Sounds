using System;
using System.Collections.Generic;
using System.Linq;
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
            public Betty(FlightWarnings.CommonWarningsClips stockBettyWarnings)
            {
                commonWarnings = new FlightWarnings.CommonWarningsClips();

                commonWarnings.EngineFailure = stockBettyWarnings.EngineFailure;
                commonWarnings.LeftEngineFailure = stockBettyWarnings.LeftEngineFailure;
                commonWarnings.RightEngineFailure = stockBettyWarnings.RightEngineFailure;
                commonWarnings.APUFailure = stockBettyWarnings.APUFailure;
                commonWarnings.HydraulicsFailure = stockBettyWarnings.HydraulicsFailure;
                commonWarnings.Chaff = stockBettyWarnings.Chaff;
                commonWarnings.ChaffLow = stockBettyWarnings.ChaffLow;
                commonWarnings.ChaffEmpty = stockBettyWarnings.ChaffEmpty;
                commonWarnings.Flare = stockBettyWarnings.Flare;
                commonWarnings.FlareLow = stockBettyWarnings.FlareLow;
                commonWarnings.FlareEmpty = stockBettyWarnings.FlareEmpty;
                commonWarnings.BingoFuel = stockBettyWarnings.BingoFuel;
                commonWarnings.Altitude = stockBettyWarnings.Altitude;
                commonWarnings.PullUp = stockBettyWarnings.PullUp;
                commonWarnings.OverG = stockBettyWarnings.OverG;
                commonWarnings.MissileLaunch = stockBettyWarnings.MissileLaunch;
                commonWarnings.Missile = stockBettyWarnings.Missile;
                commonWarnings.Shoot = stockBettyWarnings.Shoot;
                commonWarnings.Pitbull = stockBettyWarnings.Pitbull;
                commonWarnings.Warning = stockBettyWarnings.Warning;
                commonWarnings.Fire = stockBettyWarnings.Fire;
                commonWarnings.FuelLeak = stockBettyWarnings.FuelLeak;
                commonWarnings.FuelDump = stockBettyWarnings.FuelDump;
                commonWarnings.LandingGear = stockBettyWarnings.LandingGear;
                commonWarnings.AutopilotOff = stockBettyWarnings.AutopilotOff;
                commonWarnings.WingFold = stockBettyWarnings.WingFold;
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

        public FlightWarnings.CommonWarningsClips stockBettyWarnings;
        public Betty currentBetty;
        public List<Betty> bettys = new List<Betty>();

        protected override void ApplyAudio()
        {
            bettys.Clear();

            if (stockBettyWarnings == null)
            {
                GameObject vehiclePrefab = VTResources.GetPlayerVehicleList().First().vehiclePrefab;
                FlightWarnings fw = vehiclePrefab.GetComponentInChildren<FlightWarnings>(true);
                stockBettyWarnings = fw.commonWarningsClips;
            }

            for (int i = 0; i < audioProfiles.Count; i++)
            {
                bettys.Add(GenerateBettyVoiceProfile(audioProfiles[i]));
            }
        }

        public override void UnloadAudioProfiles()
        {
            base.UnloadAudioProfiles();

            bettys.Clear();
        }

        public Betty GenerateBettyVoiceProfile(AudioProfile profile)
        {
            Betty betty = new Betty(stockBettyWarnings);
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
