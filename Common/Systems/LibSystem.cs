using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Systems
{
    public class LLibSystem : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneLib.clientConfig.Days;
        }
        private int
            dayCount = 0,
            timertimer = 0,
            day6StartTimer = 0,
            reset1Timer = 0,
            reset2StartTimer = 0,
            reset2Timer = 0;

        private bool
            wasDay = false,
            day6StartTimerDone = false,
            sent = false;


        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            bool isDay = Main.dayTime;

            if (isDay && !wasDay)
            {
                dayCount++;
                sent = false;
                day6StartTimerDone = false;
                timertimer = 0;
                day6StartTimer = 0;
                reset1Timer = 0;
                reset2StartTimer = 0;
                reset2Timer = 0;
            }

            wasDay = isDay;

            if (dayCount > 6)
            {
                dayCount = 1;
            }

            if (timertimer <= 180 && !sent)
            {
                timertimer++;
            }
            else if (sent && isDay && !wasDay)
            {
                timertimer = 0;
            }
            if (timertimer > 180)
            {
                sent = true;
            }

            if (L.whoAmI == Main.myPlayer && LuneLib.clientConfig.Days && !sent && timertimer <= 180)
            {
                if (dayCount <= 6)
                {
                    ScreenMessage
                    (
                        Language.GetTextValue($"Mods.LuneLib.Messages.Chat.Isle.Day{dayCount}"),
                        1.5f, 300, 255, 255, 0, 0
                    );
                    ScreenMessage
                    (
                        Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
                        0.75f, 350, 165, 0, 35, 0
                    );
                }
            }

            if (dayCount == 6)
            {
                if (day6StartTimer < 300)
                {
                    day6StartTimer++;
                }
                else if (reset1Timer < 480)
                {
                    ScreenMessage
                    (
                        Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset1"),
                        1.5f, 325, 7, 242, 242, 0
                    );
                    reset1Timer++;
                    day6StartTimerDone = true;
                }

                if (day6StartTimerDone && reset2StartTimer < 300)
                {
                    reset2StartTimer++;
                }

                if (reset2StartTimer >= 300 && reset2Timer <= 480)
                {
                    ScreenMessage
                    (
                        Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset2"),
                        1.5f, 360, 7, 242, 242, 0
                    );
                    reset2Timer++;
                }
            }
        }
    }

}