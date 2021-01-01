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

        public override void Unload()
        {
            UnloadStaticFields();
        }

        private static void UnloadStaticFields()
        {
            ClickerClassVersion = null;
        }
    }
}