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
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/LieFlightNoCum"),
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
            }
        }
	}

    // imported from AltMusicSceneEffect because
    abstract class MusicEffect : ModSceneEffect
    {
        public abstract string MusicName { get; }
        public int timer;
        public const int IMMERSIVE_SONG_TIME = 120;
        public override int Music => MusicLoader.GetMusicSlot(Mod, $"Music/{MusicName}");
        public override bool IsSceneEffectActive(Player player)
        {
            return Active(player);
        }
        public override float GetWeight(Player player) => 0.6f;
        public abstract bool MyMusicConfig { get; }
        public abstract NPC TryGetActiveNPC { get; }
        public abstract string DisplayMusicName { get; }
        public virtual bool Active(Player player)
        {
            if (!MyMusicConfig)
                return false;
            NPC npc = TryGetActiveNPC;
            if (npc != null)
                timer = true ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!true || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = DisplayMusicName;
                return true;
            }
            return false;
        }
    }

    static class MusicUtils
    {
        private static Mod souls = null;
        private static bool checkedSouls = false;
        public static Mod Souls
        {
            get
            {
                if (!checkedSouls)
                {
                    checkedSouls = true;
                    if (ModLoader.HasMod("FargowiltasSouls"))
                        souls = ModLoader.GetMod("FargowiltasSouls");
                }
                return souls;
            }
        }

        public static bool BossMusicRange(this NPC npc)
        {
            int range = 5500;
            Rectangle value = new Rectangle((int)(npc.position.X + (float)(npc.width / 2)) - range, (int)(npc.position.Y + (float)(npc.height / 2)) - range, range * 2, range * 2);
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            return (rectangle.Intersects(value));
        }

        public static NPC FindClosestBoss(int type)
        {
            float num = 99999;
            NPC closestNPC = null;
            foreach (NPC npc in npc.Where(n => n != null && n.active && n.type == type))
            {
                if (npc.BossMusicRange() && npc.Distance(LocalPlayer.Center) < num)
                {
                    num = npc.Distance(LocalPlayer.Center);
                    closestNPC = npc;
                }
            }
            return closestNPC;
        }

        public static NPC FindClosestSoulsBoss(string name)
        {
            if (MusicUtils.Souls == null)
                return null;
            return FindClosestBoss(Souls.Find<ModNPC>(name).Type);
        }

    }

    #region Bosses
    class Mutant : MusicEffect
    {
        public override SceneEffectPriority Priority => (SceneEffectPriority)9;
        private bool useAltMusic => MusicConfig.Instance.MutantFtw &&
            (MusicUtils.Souls.Version >= Version.Parse("1.8") ? (bool)MusicUtils.Souls.Call("MasochistMode") : Main.getGoodWorld);
        public override string MusicName => useAltMusic ? "ErodingThePore" : "UndyingMacula";
        public override bool MyMusicConfig => (MusicUtils.Souls != null) && (MusicConfig.Instance.OverrideMutantTheme || useAltMusic);
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("MutantBoss");
        public override string DisplayMusicName => useAltMusic ? "Ashrount - eroding the \"pore\" (interlude)" : "Ashrount - Undying Macula ~penumbra~";
    }
    #endregion
}