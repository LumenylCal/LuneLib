using Terraria;
using Terraria.ModLoader;

namespace LuneLib.Common.Buffs
{
    //for syncing mostly (im lazy and it works)
    public class Lune : ModBuff
    {
        public override string Texture => "LuneLib/Assets/Images/Buffs/Lune";
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
