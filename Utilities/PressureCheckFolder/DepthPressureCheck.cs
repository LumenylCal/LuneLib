using Terraria.ModLoader;
using Terraria;

namespace LuneLib.Utilities.PressureCheckFolder
{
    public class DepthPressureCheck : ModPlayer
    {
        public static Pools Pools = new Pools();

        private Pool? CurrentlyInThisPool;
        public bool WasDrowningLastFrame { get; set; }


        public override void PostUpdate()
        {
            CheckWaterDepth();

        }

        private void CheckWaterDepth()
        {
            bool currentlyDrowning = Collision.DrownCollision(Player.position, Player.width, Player.height, Player.gravDir);

            if (currentlyDrowning)
            {
                if (!WasDrowningLastFrame)
                {
                     CurrentlyInThisPool = Pools.FindPool(Player.Center);

                    Main.NewText($"{CurrentlyInThisPool} {CurrentlyInThisPool.SurfaceY}");
                }

                if (CurrentlyInThisPool != null)
                {
                    var poolSurfaceY = CurrentlyInThisPool.SurfaceY;
                }
            }

            if (!currentlyDrowning && WasDrowningLastFrame) CurrentlyInThisPool = null;

            WasDrowningLastFrame = currentlyDrowning;
        }
    }
}
