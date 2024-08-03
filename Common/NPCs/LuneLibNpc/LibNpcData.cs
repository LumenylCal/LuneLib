using Terraria;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.NPCs.LuneLibNpc
{
    public class LibNpcData : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        #region all my mods debuffs

            #region Lunes Worse of Life

                public int BoilFreeze = 0;

            #endregion

            #region Calamitas Mommy (Lunes Shitty Mod) this mod is currently private... its just changes id like to my game

                public int LcDepth = 0;
                public int damageCooldown = 0;

        #endregion

        #endregion

        public override void PostAI(NPC npc)
        {
            if (BoilFreeze > 0)
                BoilFreeze--;
            
            if (LcDepth > 0)
                LcDepth--;
        }
    }
}
