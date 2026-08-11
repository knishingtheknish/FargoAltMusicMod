using System.ComponentModel;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;

namespace knishfargomusic
{
    public class MusicConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static MusicConfig Instance => ModContent.GetInstance<MusicConfig>();

        [DefaultValue(NowPlayingID.Notification)]
        [DrawTicks]
        public NowPlayingID NowPlayingEnum;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool OverrideModdedMusicBoxes;

        [DefaultValue(true)]
        public bool OverrideMutantTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool MutantFtw
        {
            get; set;
        }

    }
}
