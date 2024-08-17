using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneLib.Common.Config
{
    public class Debug : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("debug101")]

        [DefaultValue(false)]
        public bool Eyes { get; set; }
        
        [DefaultValue(false)]
        public bool DebugMessages { get; set; }
        
        [DefaultValue(0)]
        [Range(-1, int.MaxValue)]
        public int TargetDistanceAirShare { get; set; }

        public override void OnLoaded()
        {
            LuneLib.debug = this;
        }
    }
}