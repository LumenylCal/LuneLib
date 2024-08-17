using CalamityMod.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public partial class LibPlayer : ModPlayer
    {

        public Player Llune;

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
                public bool IsNearLune = false;

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
            IsNearLune = false;

            currentDepthPressure = 0;

            LunesSpiritPet = false;
            WConvert = false;
            LcDepth = false;
            LTOceanH = false;
        }
    }
}
