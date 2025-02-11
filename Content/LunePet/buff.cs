using Terraria;
using Terraria.ModLoader;

namespace LuneLib.Content.LunePet
{
    public partial class Lune : ModBuff
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneLib.debug.LL;
        }
        public override string Texture => "LuneLib/Assets/Images/Invisible";
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
        }
    }
}
