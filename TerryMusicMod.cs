using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using static Terraria.Main;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace knishfargomusic
{
	public class knishfargomusic : Mod
	{
		internal static knishfargomusic Instance;
		public override void Load()
		{
			Instance = this;
		}
		public override void Unload()
		{
			Instance = null;
		}

		public Dictionary<int, Tuple<string, string>> moddedMusicDict = new Dictionary<int, Tuple<string, string>>();
        private bool isFullyLoaded = false;

        public bool overrideFtw => MusicConfig.Instance.MutantFtwTheme;

        void TryMapMusic(int musicId, string newMusicIdPath, string newMusicName)
        {
            if (musicId == 0)
                return;
            moddedMusicDict.Add(musicId, new Tuple<string, string>(newMusicIdPath, newMusicName));
        }

        // literally the worst bit of code ever written for a tmod
        public void overrideMutantTheme_GodIWantToDie()
        {
            if (!isFullyLoaded) return;

            if (!overrideFtw && ModLoader.TryGetMod("FargowiltasMusic", out Mod musicMod))
            {
                moddedMusicDict[MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Storia")] = new Tuple<string, string>(
                    "UndyingMacula",
                    "Ashrount - Undying Macula ~penumbra~"
                );
                moddedMusicDict[MusicLoader.GetMusicSlot(musicMod, "Assets/Music/StoriaShort")] = new Tuple<string, string>(
                    "UndyingMacula",
                    "Ashrount - Undying Macula ~penumbra~"
                );
                moddedMusicDict[MusicLoader.GetMusicSlot(musicMod, "Assets/Music/rePrologue")] = new Tuple<string, string>(
                    "ErodingThePore",
                    "Ashrount - eroding the \"pore\" (interlude)"
                );
            }
            else if (overrideFtw && ModLoader.TryGetMod("FargowiltasMusic", out Mod musicModA))
            {
                moddedMusicDict[MusicLoader.GetMusicSlot(musicModA, "Assets/Music/Storia")] = new Tuple<string, string>(
                    "LostRequiem",
                    "Ludicin - Lost Requiem"
                );
                moddedMusicDict[MusicLoader.GetMusicSlot(musicModA, "Assets/Music/StoriaShort")] = new Tuple<string, string>(
                    "LostRequiem",
                    "Ludicin - Lost Requiem"
                );
                moddedMusicDict[MusicLoader.GetMusicSlot(musicModA, "Assets/Music/rePrologue")] = new Tuple<string, string>(
                    "LostRequiem",
                    "Ludicin - Lost Requiem"
                );
            }
        }

        public override void PostSetupContent()
        {
            if (MusicConfig.Instance.OverrideModdedMusicBoxes && ModLoader.TryGetMod("FargowiltasMusic", out Mod musicMod))
            {
                isFullyLoaded = true;
                overrideMutantTheme_GodIWantToDie();

                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Baron"),
                    "AtoBossTheme",
                    "Arknights OST - Ato Boss Theme"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Baron2"),
                    "AtoBossTheme",
                    "Arknights OST - Ato Boss Theme"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Champions"),
                    "YuzurihaTheme",
                    "UNI2 OST - Aruku Sugata Ha Yuri No Hana (Yuzuriha Theme)"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Laevateinn_P1"),
                    "AndrogynousFullPhase",
                    "WAiKURO - Androgynous (Full Phase)"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Laevateinn_P2"),
                    "AndrogynousFullPhase",
                    "WAiKURO - Androgynous (Full Phase)"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/LieflightNoCum"),
                    "EltnumTheme",
                    "UNI2 OST - Blood Drain -Again- (Eltnum Theme)"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/PlatinumStar"),
                    "Kaguya",
                    "BlackY - Kaguya"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/SteelRed"),
                    "ErodingThePore",
                    "Ashrount - eroding the \"pore\" (interlude)"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Strawberry_Sparkly_Sunrise"),
                    "CutieMewMewMagic",
                    "DELTARUNE - Cutie Mew Mew Magic"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/TrojanSquirrel"),
                    "Shinobi",
                    "BlackY - Shinobi"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/WillChampion"),
                    "YuzurihaTheme",
                    "UNI2 OST - Aruku Sugata Ha Yuri No Hana (Yuzuriha Theme)"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/ShiftingSands"),
                    "Labyrinthox",
                    "Paradigm: Reboot - LABYRINTHOX"
                );
                /*TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Storia"),
                    "LostRequiem",
                    "Ludicin - Lost Requiem"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/StoriaShort"),
                    "LostRequiem",
                    "Ludicin - Lost Requiem"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/rePrologue"),
                    "LostRequiem",
                    "Ludicin - Lost Requiem"
                );*/
            }
        }
	}
}
