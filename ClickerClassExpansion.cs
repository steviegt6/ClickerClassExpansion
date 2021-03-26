using System;
using System.Collections.Generic;
using ClickerClassExpansion.Common.Compatibility;
using Terraria.ModLoader;

namespace ClickerClassExpansion
{
    public class ClickerClassExpansion : Mod
    {
        public static ClickerClassExpansion Instance { get; private set; }

        /// <summary>
        /// This version of clicker class expansion is built and made for Clicker Class v1.2.5!
        /// </summary>
        public readonly Version ClickerClassVersion = new Version(1, 2, 5);

        public ClickerClassExpansion() => Instance = this;

        internal Dictionary<string, ModCompatibility> modCompats;

        public override void Load()
        {
            ClickerCompatibilityCalls.Load();

            if (ModLoader.GetMod("ClickerClass").Version != ClickerClassVersion)
                Logger.Warn("This build of ClickerClassExpansion was not made for your current version of ClickerClass!" +
                    "\nSome incompatibilities or other issues may occur!");

            modCompats = new Dictionary<string, ModCompatibility>();

            foreach (Type type in Code.GetTypes())
            {
                if (type.IsSubclassOf(typeof(ModCompatibility)) && !type.IsAbstract &&
                    type.GetConstructor(new Type[] { }) != null)
                {
                    if (!(Activator.CreateInstance(type) is ModCompatibility compat))
                        continue;

                    modCompats.Add(compat.ToString(), compat);
                    compat.Load();
                }
            }
        }

        public override void PostSetupContent()
        {
            foreach (ModCompatibility compat in modCompats.Values)
                compat.SetupContent();
        }

        public override void Unload()
        {
            foreach (ModCompatibility compat in modCompats.Values)
                compat.Unload();

            ClickerCompatibilityCalls.Unload();
        }
    }
}