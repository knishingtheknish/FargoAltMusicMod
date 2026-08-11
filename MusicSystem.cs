using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace knishfargomusic
{
    public class MusicSystem : ModSystem
    {
        public static int GetMusic(string name) => MusicLoader.GetMusicSlot(knishfargomusic.Instance, $"Music/{name}");

        private const BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        public override void Load()
        {
            MonoModHooks.Add(Update, Update_Detour);
        }

        public static int OverrideMusicID(int i)
        {
            if (Main.gameMenu)
                return i;
            int old = i;
            var config = MusicConfig.Instance;
            switch (i)
            {
                case MusicID.TownDay:
                    i = GetMusic("Music_46");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Room";
                    break;

                case MusicID.TownNight:
                    i = GetMusic("Music_47");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - ArkGarden (feat. Enoa (Hikaru Tono)) [DARK])";
                    break;

                case MusicID.OverworldDay:
                    i = GetMusic("Music_1");
                    TerryMusicSystem.nowPlayingString = "Nier Automata OST - City Ruins - Rays of Light";
                    break;

                case MusicID.AltOverworldDay:
                    i = GetMusic("Music_18");
                    TerryMusicSystem.nowPlayingString = "Hollow Knight OST - Greenpath";
                    break;

                case MusicID.Night:
                    i = GetMusic("Music_3");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Sob";
                    break;

                case MusicID.WindyDay:
                    i = GetMusic("Music_44");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Day";
                    break;

                case MusicID.Underground:
                    i = GetMusic("Music_44");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Dear (feat. Katali)";
                    break;

                case MusicID.AltUnderground:
                    i = GetMusic("Music_31");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Distant Days";
                    break;

                case MusicID.Desert:
                case MusicID.UndergroundDesert:
                    i = GetMusic("Music_21");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Starlight";
                    break;

                case MusicID.Snow:
                case MusicID.Ice:
                    i = GetMusic("Music_14");
                    TerryMusicSystem.nowPlayingString = "UNI2 OST - Snow Sisters (Vatista Theme)";
                    break;

                case MusicID.Jungle:
                    i = GetMusic("Music_7");
                    TerryMusicSystem.nowPlayingString = "UNI2 OST - Begin System Cerestrial...)";
                    break;

                case MusicID.JungleNight:
                    i = GetMusic("Music_55");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Recollection";
                    break;

                case MusicID.JungleUnderground:
                    i = GetMusic("Music_54");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Twilight";
                    break;

                case MusicID.TheHallow:
                    i = GetMusic("Music_9");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - MakeFlowerCrown";
                    break;

                case MusicID.UndergroundHallow:
                    i = GetMusic("Music_11");
                    TerryMusicSystem.nowPlayingString = "Limbus Company OST - Dulcinea";
                    break;

                case MusicID.Corruption:
                    i = GetMusic("Music_8");
                    TerryMusicSystem.nowPlayingString = "UNI2 OST - Nightwalker (Linne's Theme)";
                    break;

                case MusicID.UndergroundCorruption:
                    i = GetMusic("RiverTwygzBed");
                    TerryMusicSystem.nowPlayingString = "Hollow Knight OST - Kingdom's Edge";
                    break;

                case MusicID.Crimson:
                    i = GetMusic("Music_16");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Revenger";
                    break;

                case MusicID.UndergroundCrimson:
                    i = GetMusic("Music_33");
                    TerryMusicSystem.nowPlayingString = "Ashrount - now the beginning \"vandalize\"";
                    break;

                case MusicID.Ocean:
                    i = GetMusic("Music_22");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Limbus";
                    break;

                case MusicID.OceanNight:
                    i = GetMusic("Music_43");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - 0 -Sonata-";
                    break;

                case MusicID.Space:
                case MusicID.SpaceDay:
                    i = GetMusic("Music_15");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Blue Fairy";
                    break;

                case MusicID.Hell:
                    i = GetMusic("Music_36");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - The End of the World";
                    break;

                case MusicID.Mushrooms:
                    i = GetMusic("Music_29");
                    TerryMusicSystem.nowPlayingString = "Hollow Knight OST - Fungal Wastes";
                    break;

                case MusicID.Dungeon:
                    i = GetMusic("Music_23");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Ordeal";
                    break;

                case MusicID.Temple:
                    i = GetMusic("Music_26");
                    TerryMusicSystem.nowPlayingString = "Limbus Company OST - Muga Ryoshu";
                    break;

                case MusicID.Rain:
                case MusicID.MorningRain:
                    i = GetMusic("Music_19");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - 0";
                    break;

                case MusicID.Monsoon:
                    i = GetMusic("Music_52");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Emotion";
                    break;

                case MusicID.Graveyard:
                    i = GetMusic("Music_53");
                    TerryMusicSystem.nowPlayingString = "CRYSTAR OST (Sakuzyo) - Game Over";
                    break;

                case MusicID.Eerie:
                    i = GetMusic("Music_2");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Initiation";
                    break;

                case MusicID.Sandstorm:
                    i = GetMusic("Music_40");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Starlight";
                    break;

                case MusicID.Shimmer:
                    i = GetMusic("Music_91");
                    TerryMusicSystem.nowPlayingString = "Hollow Knight OST - Queen's Gardens";
                    break;

                case MusicID.GoblinInvasion:
                    i = GetMusic("Music_39");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Prison";
                    break;

                case MusicID.TheTowers:
                    i = GetMusic("Music_39");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Trickstar";
                    break;

                case MusicID.SlimeRain:
                    i = GetMusic("Music_48");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Spirits";
                    break;

                case MusicID.Boss1:
                    i = GetMusic("Music_5");
                    TerryMusicSystem.nowPlayingString = "Limbus Company OST - Middle";
                    break;

                case MusicID.Boss2:
                    i = GetMusic("Music_12");
                    TerryMusicSystem.nowPlayingString = "Limbus Company OST - Lei Heng";
                    break;

                case MusicID.Boss3:
                    i = GetMusic("Music_13");
                    TerryMusicSystem.nowPlayingString = "God Hand OST 33 - Devil May Sly";
                    break;

                case MusicID.Boss4:
                    i = GetMusic("Music_17");
                    TerryMusicSystem.nowPlayingString = "Limbus Company OST - Pinky";
                    break;

                case MusicID.Boss5:
                    i = GetMusic("Music_25");
                    TerryMusicSystem.nowPlayingString = "Limbus Company OST - Thumb";
                    break;

                case MusicID.Deerclops:
                    i = GetMusic("Music_90");
                    TerryMusicSystem.nowPlayingString = "Xenoblade Chronicles 3 OST - Carrying The Weight of Life";
                    break;

                case MusicID.QueenSlime:
                    i = GetMusic("Music_56");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Valiant";
                    break;

                case MusicID.Plantera:
                    i = GetMusic("Music_24");
                    TerryMusicSystem.nowPlayingString = "Block Tales OST - Bubonic Plant";
                    break;

                case MusicID.EmpressOfLight:
                    i = GetMusic("Music_57");
                    TerryMusicSystem.nowPlayingString = "Arknights OST - Minima/Ideal City Boss Battle Theme";
                    break;

                case MusicID.DukeFishron:
                    i = GetMusic("Music_58");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Crystar";
                    break;

                case MusicID.LunarBoss:
                    i = GetMusic("Music_38");
                    TerryMusicSystem.nowPlayingString = "BlackY - Alea jacta est! (Long ver.)";
                    break;

                case MusicID.PirateInvasion:
                    i = GetMusic("Music_35");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Flame";
                    break;

                case MusicID.Eclipse:
                    i = GetMusic("Music_27");
                    TerryMusicSystem.nowPlayingString = "ak+q - Excelsia";
                    break;

                case MusicID.PumpkinMoon:
                    i = GetMusic("EchoesOfMemoria");
                    TerryMusicSystem.nowPlayingString = "Ludicin - Echoes of Memoria";
                    break;

                case MusicID.FrostMoon:
                    i = GetMusic("Music_32");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Beat Beat Beat";
                    break;

                case MusicID.OldOnesArmy:
                    i = GetMusic("Music_41");
                    TerryMusicSystem.nowPlayingString = "Sakuzyo - Desperate";
                    break;

                case MusicID.MartianMadness:
                    i = GetMusic("Music_37");
                    TerryMusicSystem.nowPlayingString = "DELTARUNE - THE WORLD REVOLVING";
                    break;

                case MusicID.Title:
                case MusicID.MenuMusic:
                    i = GetMusic("Music_6");
                    TerryMusicSystem.nowPlayingString = "Hollow Knight OST - Dirtmouth";
                    break;

                case MusicID.Credits:
                    i = GetMusic("WeightOfTheWorld");
                    TerryMusicSystem.nowPlayingString = "Nier Automata OST - Weight of The World/The End of YorHa";
                    break;
            }
            if (knishfargomusic.Instance.moddedMusicDict.ContainsKey(i))
            {
                var tuple = knishfargomusic.Instance.moddedMusicDict[i];
                //Main.NewText($"get! {i} {tuple.ToString()}");
                i = GetMusic(tuple.Item1);
                TerryMusicSystem.nowPlayingString = tuple.Item2;
            }
            if (i >= Main.musicFade.Length)
                return old;
            return i;
        }

        private static readonly MethodInfo Update = typeof(LegacyAudioSystem).GetMethod("Update", UniversalBindingFlags);
        public delegate void Orig_Update(LegacyAudioSystem self);
        internal static void Update_Detour(Orig_Update orig, LegacyAudioSystem self)
        {
            Main.newMusic = OverrideMusicID(Main.newMusic);
            orig(self);
        }
    }
}
