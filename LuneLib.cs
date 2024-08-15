using Terraria.ModLoader;
using Terraria;
using System.Reflection;
using Terraria.GameContent;
using static Terraria.GameContent.PlayerEyeHelper;
using static LuneLib.Utilities.LuneLibUtils;
using System;
using LuneLib.Common.Config;

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

        private MethodInfo _setStateByPlayerInfoMethod;

        public override void Load()
        {
            instance = this;

            CalamityModLoaded = ModLoader.HasMod("CalamityMod");
            InfernumModeLoaded = ModLoader.HasMod("InfernumMode");
            CalValExLoaded = ModLoader.HasMod("CalValEx");
            CalamitasMommyLoaded = ModLoader.HasMod("CalamitasMommy");
            ThoriumModLoaded = ModLoader.HasMod("ThoriumMod");

            // Access private methods using reflection
            _setStateByPlayerInfoMethod = typeof(PlayerEyeHelper).GetMethod("SetStateByPlayerInfo", BindingFlags.NonPublic | BindingFlags.Instance);

            if (_setStateByPlayerInfoMethod == null)
            {
                Logger.Warn("SetStateByPlayerInfo method not found!");
            }

            AddHooks();
        }

        public override void Unload()
        {
            instance = null;
            debug = null;
        }

        private void AddHooks()
        {
            Terraria.GameContent.On_PlayerEyeHelper.SetStateByPlayerInfo += PlayerEyeHelper_SetStateByPlayerInfo;
        }

        private void PlayerEyeHelper_SetStateByPlayerInfo(Terraria.GameContent.On_PlayerEyeHelper.orig_SetStateByPlayerInfo orig, ref PlayerEyeHelper self, Player player)
        {
            // Call the original method
            orig(ref self, player);

            // Modify the eye state if debug.asd is true
            if (debug.asd == true && LTSE)
            {
                try
                {
                    self.SwitchToState(EyeState.IsBlind);
                }
                catch (Exception e)
                {
                    Logger.Error($"Error while switching to eye state: {e.Message}");
                }
            }
        }
    }
}
