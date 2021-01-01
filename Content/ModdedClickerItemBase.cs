using ClickerClass;
using ClickerClass.Items;

namespace ClickerClassExpansion.Content
{
    public abstract class ModdedClickerItemBase : ClickerItem
    {
        public override bool Autoload(ref string name) => ClickerClassExpansion.ClickerClass.IsLoaded && ModDependencyIsLoaded;

        public virtual bool ModDependencyIsLoaded => true;

        public sealed override void SetStaticDefaults()
        {
            ClickerSystem.RegisterClickerWeapon(this);

            SafeSetStaticDefaults();
        }

        /// <summary>
        /// This is where you set all your item's static properties, such as names/translations and arrays in ItemID.Sets. This is called after SetDefaults on the initial ModItem.
        /// </summary>
        public virtual void SafeSetStaticDefaults()
        {
        }

        public sealed override void SetDefaults()
        {
            ClickerSystem.SetClickerWeaponDefaults(item);
            SafeSetDefaults();
        }

        /// <summary>
        /// This is where you set all your item's properties, such as width, damage, shootSpeed, defense, etc. For those that are familiar with tAPI, this has the same function as .json files.
        /// </summary>
        public virtual void SafeSetDefaults()
        {
        }
    }
}