using Terraria.ModLoader;
using LuneLib.Common.Config;
using System;
using Terraria.GameContent;
using Terraria;

using static Terraria.GameContent.PlayerEyeHelper;
using static LuneLib.Utilities.LuneLibUtils;
using CalamityMod.Items.Potions.Alcohol;
using Steamworks;
using System.Reflection;

namespace LuneLib
{
    public partial class LuneLib : Mod
    {
        public static LuneLib instance;
        public static Debug debug;

        public bool CalamityModLoaded;
        public bool InfernumModeLoaded;
        public bool CalValExLoaded;
        public bool CalamitasMommyLoaded;
        public bool ThoriumModLoaded;
        public bool VanillaQoLLoaded;
        public bool SpiritModLoaded;
        public bool StrongerReforgesLoaded;
        public bool BrighterLightLoaded;

        public static CSteamID steamID;
        public override void Load()
        {
            instance = this;

            steamID = SteamUser.GetSteamID();

            CalamityModLoaded = ModLoader.HasMod("CalamityMod");
            InfernumModeLoaded = ModLoader.HasMod("InfernumMode");
            CalValExLoaded = ModLoader.HasMod("CalValEx");
            CalamitasMommyLoaded = ModLoader.HasMod("CalamitasMommy");
            ThoriumModLoaded = ModLoader.HasMod("ThoriumMod");
            VanillaQoLLoaded = ModLoader.HasMod("VanillaQoL");
            SpiritModLoaded = ModLoader.HasMod("SpiritMod");
            StrongerReforgesLoaded = ModLoader.HasMod("StrongerReforges");
            BrighterLightLoaded = ModLoader.HasMod("BrighterLight");

            On_PlayerEyeHelper.SetStateByPlayerInfo += PlayerEyeHelper_SetStateByPlayerInfo;
        }

        public override void Unload()
        {
            instance = null;
            debug = null;
        }

        private void PlayerEyeHelper_SetStateByPlayerInfo(On_PlayerEyeHelper.orig_SetStateByPlayerInfo orig, ref PlayerEyeHelper self, Player player)
        {
            orig(ref self, player);

            if (debug.Eyes == true && LL)
            {
                try
                {
                    if (player.OceanMan())
                    {
                        return;
                    }
                    else
                    {
                        self.SwitchToState(EyeState.IsBlind);
                    }
                }
                catch (Exception e)
                {
                    Logger.Error($"Aw shit here we go again. reflect: {e.Message}");
                }
            }
        }
    }
}
