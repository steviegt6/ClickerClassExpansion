using ClickerClassExpansion.Common.Compatibility;
using System;
using Terraria.ModLoader;

namespace ClickerClassExpansion
{
    public class ClickerClassExpansion : Mod
    {
        /// <summary>
        /// This version of clicker class expansion is built and made for Clicker Class v1.2.4!
        /// </summary>
        public static Version ClickerClassVersion { get; private set; } = new Version(1, 2, 4);

        public static ClickerClassCompatibility ClickerClass = new ClickerClassCompatibility();

        public override void Load()
        {
            LoadCompatibilities();
        }

        public override void Unload()
        {
            UnloadStaticFields();
        }

        public static void LoadCompatibilities()
        {
            // Needs to be loaded immediately: ClickerClass = new ClickerClassCompatibility();
        }

        private static void UnloadStaticFields()
        {
            ClickerClassVersion = null;
        }
    }
}