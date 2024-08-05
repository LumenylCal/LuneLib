using CalamityMod.Items.Armor.Victide;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Terraria.ID;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public class LibPlayerData : ModPlayer
    {
        #region all my mods debuffs

            #region Lunes Worse of Life

                public bool BoilFreeze = false; // inspace debuff

            #endregion

            #region Calamitas Mommy (Lunes Shitty Mod) this mod is currently private... its just changes id like to my game

                public bool LunesSpiritPet = false; // custom pet
                public bool WConvert = false; // private but is just for shits and giggles :3
                public bool LcDepth = false; // my custom crush depth debuff
                public bool LTOceanH = false; //dw bout it heel

        #endregion

        #endregion

        #region Is wearing armour type?

            #region Lead Armour

                public static int IsWearingLeadArmor()
                {
                    var headType = L.armor[0].type;
                    var chestType = L.armor[1].type;
                    var legsType = L.armor[2].type;

                    if (headType == ItemID.LeadHelmet && chestType == ItemID.LeadChainmail && legsType == ItemID.LeadGreaves)
                    {
                        return 1;
                    }
                    else if ((headType == ItemID.LeadHelmet || chestType == ItemID.LeadChainmail) && legsType == ItemID.LeadGreaves)
                    {
                        return 2;
                    }
                    else if (headType == ItemID.LeadHelmet && (chestType == ItemID.LeadChainmail || legsType == ItemID.LeadGreaves))
                    {
                        return 2;
                    }
                    else if (headType == ItemID.LeadHelmet && legsType == ItemID.LeadGreaves)
                    {
                        return 2;
                    }
                    else if (headType == ItemID.LeadHelmet || chestType == ItemID.LeadChainmail || legsType == ItemID.LeadGreaves)
                    {
                        return 3;
                    }

                    return 0;

                }

                public static bool WearingFullLead => IsWearingLeadArmor() == 1;
                public static bool WearingTwoLeadPieces => IsWearingLeadArmor() == 2;
                public static bool WearingOneLeadPiece => IsWearingLeadArmor() == 3;

            #endregion

        #endregion

        public override void PostUpdateEquips()
        {
            IsWearingLeadArmor();
        }
    }
}
