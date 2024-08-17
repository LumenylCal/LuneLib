using System;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public partial class LibPlayer : ModPlayer
    {
        #region Is Wearing Armor Type?

        #region Lead Armor

        public static bool WearingFullLead { get; set; }
        public static bool WearingTwoLeadPieces { get; set; }
        public static bool WearingOneLeadPiece { get; set; }
        public static bool WearingAnyLead { get; set; }

        public int IsWearingLeadArmor()
        {
            int leadCount = 0;

            int[] leadArmorIDs = new int[] { ItemID.LeadHelmet, ItemID.LeadChainmail, ItemID.LeadGreaves };
            for (int i = 0; i < 3; i++)
            {
                if (Array.Exists(leadArmorIDs, id => Player.armor[i].type == id))
                {
                    leadCount++;
                }
            }

            return leadCount;
        }

        #endregion

        #region Is weaing any armour

        public static bool WearingFullArmour { get; set; }
        public static bool WearingTwoArmourPieces { get; set; }
        public static bool WearingOneArmourPiece { get; set; }
        public static bool WearingAnyArmour { get; set; }


        public int IsWearingArmor()
        {
            int armourCount = 0;

            for (int i = 0; i < 3; i++)
            {
                if (Player.armor[i].type != ItemID.None)
                {
                    armourCount++;
                }
            }

            return armourCount;
        }

    #endregion

        #region Eskimo

        public static bool WearingFullEskimo { get; set; }
        public static bool WearingTwoEskimoPieces { get; set; }
        public static bool WearingOneEskimoPiece { get; set; }
        public static bool WearingAnyEskimo { get; set; }

        public int IsWearingEskimo()
        {
            int eskimoCount = 0;

            int[] eskimoIDs = new int[] { ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants, ItemID.PinkEskimoHood, ItemID.PinkEskimoCoat, ItemID.PinkEskimoPants };
            for (int i = 0; i < 3; i++)
            {
                if (Array.Exists(eskimoIDs, id => Player.armor[i].type == id))
                {
                    eskimoCount++;
                }
            }

            return eskimoCount;
        }

        #endregion

        #region Register

        public override void PostUpdateEquips()
        {
        int leadCount = IsWearingLeadArmor();

            WearingFullLead = leadCount == 3;
            WearingTwoLeadPieces = leadCount == 2;
            WearingOneLeadPiece = leadCount == 1;
            WearingAnyLead = leadCount > 0;

        int armourCount = IsWearingArmor();

            WearingFullArmour = armourCount == 3;
            WearingTwoArmourPieces = armourCount == 2;
            WearingOneArmourPiece = armourCount == 1;
            WearingAnyArmour = armourCount > 0;
            
        int eskimoCount = IsWearingEskimo();

            WearingFullEskimo = armourCount == 3;
            WearingTwoEskimoPieces = armourCount == 2;
            WearingOneEskimoPiece = armourCount == 1;
            WearingAnyEskimo = armourCount > 0;
        }

        #endregion

        #endregion

        #region Kill Player
        public void KillPlayer()
        {
            var source = Player.GetSource_Death();
            Player.lastDeathPostion = Player.Center;
            Player.lastDeathTime = DateTime.Now;
            Player.showLastDeath = true;
            int coinsOwned = (int)Utils.CoinsCount(out bool flag, Player.inventory, new int[0]);
            if (Main.myPlayer == Player.whoAmI)
            {
                Player.lostCoins = coinsOwned;
                Player.lostCoinString = Main.ValueToCoins(Player.lostCoins);
            }
            if (Main.myPlayer == Player.whoAmI)
            {
                Main.mapFullscreen = false;
            }
            if (Main.myPlayer == Player.whoAmI)
            {
                Player.trashItem.SetDefaults(0, false);
                if (Player.difficulty == PlayerDifficultyID.SoftCore || Player.difficulty == PlayerDifficultyID.Creative)
                {
                    for (int i = 0; i < 59; i++)
                    {
                        if (Player.inventory[i].stack > 0 && ((Player.inventory[i].type >= ItemID.LargeAmethyst && Player.inventory[i].type <= ItemID.LargeDiamond) || Player.inventory[i].type == ItemID.LargeAmber))
                        {
                            int droppedLargeGem = Item.NewItem(source, (int)Player.position.X, (int)Player.position.Y, Player.width, Player.height, Player.inventory[i].type, 1, false, 0, false, false);
                            Main.item[droppedLargeGem].netDefaults(Player.inventory[i].netID);
                            Main.item[droppedLargeGem].Prefix((int)Player.inventory[i].prefix);
                            Main.item[droppedLargeGem].stack = Player.inventory[i].stack;
                            Main.item[droppedLargeGem].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                            Main.item[droppedLargeGem].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
                            Main.item[droppedLargeGem].noGrabDelay = 100;
                            Main.item[droppedLargeGem].favorited = false;
                            Main.item[droppedLargeGem].newAndShiny = false;
                            if (Main.netMode == NetmodeID.MultiplayerClient)
                            {
                                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, droppedLargeGem, 0f, 0f, 0f, 0, 0, 0);
                            }
                            Player.inventory[i].SetDefaults(0, false);
                        }
                    }
                }
                else if (Player.difficulty == PlayerDifficultyID.MediumCore)
                {
                    Player.DropItems();
                }
                else if (Player.difficulty == PlayerDifficultyID.Hardcore)
                {
                    Player.DropItems();
                    Player.KillMeForGood();
                }
            }
            SoundEngine.PlaySound(SoundID.PlayerKilled, Player.Center);
            Player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            Player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            Player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            Player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * 0);
            Player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * 0);
            Player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * 0);
            if (Player.stoned)
            {
                Player.headPosition = Vector2.Zero;
                Player.bodyPosition = Vector2.Zero;
                Player.legPosition = Vector2.Zero;
            }
            for (int j = 0; j < 100; j++)
            {
                Dust.NewDust(Player.position, Player.width, Player.height, DustID.LifeDrain, (float)(2 * 0), -2f, 0, default, 1f);
            }
            Player.mount.Dismount(Player);
            Player.dead = true;
            Player.respawnTimer = 600;
            if (Main.expertMode)
            {
                Player.respawnTimer = (int)(Player.respawnTimer * 1.5);
            }
            Player.immuneAlpha = 0;
            Player.palladiumRegen = false;
            Player.iceBarrier = false;
            Player.crystalLeaf = false;

            PlayerDeathReason damageSource = PlayerDeathReason.ByOther(Player.Male ? 14 : 15);

            NetworkText deathText = damageSource.GetDeathText(Player.name);
            if (Main.netMode == NetmodeID.MultiplayerClient && Player.whoAmI == Main.myPlayer)
            {
                NetMessage.SendPlayerDeath(Player.whoAmI, damageSource, (int)1000.0, 0, false, -1, -1);
            }
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(deathText, new Color(225, 25, 25));
            }
            else if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(deathText.ToString(), 225, 25, 25);
            }

            if (Player.whoAmI == Main.myPlayer && (Player.difficulty == PlayerDifficultyID.SoftCore || Player.difficulty == PlayerDifficultyID.Creative))
            {
                Player.DropCoins();
            }
            Player.DropTombstone(coinsOwned, deathText, 0);

            if (Player.whoAmI == Main.myPlayer)
            {
                try
                {
                    WorldGen.saveToonWhilePlaying();
                }
                catch
                {
                }
            }
        }
        #endregion

    }
}
