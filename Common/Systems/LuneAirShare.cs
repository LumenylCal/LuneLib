using Microsoft.Xna.Framework;
using Terraria;
using static LuneLib.Utilities.LuneLibUtils;
using static LuneLib.LuneLib;
using Terraria.ModLoader;
using ThoriumMod.NPCs;
using System.IO;

namespace CalamitasMommy.Content.ChangesToGamePlay
{
    public class LunesAirShare : ModPlayer
    {
        public Vector2 LunePos;
        public Vector2 YourPos;
        public int PosDif;

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

            if (Player.whoAmI != Main.myPlayer && LTSE)
            {
                LunePos = Player.Center;
            }

            if (Player.whoAmI == Main.myPlayer && !LTSE)
            {
                YourPos = Player.Center;
            }

            PosDif = (int)Vector2.Distance(YourPos, LunePos);

            if (PosDif <= (debug.TargetDistanceAirShare * 16))
            {
                Player.LibPlayer().IsNearLune = true;
            }
            else
            {
                Player.LibPlayer().IsNearLune = false;
            }

            if (LuneLib.LuneLib.debug.DebugMessages && Player.whoAmI == Main.myPlayer)
            {
                Main.NewText($"´LPos = {LunePos}, YPos = {YourPos}, PosD = {PosDif}");
            }
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)MessageType.SyncPos);
            packet.Write((byte)Player.whoAmI);
            packet.WriteVector2(LunePos);
            packet.WriteVector2(YourPos);
            packet.Send(toWho, fromWho);
        }

        public void ReceivePlayerSync(BinaryReader reader)
        {
            LunePos = reader.ReadVector2();
            YourPos = reader.ReadVector2();
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            LunesAirShare clone = (LunesAirShare)targetCopy;
            clone.LunePos = LunePos;
            clone.YourPos = YourPos;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            LunesAirShare clone = (LunesAirShare)clientPlayer;

            if (LunePos != clone.LunePos || YourPos != clone.YourPos)
                SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
        }
    }
}
