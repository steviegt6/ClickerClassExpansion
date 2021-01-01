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

        public static ClickerClassCompatibility ClickerClass { get; private set; } = new ClickerClassCompatibility();

        public static CalamityModCompatibility CalamityMod { get; private set; }

        public static RedemptionCompatibility Redemption { get; private set; }

        public static SacredToolsCompatibility SacredTools { get; private set; }

        public static ThoriumModCompatibility ThoriumMod { get; private set; }

        public override void Load()
        {
            LoadCompatibilities();
        }

        public override void Unload()
        {
            UnloadStaticFields();
        }

        private static void LoadCompatibilities()
        {
            Mod mod = ModContent.GetInstance<ClickerClassExpansion>();
            // Needs to be loaded immediately: ClickerClass = new ClickerClassCompatibility();

            CalamityMod = new CalamityModCompatibility();
            Redemption = new RedemptionCompatibility();
            SacredTools = new SacredToolsCompatibility();
            ThoriumMod = new ThoriumModCompatibility();

            if (CalamityMod.IsLoaded)
                mod.Logger.Info("CalamityMod (Calamity) has been detected. Calamity content will be loaded.");

            if (Redemption.IsLoaded)
                mod.Logger.Info("Redemption (Mod of Redemption) has been detected. MoR content will be loaded.");

            if (SacredTools.IsLoaded)
                mod.Logger.Info("SacredTools (Shadows of Abaddon) has been detected. SoA content will be loaded.");

            if (ThoriumMod.IsLoaded)
                mod.Logger.Info("ThoriumMod (Thorium) has been detected. Thorium content will be loaded.");
        }

        private static void UnloadStaticFields()
        {
            ClickerClassVersion = null;
        }
    }
}