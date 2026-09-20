using System;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace knishfargomusic
{
    public class MusicConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static MusicConfig Instance => ModContent.GetInstance<MusicConfig>();

        public override void OnChanged()
        {
            if (knishfargomusic.Instance != null)
            {
                knishfargomusic.Instance.overrideMutantTheme_GodIWantToDie();
            }
            base.OnChanged();
        }

        [DefaultValue(NowPlayingID.Notification)]
        [DrawTicks]
        public NowPlayingID NowPlayingEnum;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool OverrideModdedMusicBoxes;

        [DefaultValue(true)]
        public bool MutantFtwTheme;
    }
}
