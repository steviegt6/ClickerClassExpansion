using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClickerClassExpansion.Content.ThoriumMod.Weapons;
using Terraria;
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
            try
            {
                List<object> contractList =
                    Code.GetType("ThoriumMod.Contracts.ContractVault")
                        .GetField("Contracts", BindingFlags.Static | BindingFlags.NonPublic)
                        ?.GetValue(null) as List<object>;

                // Bone Lee contract
                object boneLeeContract = (contractList ?? throw new InvalidOperationException()).FirstOrDefault(
                    contract => Code.GetType("ThoriumMod.Contracts.MonsterContract")
                        .GetProperty("Title", BindingFlags.Public | BindingFlags.Instance)
                        ?.GetValue(contract) as string == "Tracker's End");

                List<object> boneLeeRewardList = ((object[])Code.GetType("ThoriumMod.Contracts.MonsterContract")
                        .GetProperty("Rewards", BindingFlags.Public | BindingFlags.Instance)
                        ?.GetValue(boneLeeContract) ?? throw new InvalidOperationException())
                    .ToList();

                boneLeeRewardList.Add(Code.GetType("ContractReward")
                    .GetConstructor(BindingFlags.Public | BindingFlags.Instance, null,
                        new[] { typeof(int), typeof(int) }, null)
                    ?.Invoke(new object[] { ModContent.ItemType<TheBlackClicker>(), 25 }));

                Code.GetType("ThoriumMod.Contracts.MonsterContract")
                    .GetProperty("Rewards", BindingFlags.Instance | BindingFlags.Public)
                    ?.SetValue(boneLeeContract, boneLeeRewardList.ToArray());
            }
            catch (Exception e)
            {
                if (e is InvalidOperationException)
                    ClickerClassExpansion.Instance.Logger.Warn(e.Message + "\n" + e.StackTrace);
            }
        }
    }

    public static class ThoriumModExtensions
    {
        public static int GetFlatShadowDamage(this Player player)
        {
            object thoriumPlayer = player.GetModPlayer(ModLoader.GetMod("ThoriumMod"), "ThoriumPlayer");

            return (int)ModLoader.GetMod("ThoriumMod").Code.GetType("ThoriumMod.ThoriumPlayer")
                .GetField("flatShadowDamage", BindingFlags.Instance | BindingFlags.Public)
                ?.GetValue(thoriumPlayer);
        }

        public static int GetDarkFocus(this Player player)
        {
            object thoriumPlayer = player.GetModPlayer(ModLoader.GetMod("ThoriumMod"), "ThoriumPlayer");

            return (int)ModLoader.GetMod("ThoriumMod").Code.GetType("ThoriumMod.ThoriumPlayer")
                .GetField("darkFocus", BindingFlags.Instance | BindingFlags.Public)
                ?.GetValue(thoriumPlayer);
        }

        public static void SetDarkFocus(this Player player, int value)
        {
            object thoriumPlayer = player.GetModPlayer(ModLoader.GetMod("ThoriumMod"), "ThoriumPlayer");

            ModLoader.GetMod("ThoriumMod").Code.GetType("ThoriumMod.ThoriumPlayer")
                .GetField("darkFocus", BindingFlags.Instance | BindingFlags.Public)
                ?.SetValue(thoriumPlayer, value);
        }
    }
}