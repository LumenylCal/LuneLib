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
    }
}
