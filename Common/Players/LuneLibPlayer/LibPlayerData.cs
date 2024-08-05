using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public class LibPlayerData : ModPlayer
    {
        #region All My Mods Debuffs

            #region Lunes Worse of Life
            public bool BoilFreeze = false; // In-space debuff
            #endregion

            #region Calamitas Mommy (Lunes Shitty Mod)
            public bool LunesSpiritPet = false; // Custom pet
            public bool WConvert = false; // Private, just for fun
            public bool LcDepth = false; // Custom crush depth debuff
            public bool LTOceanH = false; // Unclear use, placeholder
            #endregion

        #endregion

        #region Is Wearing Armor Type?

            #region Lead Armor
            public bool WearingFullLead { get; private set; }
            public bool WearingTwoLeadPieces { get; private set; }
            public bool WearingOneLeadPiece { get; private set; }

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

            public override void UpdateEquips()
            {
                base.UpdateEquips();
                int leadCount = IsWearingLeadArmor();

                WearingFullLead = leadCount == 3;
                WearingTwoLeadPieces = leadCount == 2;
                WearingOneLeadPiece = leadCount == 1;
            }

            #endregion

        #endregion
    }
}
