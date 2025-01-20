using CalamityMod;
using CalamityMod.BiomeManagers;
using LuneLib.Common.NPCs.LuneLibNpc;
using LuneLib.Common.Players.LuneLibPlayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;

using static LuneLib.LuneLib;

namespace LuneLib.Utilities
{
    public static class LuneLibUtils
    {
        #region fields and properties go ehre plss -w-

        /// <summary>
        /// L is just Main.CurrentPlayer
        /// </summary>
        public static Player L => Main.CurrentPlayer;

        /// <summary>
        /// Local Player
        /// </summary>
        public static Player LP => Main.LocalPlayer;

        /// <summary>
        /// Checks if it's my SteamID
        /// </summary>
        public static bool LL => LuneL(L);
        public static bool LE => LuneE(L);

        public static bool ZoneOcean => L.ZoneBeach;

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneSunkenSea => L.InModBiome(ModContent.GetInstance<SunkenSeaBiome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneSulphur => L.InModBiome(ModContent.GetInstance<SulphurousSeaBiome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyssLayer1 => L.InModBiome(ModContent.GetInstance<AbyssLayer1Biome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyssLayer2 => L.InModBiome(ModContent.GetInstance<AbyssLayer2Biome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyssLayer3 => L.InModBiome(ModContent.GetInstance<AbyssLayer3Biome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyssLayer4 => L.InModBiome(ModContent.GetInstance<AbyssLayer4Biome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyss => ZoneAbyssLayer1 || ZoneAbyssLayer2 || ZoneAbyssLayer3 || ZoneAbyssLayer4;

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAquatic => ZoneSulphur || ZoneOcean || ZoneSunkenSea;

        private static Texture2D messageBackground;
        #endregion

        #region help

        private static void MessageBackground()
        {
            if (messageBackground == null)
            {
                messageBackground = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
                messageBackground.SetData(new[] { Color.White });
            }
        }

        /// <summary>
        /// Shows a message on your screen.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="textSize"></param>
        /// <param name="textHeight"></param>
        /// <param name="textR"></param>
        /// <param name="textG"></param>
        /// <param name="textB"></param>
        /// <param name="bgA"></param>
        /// <param name="bgR"></param>
        /// <param name="bgG"></param>
        /// <param name="bgB"></param>
        public static void ScreenMessage(string input, float textSize, int textHeight, int textR = 0, int textG = 0, int textB = 0, int bgA = 255, int bgR = 0, int bgG = 0, int bgB = 0)
        {
            MessageBackground();

            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);

            Color textColor = new(textR, textG, textB);
            Color backgroundColor = new(bgR, bgG, bgB, bgA);

            DynamicSpriteFont font = FontAssets.MouseText.Value;
            Vector2 textPosition = new(Main.screenWidth / 2, Main.screenHeight / 2 + textHeight);
            Vector2 stringSize = font.MeasureString(input) * textSize;
            textPosition.X -= stringSize.X / 2;

            if (bgA != 0)
            {
                Rectangle backgroundRectangle = new(0, 0, Main.screenWidth + 32, Main.screenHeight + 32);
                Main.spriteBatch.Draw(messageBackground, backgroundRectangle, backgroundColor);
            }

            Main.spriteBatch.DrawString(font, input, textPosition, textColor, 0f, Vector2.Zero, textSize, SpriteEffects.None, 0f);
            Main.spriteBatch.End();
        }

        public static LocalizedText GetText(string key)
        {
            return Language.GetOrRegister($"Mods.LuneLib.{key}");
        }

        #endregion

        #region LL
        /// <summary>
        /// Checks if it's my SteamID
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool LuneL(this Player player)
        {
            if (steamID.ToString() == "76561198818748376" && debug.LL && player.whoAmI == Main.myPlayer && !debug.TestMode)
                return true;
            else if (player.name == "fish" && debug.LL && player.whoAmI == Main.myPlayer && debug.TestMode)
                return true;
            return false;
        }
        #endregion

        #region LE
        /// <summary>
        /// Checks if it's a past artists SteamID
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool LuneE(this Player player) => steamID.ToString() == "76561198348118589" && debug.LL && player.whoAmI == Main.myPlayer;
        #endregion

        #region player
        public static LibPlayer LibPlayer(this Player player) => player.GetModPlayer<LibPlayer>();
        #endregion

        #region npc
        public static LibNpcData LibNPC(this NPC npc) => npc.GetGlobalNPC<LibNpcData>();
        #endregion

        #region checks
        public static bool OceanMan(this Player player) => Collision.DrownCollision(player.position, player.width, player.height, player.gravDir);

        #endregion
        public static float ToPercentage(float value)
        {
            if (value < 0f) value = 0f;
            if (value > 100f) value = 100f;
            return value / 100f;
        }

        #region LuneProgress

        /// <summary>
        /// downed boss bool
        /// </summary>
        /// <returns>downed boss bool</returns>
        [JITWhenModsEnabled("CalamityMod")]
        public static int LuneProgress()
        {
            int progress = 
            DownedBossSystem.downedPrimordialWyrm ? 9 :
            DownedBossSystem.downedCalamitas ? 8 :
            DownedBossSystem.downedPolterghast ? 7 :
            DownedBossSystem.downedLeviathan ? 6 :
            DownedBossSystem.downedCalamitasClone ? 5 :
            DownedBossSystem.downedAquaticScourge ? 4 :
            DownedBossSystem.downedCLAMHardMode ? 3 :
            DownedBossSystem.downedCLAM ? 2 :
            DownedBossSystem.downedDesertScourge ? 1 : 0;
            return progress;
        }


        /// <summary>
        /// dry worm Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C1 => LuneProgress() == 1;

        /// <summary>
        /// big Clam Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C2 => LuneProgress() == 2;

        /// <summary>
        /// big Clam but harder Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C3 => LuneProgress() == 3;

        /// <summary>
        /// wet worm Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C4 => LuneProgress() == 4;

        /// <summary>
        /// Fake Mommy Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C5 => LuneProgress() == 5;

        /// <summary>
        /// Levi And Fish Waifu Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C6 => LuneProgress() == 6;

        /// <summary>
        ///  PolterGhast Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C7 => LuneProgress() == 7;

        /// <summary>
        /// Mommy Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C8 => LuneProgress() == 8;

        /// <summary>
        /// Adult Eidolon Wyrm Defeat
        /// </summary>
        [JITWhenModsEnabled("CalamityMod")]
        public static bool C9 => LuneProgress() == 9;


        #endregion

        public static void FuckingShit(string message)
        {
            if (clientConfig.DebugMessages)
            {
                string header = "LuneLib: ";
                if (Main.dedServ)
                {
                    Console.WriteLine(header + message);
                }
                else
                {
                    if (Main.gameMenu)
                    {
                        instance.Logger.Debug(header + Main.myPlayer + ": " + message);
                    }
                    else
                    {
                        Main.NewText(header + message);
                    }
                }
            }
        }
    }
}
