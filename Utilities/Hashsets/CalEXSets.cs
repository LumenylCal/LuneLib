using CalValEX.NPCs.Critters;
using System;
using System.Collections.Generic;

using Terraria.ModLoader;

namespace LuneLib.Utilities.Hashsets
{
    [JITWhenModsEnabled("CalValEX")]
    public static class CalEXSets
    {

        //public static void load()
        //{
        //    try
        //    {
        //        if (LuneLib.instance.CalValExLoaded)
        //        {
        //            load();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        LuneLib.instance.Logger.Error($"Couldn't load CalValEX HashSets! Error message: {e}");
        //    }
        //}


        #region Abyssal Npcs

        public static readonly HashSet<int> AbyssalNPCs;

        static CalEXSets()
        {
            var isCalValExLoaded = ModLoader.HasMod("CalValEX");
            AbyssalNPCs = isCalValExLoaded ? CreateCalValExNpcSpecificTypes() : new HashSet<int>();
        }

        private static HashSet<int> CreateCalValExNpcSpecificTypes()
        {
            return new HashSet<int>
            {
                #region CalValEX Mod NPCs

                    #region Sulphurous Sea NPCs

                        //acid rain specific
                        ModContent.NPCType<Vaporofly>(),
                        ModContent.NPCType<Orthobab>(),

                    #endregion

                    #region Layer4

                        ModContent.NPCType<Isopod>(),

                    #endregion

                #endregion
            };
        }

        #endregion
    }
}