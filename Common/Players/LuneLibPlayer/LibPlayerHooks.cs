using LuneLib.Utilities;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Events;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;

using static LuneLib.Utilities.LuneLibUtils;
using LuneLib.Content;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public partial class LibPlayer : ModPlayer
    {
        public override void PreUpdateBuffs()
        {
            if (LTSE)
            {
                Player.AddBuff(ModContent.BuffType<Lune>(), 15);
            }
        }

        #region LuneHeadCovered

        public override void PostUpdate()
        {
            float value = 0f;
            float amount = 0.1f;
            if (Player.LibPlayer().LStormEyeCovered && Player.whoAmI == Main.myPlayer)
            {
                value = 0.8f;
                amount = 0.1f;
            }
            else if (Player.LibPlayer().LNightEyes && Player.whoAmI == Main.myPlayer)
            {
                value = 0.7f;
                amount = 0.1f;
            }
            ScreenObstruction.screenObstruction = MathHelper.Lerp(ScreenObstruction.screenObstruction, value, amount);
        }

        #endregion
    }
}
