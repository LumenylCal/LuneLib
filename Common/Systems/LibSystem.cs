using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;
using Microsoft.Extensions.Options;
using static Terraria.GameContent.PlayerEyeHelper;

namespace LuneLib.Common.Systems
{
    public class LibSystem : ModSystem
    {
        #region make myself not see shit

        //public override void PostUpdateTime()
        //{
        //    UpdateGlobalBrightness();
        //}

        //public override void PostDrawTiles()
        //{
        //    UpdateGlobalBrightness();        
        //}

        //private static void UpdateGlobalBrightness()
        //    {
        //        if (LTSE && Main.player[Main.myPlayer].blind)
        //        {
        //            Lighting.GlobalBrightness = 1.2f;
        //        }
        //    }

        #endregion

    }
}
