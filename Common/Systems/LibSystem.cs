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
            reset1pos = 325;

        private bool
            wasDay = false,
            day6StartTimerDone = false,
            sent = false,
            _flag0 = true,
            _flag1 = true,
            _flag2 = true,
            _flag3 = true,
            _flag4 = true;

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            bool isDay = Main.dayTime;
            if (isDay && !wasDay)
            {
                dayCount++;
                sent = false;
                _flag0 = true;
                _flag1 = true;
                _flag2 = true;
                _flag3 = true;
                _flag4 = true;
                day6StartTimerDone = false;
                reset1pos = 325;
            }

            if (_flag0)
            {
                ResetTimer("timertimer");
                _flag0 = false;
            }
            else if (WaitNamed("timertimer", 3000) && !sent)
            {
                sent = true;
            }

            wasDay = isDay;

            if (dayCount > 6)
            {
                dayCount = 1;
            }

            if (L.whoAmI == Main.myPlayer && LuneLib.clientConfig.Days && !sent && !WaitNamed("timertimer", 3000))
            {
                if (dayCount <= 6)
                {
                    ScreenMessage
                    (
                        Language.GetTextValue($"Mods.LuneLib.Messages.Chat.Isle.Day{dayCount}"),
                        1.5f, 300, 255, 255, 0, 0
                    );
                    if (LuneLib.clientConfig.dayshelptext)
                    {
                        ScreenMessage
                        (
                            Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
                            0.75f, 350, 165, 0, 35, 0
                        );
                    }
                }
            }

            if (dayCount == 6)
            {
                if (_flag1)
                {
                    ResetTimer("day6StartTimer");
                    _flag1 = false;
                }
                if (WaitNamed("day6StartTimer", 5000))
                {
                    if (_flag2)
                    {
                        ResetTimer("reset1Timer");
                        _flag2 = false;
                    }
                    if (!WaitNamed("reset1Timer", 5000))
                    {
                        ScreenMessage
                        (
                            Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset1"),
                            1.5f, reset1pos, 7, 242, 242, 0
                        );
                        day6StartTimerDone = true;
                    }
                }
                if (day6StartTimerDone)
                {
                    if (_flag3)
                    {
                        ResetTimer("reset2StartTimer2");
                        ResetTimer("reset2Timer");
                        _flag3 = false;
                    }
                    if (WaitNamed("reset2StartTimer2", 4300) && !WaitNamed("reset2Timer", 8000))
                    {
                        if (reset1pos < 290)
                            reset1pos = 290;
                        reset1pos--;
                        if (_flag4)
                        {
                            ResetTimer("reset2StartTimer3");
                            _flag4 = false;
                        }
                        if (!WaitNamed("reset2StartTimer3", 5000))
                        {
                            ScreenMessage
                            (
                                Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset2"),
                                1.5f, 325, 7, 242, 242, 0
                            );
                        }
                    }
                }
            }
        }
    }
}