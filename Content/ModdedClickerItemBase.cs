using ClickerClass.Items;

namespace ClickerClassExpansion.Content
{
    public abstract class ModdedClickerItemBase : ClickerItem
    {
        public override bool Autoload(ref string name) => ClickerClassExpansion.ClickerClass.IsLoaded;
    }
}