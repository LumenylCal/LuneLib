using Terraria.ModLoader;

namespace LuneLib
{
    public partial class LuneLib : Mod
	{
        public static LuneLib instance;

        public bool CalamityModLoaded;
		public bool InfernumModeLoaded;
		public bool CalValExLoaded;
		public bool CalamitasMommyLoaded;
		public bool ThoriumModLoaded;

        public override void Load()
        {
            instance = this;

            CalamityModLoaded = ModLoader.HasMod("CalamityMod");
            InfernumModeLoaded = ModLoader.HasMod("InfernumMode");
            CalValExLoaded = ModLoader.HasMod("CalValEx");
            CalamitasMommyLoaded = ModLoader.HasMod("CalamitasMommy");
            ThoriumModLoaded = ModLoader.HasMod("ThoriumMod");
        }

        public override void Unload()
        {
            instance = null!;
        }
    }
}
