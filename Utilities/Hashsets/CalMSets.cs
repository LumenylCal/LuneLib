using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace LuneLib.Utilities.Hashsets
{
    [JITWhenModsEnabled("CalamitasMommy")]
    public static class CalMSets
    {

        //public static void load()
        //{
        //    try
        //    {
        //        if (LuneLib.instance.CalamitasMommyLoaded)
        //        {
        //            load();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        LuneLib.instance.Logger.Error(
        //            $"Couldn't load CalM HashSets! Error message: {e}");
        //    }
        //}

        private static int tenebrisTileID;

        public static readonly HashSet<int> IsAquaticTile;
        static CalMSets()
        {

            var isCalMLoaded = ModLoader.HasMod("CalamitasMommy");
            IsAquaticTile = isCalMLoaded ? CreateCalMTileSpecificTypes() : new HashSet<int>();

            if (ModLoader.TryGetMod("CalamitasMommy", out Mod calamitasmommy))
            {
                tenebrisTileID = calamitasmommy.Find<ModTile>("TenebrisTile").Type;
            }
        }

        private static HashSet<int> CreateCalMTileSpecificTypes()
        {
            return new HashSet<int>
            {

                tenebrisTileID,

            };
        }

    }
}
