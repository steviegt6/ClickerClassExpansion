using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClickerClassExpansion.Content.ThoriumMod.Weapons;
using Terraria.ModLoader;

namespace ClickerClassExpansion.Common.Compatibility
{
    public class ThoriumModCompatibility : ModCompatibility
    {
        public ThoriumModCompatibility() : base("ThoriumMod")
        {
        }

        public override void SetupContent()
        {
            List<MonsterContract> contractList = Instance.Code.GetType("ThoriumMod.Contracts.ContractVault").GetField("Contracts", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as List<MonsterContract>;

            // Bone Lee contract
            MonsterContract boneLeeContract = contractList.FirstOrDefault(contract => contract.Title == "Tracker's End");

            List<ContractReward> boneLeeRewardList = boneLeeContract.Rewards.ToList();
            boneLeeRewardList.Add(new ContractReward(ModContent.ItemType<TheBlackClicker>(), 25));

            typeof(MonsterContract).GetProperty("Rewards", BindingFlags.Instance | BindingFlags.Public).SetValue(boneLeeContract, boneLeeRewardList.ToArray());
        }
    }
}