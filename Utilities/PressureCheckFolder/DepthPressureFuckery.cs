//using Terraria;
//using Terraria.ModLoader;

//namespace LuneLib.Utilities.PressureCheckFolder
//{
//    public class DepthPressureFuckery : ModPlayer
//    {
//        public override void PostUpdate()
//        {
//            DepthPressureCheck depthPressureCheck = Player.GetModPlayer<DepthPressureCheck>();

//            if (depthPressureCheck.IsDrowning)
//            {
//                float depthDifference = Player.position.Y - depthPressureCheck.EntryPoint.Y;

//                float additionalBreathLoss = depthDifference / 1000f;

//                Player.breath -= (int)additionalBreathLoss;

//                if (Player.breath < 0)
//                {
//                    Player.breath = 0;
//                }
//            }
//        }
//    }
//}
