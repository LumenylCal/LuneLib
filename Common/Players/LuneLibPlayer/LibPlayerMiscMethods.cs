using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.GameContent.PlayerEyeHelper;
using Terraria.GameContent;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneLib.LuneLib;

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

            int[] leadArmorIDs = [ItemID.LeadHelmet, ItemID.LeadChainmail, ItemID.LeadGreaves];
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

            int[] eskimoIDs = [ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants, ItemID.PinkEskimoHood, ItemID.PinkEskimoCoat, ItemID.PinkEskimoPants];
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

        #region Tungsten armour

        public static bool WearingFullTungsten { get; set; }
        public static bool WearingTwoTungstenPieces { get; set; }
        public static bool WearingOneTungstenPiece { get; set; }
        public static bool WearingAnyTungsten  { get; set; }

        public int IsWearingTungsten()
        {
            int TungstenCount = 0;

            int[] TungstenIDs = [ItemID.TungstenHelmet, ItemID.TungstenChainmail, ItemID.TungstenGreaves];
            for (int i = 0; i < 3; i++)
            {
                if (Array.Exists(TungstenIDs, id => Player.armor[i].type == id))
                {
                    TungstenCount++;
                }
            }

            return TungstenCount;
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

            WearingFullEskimo = eskimoCount == 3;
            WearingTwoEskimoPieces = eskimoCount == 2;
            WearingOneEskimoPiece = eskimoCount == 1;
            WearingAnyEskimo = eskimoCount > 0;
            
        int TungstenCount = IsWearingTungsten();

            WearingFullTungsten = TungstenCount == 3;
            WearingTwoTungstenPieces = TungstenCount == 2;
            WearingOneTungstenPiece = TungstenCount == 1;
            WearingAnyTungsten = TungstenCount > 0;
        }

        #endregion

        #endregion
    }
}
