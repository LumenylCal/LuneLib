using Terraria.ModLoader;

namespace LuneLib.Utilities.PressureCheckFolder
{
    public class PoolSys : ModSystem
    {
        public override void PostWorldGen()
        {
            DepthPressureCheck.Pools = Pools.CreatePools();
        }
    }
}
