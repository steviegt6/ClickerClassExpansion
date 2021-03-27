using ClickerClassExpansion.Common.Compatibility;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClassExpansion.Content.Vanilla.Items
{
    public abstract class GemClickerItem : ModdedClickerItem
    {

        public abstract int DamageIncrease { get; }

        public abstract float RadiusIncrease { get; }

        public abstract int GemItem { get; }

        public abstract int DustType { get; }

        public abstract Color GemColor { get; }

        public override void SafeSetDefaults()
        {
            ClickerCompatibilityCalls.SetRadius(item, 1f + RadiusIncrease);
            ClickerCompatibilityCalls.SetColor(item, GemColor);
            ClickerCompatibilityCalls.SetDust(item, DustType);
            ClickerCompatibilityCalls.AddEffect(item, "ClickerClass:DoubleClick");

            item.damage = 5 + DamageIncrease;
            item.knockBack = 1.25f;
            item.rare = ItemRarityID.White;

            Item gem = new Item();
            gem.SetDefaults(GemItem, true);
            item.value = gem.value * 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(GemItem, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
