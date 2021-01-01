using Terraria.ModLoader;

namespace ClickerClassExpansion.Common.Compatibility
{
    public abstract class ModCompatibility
    {
        public Mod Mod { get; }

        public bool IsLoaded { get; }

        public ModCompatibility(string mod)
        {
            Mod = ModLoader.GetMod(mod);
            IsLoaded = Mod != null;
        }

        public virtual void Load()
        {
        }

        public virtual void Unload()
        {
        }
    }
}