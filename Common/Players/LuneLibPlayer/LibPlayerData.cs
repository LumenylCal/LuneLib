using InfernumMode.Content.BehaviorOverrides.BossAIs.Draedon.Thanatos;
using System;
using System.Reflection;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

using static Terraria.GameContent.PlayerEyeHelper;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public class LibPlayerData : ModPlayer
    {
        #region All My Mods Debuffs

            #region Lunes Worse of Life

                public bool BoilFreeze = false; // In-space debuff
                public bool BlizzardFrozen = false; //Frozen Blizzard
                public bool LeadPoison = false; // weaing lead armour

            #endregion

            #region Calamitas Mommy (Lunes Shitty Mod PRIVATE)

                public bool LunesSpiritPet = false; // Custom pet
                public bool WConvert = false; // Private, just for fun
                public bool LcDepth = false; // Custom crush depth debuff
                public bool LTOceanH = false; // placeholder

            #endregion

        #endregion

        public override void ResetEffects()
        {
            BoilFreeze = false;
            BlizzardFrozen = false;
            LeadPoison = false;

            LunesSpiritPet = false;
            WConvert = false;
            LcDepth = false;
            LTOceanH = false;
        }

        #region Is Wearing Armor Type?

        #region Lead Armor

        public static bool WearingFullLead { get; set; }
                public static bool WearingTwoLeadPieces { get; set; }
                public static bool WearingOneLeadPiece { get; set; }

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
