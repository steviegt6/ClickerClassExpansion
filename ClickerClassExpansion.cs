using ClickerClassExpansion.Common.Compatibility;
using ClickerClassExpansion.Content.ThoriumMod.Weapons;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Terraria.ModLoader;
using ThoriumMod.Contracts;

namespace ClickerClassExpansion
{
    public class ClickerClassExpansion : Mod
    {
        public static ClickerClassExpansion Instance { get; private set; }

        /// <summary>
        /// This version of clicker class expansion is built and made for Clicker Class v1.2.4!
        /// </summary>
        public readonly Version ClickerClassVersion = new Version(1, 2, 5);

        internal Mod calamityMod;
        internal Mod clickerClass;
        internal Mod redemption;
        internal Mod sacredTools;
        internal Mod spiritMod;
        internal Mod thoriumMod;

        public ClickerClassExpansion()
        {
            Instance = this;
        }

        public override void Load()
        {
            LoadCompatibilities();

            if (ModLoader.GetMod("ClickerClass").Version != ClickerClassVersion)
                Logger.Warn("This build of ClickerClassExpansion was not made for your current version of ClickerClass!" +
                    "\nSome incompatibilities or other issues may occur!");
        }

        public override void PostSetupContent()
        {
            if (thoriumMod != null)
                ModifyContracts();
        }

        private void LoadCompatibilities()
        {
            calamityMod = ModLoader.GetMod("CalamityMod");
            clickerClass = ModLoader.GetMod("ClickerClass");
            redemption = ModLoader.GetMod("Redemption");
            sacredTools = ModLoader.GetMod("SacredTools");
            spiritMod = ModLoader.GetMod("SpiritMod");
            thoriumMod = ModLoader.GetMod("ThoriumMod");

            if (calamityMod != null)
                Logger.Info("CalamityMod (Calamity) has been detected. Calamity content will be loaded.");

            if (redemption != null)
                Logger.Info("Redemption (Mod of Redemption) has been detected. MoR content will be loaded.");

            if (sacredTools != null)
                Logger.Info("SacredTools (Shadows of Abaddon) has been detected. SoA content will be loaded.");

            if (spiritMod != null)
                Logger.Info("ThoriumMod (Thorium) has been detected. Thorium content will be loaded.");

            if (thoriumMod != null)
                Logger.Info("SpiritMod (Spirit) has been detected. Spirit content will be loaded.");
        }

        private void ModifyContracts()
        {
            List<MonsterContract> contractList = thoriumMod.Code.GetType("ThoriumMod.Contracts.ContractVault").GetField("Contracts", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as List<MonsterContract>;

            // Bone Lee contract
            MonsterContract boneLeeContract = contractList.FirstOrDefault(contract => contract.Title == "Tracker's End");

            List<ContractReward> boneLeeRewardList = boneLeeContract.Rewards.ToList();
            boneLeeRewardList.Add(new ContractReward(ModContent.ItemType<TheBlackClicker>(), 25));

            typeof(MonsterContract).GetProperty("Rewards", BindingFlags.Instance | BindingFlags.Public).SetValue(boneLeeContract, boneLeeRewardList.ToArray());
        }
    }
}