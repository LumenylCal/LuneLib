using Terraria;
using Terraria.ModLoader;

namespace LuneLib.Utilities.PressureCheckFolder
{
    public class PoolSys : ModSystem
    {
        public override void OnModLoad()
        {
            WorldGen.Hooks.OnWorldLoad += () =>
            {
                DepthPressureCheck.Pools = Pools.CreatePools();
            };
        }
    }
}
