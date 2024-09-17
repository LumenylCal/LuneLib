using SpiritMod.NPCs.Bloatfish;
using SpiritMod.NPCs.Critters;
using SpiritMod.NPCs.Critters.Ocean;
using SpiritMod.NPCs.ElectricEel;
using SpiritMod.NPCs.Horned_Crustacean;
using SpiritMod.NPCs.Mimic;
using SpiritMod.NPCs.Reach;
using SpiritMod.NPCs.Sea_Mandrake;
using SpiritMod.NPCs.Tides;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace LuneLib.Utilities.Hashsets
{
    [JITWhenModsEnabled("SpiritMod")]
    public static class SpiritSets
    {
        public static readonly HashSet<int> AbyssalProjectiles;

        public static readonly HashSet<int> AbyssalNPCs;

        public static readonly HashSet<int> AquaticBossProjectiles;

        static SpiritSets()
        {
            var isSpiritLoaded = ModLoader.HasMod("SpiritMod");
            if (isSpiritLoaded)
            {

                AbyssalProjectiles = isSpiritLoaded ? CreateSpiritProjSpecificTypes() : new HashSet<int>();

                AbyssalNPCs = isSpiritLoaded ? CreateSpiritNpcSpecificTypes() : new HashSet<int>();

                AquaticBossProjectiles = isSpiritLoaded ? CreateSpiritBossProjSpecificTypes() : new HashSet<int>();

            }
        }

        #region Abyssal Projectiles

        private static HashSet<int> CreateSpiritProjSpecificTypes()
        {
            return new HashSet<int>
                {
                 ModContent.ProjectileType<RyBolt>(),
                 ModContent.ProjectileType<RyTentacle>(),
                 ModContent.ProjectileType<TentacleSquid>(),
                };
        }
        private static HashSet<int> CreateSpiritNpcSpecificTypes()
        {
            return new HashSet<int>
                {
                    ModContent.NPCType<Rylheian>(),
                    ModContent.NPCType<SwollenFish>(),
                    ModContent.NPCType<ElectricEel>(),
                    ModContent.NPCType<Horned_Crustacean>(),
                    ModContent.NPCType<ReaverShark>(),
                    ModContent.NPCType<Swordfish>(),
                    ModContent.NPCType<GildJelly>(),
                    ModContent.NPCType<TinyCrab>(),
                    ModContent.NPCType<RedSnapper>(),
                    ModContent.NPCType<Floater1>(),
                    ModContent.NPCType<Luvdisc>(),
                    ModContent.NPCType<TubeWorm>(),
                    ModContent.NPCType<Gulper>(),
                    ModContent.NPCType<Crinoid>(),
                    ModContent.NPCType<Grouper>(),
                    ModContent.NPCType<Sea_Mandrake>(),
                    ModContent.NPCType<PurpleClubberfish>(),
                    ModContent.NPCType<Rockfish>(),
                    ModContent.NPCType<SawtoothShark>(),
                    ModContent.NPCType<Toxikarp>(),
                    ModContent.NPCType<MangoJelly>(),
                    ModContent.NPCType<Cavefish>(),
                    ModContent.NPCType<AtlanticCod>(),
                    ModContent.NPCType<CrismonTigerfish>(),
                    ModContent.NPCType<GoldenCarp>(),
                    ModContent.NPCType<Noxophyll>(),
                    ModContent.NPCType<SpecularFish>(),
                    ModContent.NPCType<NeonTetra>(),
                    ModContent.NPCType<FrostMinnow>(),
                    ModContent.NPCType<Ebonkoi>(),
                    ModContent.NPCType<Prismite>(),
                    ModContent.NPCType<Lardfish>(),
                    ModContent.NPCType<Damselfish>(),
                    ModContent.NPCType<WoodCrateMimic>(),
                    ModContent.NPCType<IronCrateMimic>(),
                    ModContent.NPCType<GoldCrateMimic>(),
                };
        }
        private static HashSet<int> CreateSpiritBossProjSpecificTypes()
        {
            return new HashSet<int>
                {

                };
        }

        #endregion
    }
}
