using Microsoft.Xna.Framework;
using Terraria;
using static LuneLib.Utilities.LuneLibUtils;
using static LuneLib.LuneLib;

namespace CalamitasMommy.Content.ChangesToGamePlay
{
    public static class EnableLuneAirShare
    {

        public static void LuneAirShareDraw()
        {

        }

        public static void LuneAirShare()
        {
            if (debug.TargetDistanceAirShare == 0) return;

            if (!LTSE)
            {
                return;
            }

            foreach (Player otherPlayer in Main.player)
            {
                if (otherPlayer.active && !otherPlayer.dead && otherPlayer.whoAmI != L.whoAmI)
                {
                    float distanceInTiles = (int)Vector2.Distance(L.Center, otherPlayer.Center);

                    if (distanceInTiles <= 16f * debug.TargetDistanceAirShare)
                    {
                        otherPlayer.breath = otherPlayer.breathMax;
                    }
                }
            }
        }
    }
}