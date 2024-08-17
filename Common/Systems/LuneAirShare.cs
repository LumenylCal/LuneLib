using Microsoft.Xna.Framework;
using Terraria;
using static LuneLib.Utilities.LuneLibUtils;
using static LuneLib.LuneLib;
using Terraria.ModLoader;
using ThoriumMod.NPCs;

namespace CalamitasMommy.Content.ChangesToGamePlay
{
    public class EnableLuneAirShare : ModPlayer
    {

        public void LuneAirShareDraw() // make a sprite or some shit
        {

        }
        public override void PostUpdate()
        {
            LuneAirShare();
        }
        public void LuneAirShare()
        {
            if (debug.TargetDistanceAirShare == 0) return;

            if (LTSE)
            {
                Player.LibPlayer().Llune = L;
            }
            if (LuneLib.LuneLib.debug.DebugMessages && Player.whoAmI == Main.myPlayer)
            {
                if (Player.LibPlayer().Llune == L)
                {
                    Main.NewText("Are you Lune?: True");
                }
                else
                {
                    Main.NewText("Are you Lune?: False");
                }
            }
            if (Player.active && !Player.dead && Player.whoAmI == Main.myPlayer && !LTSE && Player.LibPlayer().Llune != null)
            {
                float distanceInTiles = (int)Vector2.Distance(Player.Center, Player.LibPlayer().Llune.Center);

                if (distanceInTiles <= 16f * debug.TargetDistanceAirShare)
                {
                    Player.LibPlayer().IsNearLune = true;
                    Player.breath = Player.breathMax;
                }
                else
                {
                    Player.LibPlayer().IsNearLune = false;
                }
            }
        }
    }
}