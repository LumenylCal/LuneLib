using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Systems
{
    public class LibSystem : GlobalItem
    {
        public override void SetDefaults(Item entity)
        {
            if (entity.type == ItemID.BottomlessBucket && LTSE)
            {
                entity.useTime = 1;
                entity.useAnimation = 1;
            }
        }
    }

    public class LLibSystem : ModSystem
    {
        private int dayCount = 0;

        private bool wasDay = false;

        public override void PostUpdateEverything()
        {
            bool isDay = Main.dayTime;

            if (isDay && !wasDay)
            {
                dayCount++;
            }

            wasDay = isDay;

            if (dayCount >= 6 && L.whoAmI == Main.myPlayer)
            {
                ResetSimulation();

                dayCount = 0;
            }
        }

        private async void ResetSimulation()
        {
            Main.NewText(Language.GetTextValue("Mods.LuneLib.Messages.Chat.TheReset1"), 7, 242 , 242);

            await Task.Delay(5000);

            Main.NewText(Language.GetTextValue("Mods.LuneLib.Messages.Chat.TheReset2"), 7, 242, 242);
        }
    }
}
