using LuneLib.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Content.LunePet
{
    public partial class LPetBuff : ModBuff
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneLib.debug.DI;
        }
        public override string Texture => "LuneLib/Assets/Images/LPet/LPetBuff";
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            if (!LL)
            {
                Main.lightPet[Type] = true; 
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.LibPlayer().LunesSpiritPet = true;
                bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<LPet>()] <= 0;
                if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
                {
                    Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, ModContent.ProjectileType<LPet>(), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
        }
    }
}
