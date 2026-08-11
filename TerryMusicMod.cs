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

        void TryMapMusic(int musicId, string newMusicIdPath, string newMusicName)
        {
            if (musicId == 0)
                return;
            moddedMusicDict.Add(musicId, new Tuple<string, string>(newMusicIdPath, newMusicName));
        }

        public override void PostSetupContent()
        {
            if (/*MusicConfig.Instance.OverrideModdedMusicBoxes &&*/ ModLoader.TryGetMod("FargowiltasMusic", out Mod musicMod))
            {
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Baron"),
                    "Anger",
                    "Sakuzyo - Anger"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Baron2"),
                    "Anger",
                    "Sakuzyo - Anger"
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
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Storia"),
                    "UndyingMacula",
                    "Ashrount - Undying Macula ~penumbra~"
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
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/rePrologue"),
                    "ErodingThePore",
                    "Ashrount - eroding the \"pore\" (interlude)"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/ShiftingSands"),
                    "Labyrinthox",
                    "Paradigm: Reboot - LABYRINTHOX"
                );
				TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/StoriaShort"),
                    "UndyingMacula",
                    "Ashrount - Undying Macula ~penumbra~"
				);
            }
        }
	}
}
