using ClickerClassExpansion.Common.Compatibility;
using Microsoft.Xna.Framework;
using Terraria;

namespace ClickerClassExpansion.Content
{
    public abstract class ModdedClickerItem : TextureFallbackItem
    {
        public virtual ModCompatibility ModDependency => null;

        public sealed override void SetStaticDefaults()
        {
            ClickerCompatibilityCalls.RegisterClickerWeapon(this);
            SafeSetStaticDefaults();
        }

        public sealed override void SetDefaults()
        {
            ClickerCompatibilityCalls.SetClickerWeaponDefaults(item);
            item.Size = new Vector2(30);

            SafeSetDefaults();
        }

        /// <summary>
        /// This is where you set all your item's static properties, such as names/translations and arrays in ItemID.Sets. This is called after SetDefaults on the initial ModItem.
        /// </summary>
        public virtual void SafeSetStaticDefaults()
        {
        }

        /// <summary>
        /// This is where you set all your item's properties, such as width, damage, shootSpeed, defense, etc. For those that are familiar with tAPI, this has the same function as .json files.
        /// </summary>
        public virtual void SafeSetDefaults()
        {
        }
    }
}