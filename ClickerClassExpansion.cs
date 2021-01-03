using ClickerClassExpansion.Common.Compatibility;
using System;
using Terraria.ModLoader;

namespace ClickerClassExpansion
{
    public class ClickerClassExpansion : Mod
    {
        public static ClickerClassExpansion Instance { get; private set; }

        /// <summary>
        /// This version of clicker class expansion is built and made for Clicker Class v1.2.4!
        /// </summary>
        public Version ClickerClassVersion { get; }

        public ClickerClassCompatibility ClickerClass = new ClickerClassCompatibility();

        public GenericCompatibility CalamityMod = new GenericCompatibility("CalamityMod");

        public GenericCompatibility Redemption = new GenericCompatibility("Redemption");

        public GenericCompatibility SacredTools = new GenericCompatibility("SacredTools");

        public GenericCompatibility ThoriumMod = new GenericCompatibility("ThoriumMod");

        public GenericCompatibility SpiritMod = new GenericCompatibility("SpiritMod");

        public ClickerClassExpansion()
        {
            Instance = this;

            ClickerClassVersion = new Version(1, 2, 5);
        }

        public override void Load()
        {
            if (ClickerClass.Mod.Version != ClickerClassVersion)
                Logger.Warn("This build of ClickerClassExpansion was not made for your current version of ClickerClass!" +
                    "\nSome incompatibilities or other issues may occur!");

            CheckCompatibilities();
        }

        private void CheckCompatibilities()
        {
            if (CalamityMod.IsLoaded)
                Logger.Info("CalamityMod (Calamity) has been detected. Calamity content will be loaded.");

            if (Redemption.IsLoaded)
                Logger.Info("Redemption (Mod of Redemption) has been detected. MoR content will be loaded.");

            if (SacredTools.IsLoaded)
                Logger.Info("SacredTools (Shadows of Abaddon) has been detected. SoA content will be loaded.");

            if (ThoriumMod.IsLoaded)
                Logger.Info("ThoriumMod (Thorium) has been detected. Thorium content will be loaded.");

            if (SpiritMod.IsLoaded)
                Logger.Info("SpiritMod (Spirit) has been detected. Spirit content will be loaded.");
        }
    }
}