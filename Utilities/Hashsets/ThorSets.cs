using System.Collections.Generic;

using Terraria.ModLoader;
using ThoriumMod.NPCs.BossForgottenOne;
using ThoriumMod.NPCs.BossQueenJellyfish;
using ThoriumMod.NPCs.Depths;
using ThoriumMod.Projectiles;
using ThoriumMod.Projectiles.Boss;
using ThoriumMod.Projectiles.Enemy;
using ThoriumMod.Tiles;
using ThoriumMod.Walls;

namespace LuneLib.Utilities.Hashsets
{
    [JITWhenModsEnabled("ThoriumMod")]
    public class ThorSets
    {
        public static readonly HashSet<int> AbyssalProjectiles;

        public static readonly HashSet<int> AbyssalNPCs;

        public static readonly HashSet<int> AquaticBossProjectiles;

        public static readonly HashSet<int> AquaticBosses;

        public static readonly HashSet<int> IsAquaticTile;

        public static readonly HashSet<int> IsAquaticWall;

        static ThorSets()
        {

            var isThorLoaded = ModLoader.HasMod("ThoriumMod");

            AbyssalProjectiles = isThorLoaded ? CreateThorProjSpecificTypes() : new HashSet<int>();

            AbyssalNPCs = isThorLoaded ? CreateThorNpcSpecificTypes() : new HashSet<int>();

            AquaticBossProjectiles = isThorLoaded ? CreateThorBossProjSpecificTypes() : new HashSet<int>();

            AquaticBosses = isThorLoaded ? CreateThorBossSpecificTypes() : new HashSet<int>();

            IsAquaticTile = isThorLoaded ? CreateThorTileSpecificTypes() : new HashSet<int>();

            IsAquaticWall = isThorLoaded ? CreateThorWallSpecificTypes() : new HashSet<int>();

        }

        #region Abyssal Projectiles

        private static HashSet<int> CreateThorProjSpecificTypes()
        {
        return new HashSet<int>
        {
            #region Ocean Proj

                ModContent.ProjectileType<BubblePulse>(),

                #endregion

                #region Aquatic depths

                    ModContent.ProjectileType<BlowfishStinger>(),
                    ModContent.ProjectileType<HostilePearl>(),
                    ModContent.ProjectileType<OctopusArm>(),
                    ModContent.ProjectileType<KrakenArm>(),
                    ModContent.ProjectileType<SerpentSpit>(),

                #endregion
            };
        }

        #endregion

        #region Abyssal Npcs

        private static HashSet<int> CreateThorNpcSpecificTypes()
        {
        return new HashSet<int>
            {

                #region Ocean npcs

                    ModContent.NPCType<ZealousJellyfish>(),
                    ModContent.NPCType<DistractingJellyfish>(),
                    ModContent.NPCType<SpittingJellyfish>(),

                #endregion // should out to protohog for helping me for adding 4 names 

                #region aquatic depths

                    #region prehardmode // should out to protohog for helping me for adding 4 names 

                        ModContent.NPCType<ManofWar>(),
                        ModContent.NPCType<Barracuda>(),
                        ModContent.NPCType<Sharptooth>(),
                        ModContent.NPCType<Blowfish>(),
                        ModContent.NPCType<Hammerhead>(),
                        ModContent.NPCType<GigaClam>(),
                        ModContent.NPCType<Octopus>(),
                        ModContent.NPCType<Globee>(),
                        ModContent.NPCType<MorayBody>(),
                        ModContent.NPCType<MorayHead>(),
                        ModContent.NPCType<MorayTail>(),

                    #endregion 

                    #region hardmode

                        ModContent.NPCType<FeedingFrenzy>(),
                        ModContent.NPCType<FeedingFrenzy2>(),
                        ModContent.NPCType<VampireSquid>(),
                        ModContent.NPCType<CrownofThorns>(),
                        ModContent.NPCType<Kraken>(),
                        ModContent.NPCType<Blobfish>(),
                        ModContent.NPCType<PutridSerpent>(),
                        ModContent.NPCType<AbyssalAngler>(),
                        ModContent.NPCType<AbyssalAngler2>(),
                        ModContent.NPCType<VoltEelBody>(),
                        ModContent.NPCType<VoltEelBody1>(),
                        ModContent.NPCType<VoltEelBody2>(),
                        ModContent.NPCType<VoltEelHead>(),
                        ModContent.NPCType<VoltEelTail>(),
                        ModContent.NPCType<Whale>(),
                        ModContent.NPCType<SubmergedMimic>(),

                        ModContent.NPCType<AquaticHallucination>(),
                        ModContent.NPCType<AbyssalSpawn>(),

                    #endregion

                    #region critter

                        ModContent.NPCType<DumboOctopus>(),
                        ModContent.NPCType<DumboOctopusBase>(),
                        ModContent.NPCType<PurpleDumboOctopus>(),
                        ModContent.NPCType<GoldDumboOctopus>(),
                        ModContent.NPCType<Lobster>(),
                        ModContent.NPCType<BlueLobster>(),
                        ModContent.NPCType<GoldLobster>(),
                        ModContent.NPCType<GiantIsopod>(),

                    #endregion

                #endregion

            };
        }

        #endregion

        #region Aquatic Boss Projectiles

        private static HashSet<int> CreateThorBossProjSpecificTypes()
        {
        return new HashSet<int>
            {
                #region Ocean Proj

                    ModContent.ProjectileType<BubbleBomb>(),
                    ModContent.ProjectileType<QueenTorrent>(),
                    ModContent.ProjectileType<QueenJellyfishArm>(),

                #endregion

                #region Aquatic depths

                    ModContent.ProjectileType<Whirlpool>(),
                    ModContent.ProjectileType<ForgottenOneSpit>(),
                    ModContent.ProjectileType<ForgottenOneSpit2>(),
                    ModContent.ProjectileType<AquaRipple>(),
                    ModContent.ProjectileType<AbyssalStrike>(),
                    ModContent.ProjectileType<AbyssalStrike2>(),
                    ModContent.ProjectileType<OldGodSpit>(),
                    ModContent.ProjectileType<OldGodSpit2>(),

                #endregion
            };
        }

        #endregion

        #region Aquatic Bosses

        private static HashSet<int> CreateThorBossSpecificTypes()
        {
        return new HashSet<int>
            {
                ModContent.NPCType<QueenJellyfish>(),
                ModContent.NPCType<ForgottenOne>(),
                ModContent.NPCType<ForgottenOneCracked>(),
                ModContent.NPCType<ForgottenOneReleased>(),
            };
        }

        #endregion

        #region Is Aquatic Tile

        private static HashSet<int> CreateThorTileSpecificTypes()
        {
        return new HashSet<int>
            {

                ModContent.TileType<GlowingMarineBlock>(),
                ModContent.TileType<LeakyMarineBlock>(),
                ModContent.TileType<LeakyMossyMarineBlock>(),
                ModContent.TileType<MossyMarineBlock>(),
                ModContent.TileType<RefinedMarineBlock>(),
                ModContent.TileType<BrackishClumpTile>(),
                ModContent.TileType<Aquamarine>(),
                ModContent.TileType<Aquaite>(),
                ModContent.TileType<DepthChestTile>(),
                ModContent.TileType<SynthGold>(),
                ModContent.TileType<SynthPlatinum>(),

                ModContent.TileType<DepthsAmethyst>(),
                ModContent.TileType<DepthsTopaz>(),
                ModContent.TileType<DepthsOpal>(),
                ModContent.TileType<DepthsAquamarine>(),
                ModContent.TileType<DepthsSapphire>(),
                ModContent.TileType<DepthsEmerald>(),
                ModContent.TileType<DepthsRuby>(),
                ModContent.TileType<DepthsDiamond>(),
                ModContent.TileType<DepthsAmber>(),
            };
        }

        #endregion

        #region Is Aquatic Wall

        private static HashSet<int> CreateThorWallSpecificTypes()
        {
        return new HashSet<int>
            {

                ModContent.WallType<MarineWall>(),
                ModContent.WallType<MarineWall2>(),
                ModContent.WallType<MarineWallDry>(),
                ModContent.WallType<RefinedMarineWall>(),
                ModContent.WallType<SeaScaleWall>(),

            };
        }

        #endregion

    }
}