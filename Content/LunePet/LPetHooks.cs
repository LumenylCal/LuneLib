using Terraria;
using Terraria.ModLoader;

namespace LuneLib.Content.LunePet
{
    public partial class LPet : ModProjectile
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneLib.debug.DI;
        }
        public override string Texture => "LuneLib/Assets/Images/LPet/LPet";
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 17;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 38;
            Projectile.height = 58;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft *= 5;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (Projectile.owner == Main.myPlayer)
            {
                FollowMouse();
            }
            else
            {
                Projectile.alpha = 255;
                Projectile.light = 0f;
            }
        }
    }
}
