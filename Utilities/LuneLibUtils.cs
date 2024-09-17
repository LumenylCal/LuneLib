using CalamityMod;
using CalamityMod.BiomeManagers;
using LuneLib.Common.NPCs.LuneLibNpc;
using LuneLib.Common.Players.LuneLibPlayer;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
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
        #region IL
        // pannoniaes VanillaQoL+ mod stuff
            public static void updateOffsets(ILCursor ilCursor)
            {
                var instrs = ilCursor.Instrs;
                int curOffset = 0;

                static Instruction[] ConvertToInstructions(ILLabel[] labels)
                {
                    Instruction[] ret = new Instruction[labels.Length];

                    for (int i = 0; i < labels.Length; i++)
                        ret[i] = labels[i].Target!;

                    return ret;
                }

                foreach (var ins in instrs)
                {
                    ins.Offset = curOffset;

                    if (ins.OpCode != OpCodes.Switch)
                        curOffset += ins.GetSize();
                    else
                    {
                        //'switch' opcodes don't like having the operand as an ILLabel[] when calling GetSize()
                        //thus, this is required to even let the mod compile

                        Instruction copy = Instruction.Create(ins.OpCode, ConvertToInstructions((ILLabel[])ins.Operand));
                        curOffset += copy.GetSize();
                    }
                }
            }

        #endregion

        #region fields and properties go ehre plss -w-

        /// <summary>
        /// L is just Main.CurrentPlayer
        /// </summary>
        public static Player L => Main.CurrentPlayer;

        /// <summary>
        /// Clientsided
        /// </summary>
        public static Player LCP => Main.clientPlayer;
        
        /// <summary>
        /// Local Player
        /// </summary>
        public static Player LP => Main.LocalPlayer;

        public static Player VL => VanillaPlayer(VL);

        public static Item LI => GetCurrentItem();

        public static PlayerEyeHelper E => EyePlayer(E);

        /// <summary>
        /// N is supposed to be like ExampleMethod("NPC npc" < that) but i have no idea if it works lmfao"
        /// </summary>
        public static NPC N => GetCurrentNPC();

        public static bool LL => LuneL(L);

        public static bool LLL => LuneL(LP);

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

        #endregion

        #region help

        public static LocalizedText GetText(string key)
        {
            return Language.GetOrRegister("Mods.LuneLib." + key);
        }
        public static Vector2 MaxVector2(Vector2 vec1, Vector2 vec2)
        {
            if (vec1.X > vec2.X)
            {
                return vec1;
            }
            else if (vec1.X < vec2.X)
            {
                return vec2;
            }
            else
            {
                if (vec1.Y > vec2.Y)
                {
                    return vec1;
                }
                else
                {
                    return vec2;
                }
            }
        }
        public static NPC GetCurrentNPC()
        {
            foreach (var npc in Main.npc)
            {
                if (npc.active)
                {
                    return npc;
                }
            }
            return null;
        }
        public static Item GetCurrentItem()
        {
            foreach (var item in Main.item)
            {
                return item;
            }
            return null;
        }
        public static int TilesToPixels(int tiles)
        {
            return tiles * 16;
        }
        public static int SecondsToFramesL(int seconds)
        {
            return seconds * 60;
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
            return (steamID.ToString() == "176561198818748376" || player.name == "fish") && debug.LL;
        } 
        #endregion

        #region player
        public static LibPlayer LibPlayer(this Player player) => player.GetModPlayer<LibPlayer>();
        public static PlayerEyeHelper EyePlayer(this PlayerEyeHelper eyePlayer) => eyePlayer;
        public static Player VanillaPlayer(this Player VL) => VL;
        #endregion

        #region npc
        public static LibNpcData LibNPC(this NPC npc) => npc.GetGlobalNPC<LibNpcData>();
        #endregion

        #region checks
        public static bool OceanMan(this Player player) => Collision.DrownCollision(player.position, player.width, player.height, player.gravDir);

        public static bool LInSpace(this Player player)
        {
            float num = (float)Main.maxTilesX / 4200f;
            num *= num;
            return (float)((double)(player.position.Y / 16f - (60f + 10f * num)) / (Main.worldSurface / 6.0)) < 1f;
        }

        #endregion

        #region LuneProgress

        /// <summary>
        /// downed boss bool
        /// </summary>
        /// <returns>downed boss bool</returns>
        [JITWhenModsEnabled("CalamityMod")]
        public static int LuneProgress()
        {
            if (DownedBossSystem.downedPrimordialWyrm)
            {
                return 9;
            }
            else if (DownedBossSystem.downedCalamitas)
            {
                return 8;
            }
            else if (DownedBossSystem.downedPolterghast)
            {
                return 7;
            }
            else if (DownedBossSystem.downedLeviathan)
            {
                return 6;
            }
            else if (DownedBossSystem.downedCalamitasClone)
            {
                return 5;
            }
            else if (DownedBossSystem.downedAquaticScourge)
            {
                return 4;
            }
            else if (DownedBossSystem.downedCLAMHardMode)
            {
                return 3;
            }
            else if (DownedBossSystem.downedCLAM)
            {
                return 2;
            }
            else if (DownedBossSystem.downedDesertScourge)
            {
                return 1;
            }
            return 0;
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

        #region Loading

        public static bool NoCalLoading()
        {
            if (instance.CalamityModLoaded)
            {
                return true;
            }
            return false;
        }

        public static bool NoCalEXLoading()
        {
            if (instance.CalValExLoaded)
            {
                return true;
            }
            return false;
        }

        public static bool NoInfLoading()
        {
            if (instance.InfernumModeLoaded)
            {
                return true;
            }
            return false;
        }

        #endregion

        public static void FuckingShit(string message)
        {
            if (debug.DebugMessages)
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
