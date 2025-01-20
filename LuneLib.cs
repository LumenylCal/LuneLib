using LuneLib.Common.Config;
using LuneLib.Common.Players.LuneLibPlayer;
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

        public bool
            CalamityModLoaded,
            InfernumModeLoaded,
            CalValExLoaded,
            CalamitasMommyLoaded,
            ThoriumModLoaded, 
            VanillaQoLLoaded,
            SpiritModLoaded,
            StrongerReforgesLoaded,
            BrighterLightLoaded,
            CoyoteframesLoaded,
            ChatSourceLoaded,
            DarkSurfaceLoaded;

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
            ChatSourceLoaded = ModLoader.HasMod("ChatSource");
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

            if (debug.LL && player.GetModPlayer<LibPlayer>().IsLune)
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
                    Logger.Error($"(Tell Lune. She needs the message (if shes alive)) Aw shit here we go again. error_ref: {e.Message}");
                }
            }
        }
    }
}
