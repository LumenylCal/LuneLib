using CalamitasMommy.Content.ChangesToGamePlay;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuneLib
{
    public partial class LuneLib : Mod
    {
        internal enum MessageType : byte
        {
            SyncPos
        }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();

            switch (msgType)
            {
                case MessageType.SyncPos:
                    byte playerNumber = reader.ReadByte();
                    LunesAirShare lunesAirShare = Main.player[playerNumber].GetModPlayer<LunesAirShare>();
                    lunesAirShare.ReceivePlayerSync(reader);

                    if (Main.netMode == NetmodeID.Server)
                    {
                        lunesAirShare.SyncPlayer(-1, whoAmI, false);
                    }
                    break;
                default:
                    Logger.WarnFormat("MANE YOU GONE BROKE MY CODE MF {0}", msgType);
                    break;
            }
        }
    }
}