using System.Collections.Generic;
using Terraria.ModLoader;

namespace LuneLib.Utilities.Hashsets
{
    [JITWhenModsEnabled("CalamitasMommy")]
    public static class CalMSets
    {
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
