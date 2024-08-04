using CalamityMod.Items.Weapons.Melee;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuneLib.Content
{
    public class ProtohogItem : ModItem
    {
        public override string Texture => "LuneLib/Assets/Images/PlaceHolder";

        public override void SetDefaults()
        {
            Item.damage = int.MaxValue;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 1;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<CosmicShiv>(2).
                AddIngredient(ItemID.Swordfish, 1).
                AddTile(TileID.WorkBenches);
                Register();
        }
    }
}