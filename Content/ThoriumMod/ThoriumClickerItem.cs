using ClickerClassExpansion.Common.Compatibility;

namespace ClickerClassExpansion.Content.ThoriumMod
{
    public abstract class ThoriumClickerItem : ModdedClickerItem
    {
        public override ModCompatibility ModDependency => ClickerClassExpansion.Instance.modCompats["ThoriumMod"];
    }
}