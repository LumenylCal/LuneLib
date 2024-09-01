using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LuneWoL.Content.LunePet
{
    public partial class LPet : ModProjectile
    {
        public override void AI()
        {
            FollowMouse();
        }
    }
}
