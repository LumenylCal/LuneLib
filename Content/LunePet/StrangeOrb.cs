﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Content.LunePet
{
    public class LOrb : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneLib.debug.DI;
        }
        public override string Texture => "LuneLib/Assets/Images/LPet/LPetOrb";

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WispinaBottle);
            Item.shoot = ModContent.ProjectileType<LPet>();
            Item.buffType = ModContent.BuffType<LPetBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

        public override void AddRecipes()
        {
            Recipe.Create(Type).
                AddIngredient(ItemID.WhitePearl).
                Register();
        }
    }
}