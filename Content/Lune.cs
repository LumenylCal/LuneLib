using LuneLib.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace LuneLib.Content
{
    public class Lune : ModBuff
    {
        public override string Texture => "LuneLib/Assets/Images/Invisible";

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.LibPlayer().Lune = true;
        }
    }
}
