using ClickerClassExpansion.Common.Compatibility;
using Terraria.ModLoader;

namespace ClickerClassExpansion.Content.ThoriumMod
{
    public abstract class ThoriumClickerItem : ModdedClickerItem
    {
        public override ModCompatibility ModDependency => ClickerClassExpansion.Instance.modCompats["ThoriumMod"];

        public override bool ModDependencyIsLoaded => ModLoader.GetMod("ThoriumMod") != null;
    }
}