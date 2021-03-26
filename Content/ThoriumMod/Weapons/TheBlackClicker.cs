using ClickerClassExpansion.Common.Compatibility;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClassExpansion.Content.ThoriumMod.Weapons
{
    public class TheBlackClicker : ThoriumClickerItem
    {
        public override void SafeSetStaticDefaults()
        {
            DisplayName.SetDefault("The Black Clicker");
            Tooltip.SetDefault("Dealing damage grants you stacking damage" +
                "\nAt 50 stacks, your damage peaks and will wither away the target for 3 seconds");

            ClickerCompatibilityCalls.RegisterClickEffect(mod, "DarkClickerWither", "Wither", "Damaging an enemy grants stacking damage, capping at 50", 1, Color.Black, (player, position, type, damage, knockback) =>
            {
                if (damage <= 0)
                    return;

                player.AddBuff(ModDependency.Instance.BuffType("DarknessWithin"), 600);
                player.SetDarkFocus(player.GetDarkFocus() + 1);

                if (player.GetDarkFocus() < 50)
                    return;

                NPC closestNPC = null;
                float closestDist = float.MaxValue;

                foreach (NPC npc in Main.npc)
                    if (npc.active && npc.Distance(position) < closestDist)
                    {
                        closestNPC = npc;
                        closestDist = npc.Distance(position);
                    }

                if (closestDist <= 50f)
                    closestNPC?.AddBuff(ModDependency.Instance.BuffType("Wither"), 180);
            });
        }

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat) => flat += player.GetFlatShadowDamage();

        public override void SafeSetDefaults()
        {
            ClickerCompatibilityCalls.SetRadius(item, 4f);
            ClickerCompatibilityCalls.SetColor(item, Color.Black);
            ClickerCompatibilityCalls.SetDust(item, ModLoader.GetMod("ThoriumMod").DustType("BlackDust"));
            ClickerCompatibilityCalls.AddEffect(item, "ClickerClassExpansion:DarkClickerWither");

            item.damage = 60;
            item.width = item.height = 30;
            item.knockBack = 1f;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Red;
        }
    }
}