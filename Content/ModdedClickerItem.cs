using ClickerClassExpansion.Common.Compatibility;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ClickerClassExpansion.Content
{
    public abstract class ModdedClickerItem : ModItem
    {
        // If no image for our item is found, use Clicker Class' The Clicker item.
        public override string Texture
        {
            get
            {
                if (ModContent.TextureExists(base.Texture))
                    return base.Texture;

                mod.Logger.Warn($"Item image for {Name} ({base.Texture}) not found! Falling back to ClickerClass' \"The Clicker\"...");

                return "ClickerClass/Items/Weapons/Clickers/TheClicker";
            }
        }

        public virtual ModCompatibility ModDependency => null;

        public sealed override void SetStaticDefaults()
        {
            ClickerCompatibilityCalls.RegisterClickerWeapon(this);
            SafeSetStaticDefaults();
        }

        public sealed override void SetDefaults()
        {
            ClickerCompatibilityCalls.SetClickerWeaponDefaults(item);
            item.Size = Main.itemTexture[item.type]?.Size() ?? Vector2.Zero;

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