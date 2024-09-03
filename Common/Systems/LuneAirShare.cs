using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static LuneLib.Common.Players.LuneLibPlayer.LibPlayer;
using static LuneLib.Utilities.LuneLibUtils;
using static LuneLib.LuneLib;

namespace LuneLib.Common.Systems
{
    public class LunesAirShare : ModPlayer
    {
        public override void PostUpdate()
        {
            AirShare();
        }

        public void AirShare()
        {
            if (!LL) return;

            foreach (Player otherPlayer in Main.player)
            {
                if (otherPlayer.active && otherPlayer != Player)
                {
                    float distance = Vector2.Distance(Player.Center, otherPlayer.Center);

                    float maxDistance = TilesToPixels(debug.TargetDistanceAirShare);

                    if (distance <= maxDistance)
                    {
                        otherPlayer.LibPlayer().IsNearLune = true;
                    }
                }
            }
        }
    }
}
