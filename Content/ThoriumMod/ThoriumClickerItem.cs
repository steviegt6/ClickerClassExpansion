using Terraria.ModLoader;

namespace ClickerClassExpansion.Content.ThoriumMod
{
    public abstract class ThoriumClickerItem : ModdedClickerItemBase
    {
        public override bool ModDependencyIsLoaded => ModLoader.GetMod("ThoriumMod") != null;
    }
}