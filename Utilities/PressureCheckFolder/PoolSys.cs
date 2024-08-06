using Terraria.ModLoader;

namespace LuneWOL.PressureCheckFolder
{
    public class PoolSys : ModSystem
    {
        public override void PostWorldGen()
        {
            DepthPressureCheck.Pools = Pools.CreatePools();
        }
    }
}
