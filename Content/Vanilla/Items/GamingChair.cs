using ClickerClassExpansion.Content.Vanilla.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClassExpansion.Content.Vanilla.Items
{
    public class GamingChair : TextureFallbackItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaming Chair");
            Tooltip.SetDefault("A strangely-stained chair" +
                               "\n'Throne of lies...'");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 30;

            item.maxStack = 99;

            item.useTurn = item.autoReuse = true;
            item.useTime = item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.consumable = true;
            
            item.createTile = ModContent.TileType<GamingChairTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.SoulofSight, 2);
            recipe.AddIngredient(ItemID.SoulofMight, 2);
            recipe.AddIngredient(ItemID.SoulofFright, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
