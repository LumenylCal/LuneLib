using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneWOL.Config
{
    public class Debug : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("debug101")]

        [DefaultValue(false)]
        public bool asd { get; set; }

        public override void OnLoaded()
        {
            LuneLib.LuneLib.debug = this;
        }
    }
}