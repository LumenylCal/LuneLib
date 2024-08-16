using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public class LibPlayerData : ModPlayer
    {

        #region LuneHeadCovered

            public override void PostUpdate()
            {
                float value = 0f;
                float amount = 0.1f;
                if (Player.LibPlayer().LStormEyeCovered && Player.whoAmI == Main.myPlayer)
		        {
                    value = 0.8f;
			        amount = 0.1f;
		        }
                else if (Player.LibPlayer().LNightEyes && Player.whoAmI == Main.myPlayer)
		        {
                    value = 0.7f;
			        amount = 0.1f;
		        }
            	ScreenObstruction.screenObstruction = MathHelper.Lerp(ScreenObstruction.screenObstruction, value, amount);
            }

        #endregion


        #region All My Mods Debuffs

            #region Lunes Worse of Life

                public bool BoilFreeze = false; // In-space debuff
                public bool BlizzardFrozen = false; //Frozen Blizzard
                public bool Chilly = false; //in tundra
                public bool LeadPoison = false; // weaing lead armour
                public bool CrimtuptionzoneNight = false; // In crimtuption during night
                public bool NightChild = false; // Nighty night
                public bool HeatStroke = false; // HeatStroke
                public bool depthwaterPressure = false; // Stage 1 Pressure
                public bool LWaterEyes = false;
                public bool LStormEyeCovered = false;
                public bool LNightEyes = false;

                public int currentDepthPressure = 0; // Current Depth Pressure to apply bad regen with

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
            CrimtuptionzoneNight = false;
            Chilly = false;
            NightChild = false;
            HeatStroke = false;
            depthwaterPressure = false;
            LWaterEyes = false;
            LStormEyeCovered = false;
            LNightEyes = false;

            currentDepthPressure = 0;

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

                        int armourCount = IsWearingArmor();

                        WearingFullArmour = armourCount == 3;
                        WearingTwoArmourPieces = armourCount == 2;
                        WearingOneArmourPiece = armourCount == 1;
                        WearingAnyArmour = armourCount > 0;
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

        #endregion

    }
}
