namespace LuneLib.Utilities.Hashsets
{
    public static class HashSets
    {

        #region HashSet Contains Type {?}

            #region HashSetContainsAbyssProj

                public static bool HashSetContainsAbyssProj(int type) =>
                    ContainsInfAbyssProj(type) || ContainsCalAbyssProj(type) || ContainsVanAbyssProj(type) || ContainsThorAbyssProj(type);

                public static bool ContainsInfAbyssProj(int type) => 
                    LuneLib.instance.InfernumModeLoaded && InfSets.AbyssalProjectiles.Contains(type);
                public static bool ContainsCalAbyssProj(int type) =>
                    LuneLib.instance.CalamityModLoaded && CalSets.AbyssalProjectiles.Contains(type);
                public static bool ContainsThorAbyssProj(int type) =>
                    LuneLib.instance.ThoriumModLoaded && ThorSets.AbyssalProjectiles.Contains(type);
                public static bool ContainsVanAbyssProj(int type) =>
                    VanillaSets.AbyssalProjectiles.Contains(type);

            #endregion

            #region HashSetContainsAbyssalPredator

                public static bool HashSetContainsAbyssalPredator(int type) =>
                    ContainsCalAbyssalPredator(type) || ContainsInfAbyssalPredator(type) || ContainsCalExAbyssalPredator(type) || ContainsVanAbyssalPredator(type) || ContainsThorExAbyssalPredator(type);

                public static bool ContainsCalAbyssalPredator(int type) =>
                    LuneLib.instance.CalamityModLoaded && CalSets.AbyssalNPCs.Contains(type);
                public static bool ContainsInfAbyssalPredator(int type) =>
                    LuneLib.instance.InfernumModeLoaded && InfSets.AbyssalNPCs.Contains(type);
                public static bool ContainsCalExAbyssalPredator(int type) =>
                    LuneLib.instance.CalValExLoaded &&  CalEXSets.AbyssalNPCs.Contains(type);
                public static bool ContainsThorExAbyssalPredator(int type) =>
                    LuneLib.instance.ThoriumModLoaded && ThorSets.AbyssalNPCs.Contains(type);
                public static bool ContainsVanAbyssalPredator(int type) =>
                    VanillaSets.AbyssalNPCs.Contains(type);

            #endregion

            #region HashSetContainsAquaticBossProjectile

                public static bool HashSetContainsAquaticBossProjectile(int type) =>
                    ContainsCalAquaticBossProjectile(type) || ContainsInfAquaticBossProjectile(type) || ContainsThorAquaticBossProjectile(type);

                public static bool ContainsCalAquaticBossProjectile(int type) =>
                    LuneLib.instance.CalamityModLoaded && CalSets.AquaticBossProjectiles.Contains(type);
                public static bool ContainsInfAquaticBossProjectile(int type) =>
                    LuneLib.instance.InfernumModeLoaded && InfSets.AquaticBossProjectiles.Contains(type);
                public static bool ContainsThorAquaticBossProjectile(int type) =>
                    LuneLib.instance.ThoriumModLoaded && ThorSets.AquaticBossProjectiles.Contains(type);

        #endregion

            #region HashSetContainsAquaticBoss

                public static bool HashSetContainsAquaticBoss(int type) =>
                    ContainsCalAquaticBoss(type) || ContainsInfAquaticBossProjectile(type) || ContainsVanAquaticBoss(type) || ContainsThorAquaticBoss(type);

                public static bool ContainsCalAquaticBoss(int type) =>
                    LuneLib.instance.CalamityModLoaded && CalSets.AquaticBosses.Contains(type);
                public static bool ContainsThorAquaticBoss(int type) =>
                    LuneLib.instance.ThoriumModLoaded && ThorSets.AquaticBosses.Contains(type);
                public static bool ContainsVanAquaticBoss(int type) =>
                    VanillaSets.AquaticBosses.Contains(type);

        #endregion

            #region HashSetContainsAquaticTile

            public static bool HashSetContainsAquaticTile(int type) =>
                ContainsCalAquaticTile(type) || ContainsCalMAquaticTile(type) || ContainsThorAquaticTile(type);

            public static bool ContainsCalAquaticTile(int type) =>
                LuneLib.instance.CalamityModLoaded && CalSets.IsAquaticTile.Contains(type);
            public static bool ContainsCalMAquaticTile(int type) =>
                LuneLib.instance.CalamitasMommyLoaded && CalMSets.IsAquaticTile.Contains(type);
            public static bool ContainsThorAquaticTile(int type) =>
                LuneLib.instance.ThoriumModLoaded && ThorSets.IsAquaticTile.Contains(type);

        #endregion

            #region HashSetContainsCalAquaticWall

                public static bool HashSetContainsCalAquaticWall(int type) =>
                    ContainsCalAquaticWall(type) || ContainsThorAquaticWall(type);

                public static bool ContainsCalAquaticWall(int type) =>
                    LuneLib.instance.CalamityModLoaded && CalSets.IsAquaticWall.Contains(type);
                public static bool ContainsThorAquaticWall(int type) =>
                    LuneLib.instance.ThoriumModLoaded && ThorSets.IsAquaticWall.Contains(type);

            #endregion

        #endregion

    }
}