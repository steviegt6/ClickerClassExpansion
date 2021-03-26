using System.Reflection;
using Terraria.ModLoader;

namespace ClickerClassExpansion.Common.Compatibility
{
    public abstract class ModCompatibility
    {
        private readonly string _name;

        /// <summary>
        /// The instance of the specified Mod.
        /// </summary>
        public Mod Instance { get; }

        public Assembly Code => Instance.Code;

        /// <summary>
        /// Whether or not a mod is loaded.
        /// </summary>
        public virtual bool IsLoaded => Instance != null;

        protected ModCompatibility(string mod)
        {
            Instance = ModLoader.GetMod(mod);
            _name = mod;
        }

        protected ModCompatibility(Mod mod)
        {
            Instance = mod;
            _name = mod.Name;
        }

        public virtual void Load()
        {
        }

        public virtual void SetupContent()
        {
        }

        public virtual void Unload()
        {
        }

        public override string ToString() => _name;
    }
}