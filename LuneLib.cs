using LuneLib.Common.Buffs;
using LuneLib.Common.Config;
using Steamworks;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using static LuneLib.Utilities.LuneLibUtils;
using static Terraria.GameContent.PlayerEyeHelper;

namespace LuneLib
{
    public partial class LuneLib : Mod
    {
        public static LuneLib instance;
        public static Debug debug;
        public static Client clientConfig;

        public bool CalamityModLoaded;
        public bool InfernumModeLoaded;
        public bool CalValExLoaded;
        public bool CalamitasMommyLoaded;
        public bool ThoriumModLoaded;
        public bool VanillaQoLLoaded;
        public bool SpiritModLoaded;
        public bool StrongerReforgesLoaded;
        public bool BrighterLightLoaded;
        public bool CoyoteframesLoaded;
        public bool DarkSurfaceLoaded;

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
            CoyoteframesLoaded = ModLoader.HasMod("Coyoteframes");
            DarkSurfaceLoaded = ModLoader.HasMod("DarkSurface");

            On_PlayerEyeHelper.SetStateByPlayerInfo += PlayerEyeHelper_SetStateByPlayerInfo;
        }

        public override void Unload()
        {
            instance = null;
            debug = null;
            clientConfig = null;
        }

        private void PlayerEyeHelper_SetStateByPlayerInfo(On_PlayerEyeHelper.orig_SetStateByPlayerInfo orig, ref PlayerEyeHelper self, Player player)
        {
            orig(ref self, player);

            if (debug.LL && player.HasBuff<Lune>())
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
