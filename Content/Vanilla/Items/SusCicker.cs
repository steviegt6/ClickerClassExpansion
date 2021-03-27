using System.Collections.Generic;
using System.Linq;
using ClickerClass;
using ClickerClassExpansion.Common.Compatibility;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ClickerClassExpansion.Content.Vanilla.Items
{
    public class SusCicker : ModdedClickerItem
    {
        public static List<string> AvailableEffects = new List<string>();
        public static int EffectIndex;

        public override void SafeSetStaticDefaults()
        {
            DisplayName.SetDefault("sus cicker [sic]");

            ClickerCompatibilityCalls.RegisterClickEffect(mod, "Impostor", "Impostor", "Can mimic any other effect", 3, Color.Red, DoSuspiciousActivitiesEpic);

            foreach (string effect in ClickerCompatibilityCalls.GetAllEffectNames().Where(effect => effect != $"{mod.Name}:Impostor"))
                AvailableEffects.Add(effect);

            void DoSuspiciousActivitiesEpic(Player player, Vector2 position, int type, int damage, float knockBack)
            {
                if (ClickerSystem.IsClickEffect(AvailableEffects[EffectIndex], out ClickEffect effect))
                    effect.Action?.Invoke(player, position, type, damage, knockBack);
            }
        }

        public override void SafeSetDefaults()
        {
            ClickerCompatibilityCalls.SetRadius(item, 15f);
            ClickerCompatibilityCalls.SetColor(item, Color.Red);
            ClickerCompatibilityCalls.SetDust(item, DustID.Buggy);
            ClickerCompatibilityCalls.AddEffect(item, $"{mod.Name}:Impostor");

            item.damage = 150;
            item.knockBack = 10f;
            item.value = 0;
            item.rare = ItemRarityID.Purple;
        }

        public override bool AltFunctionUse(Player player)
        {
            if (!(Main.mouseRight && Main.mouseRightRelease))
                return false;

            EffectIndex++;

            if (EffectIndex >= AvailableEffects.Count)
                EffectIndex = 0;

            if (ClickerSystem.IsClickEffect(AvailableEffects[EffectIndex], out ClickEffect effect))
                CombatText.NewText(player.getRect(), new Color(Main.rand.Next(0, 256), Main.rand.Next(0, 256), Main.rand.Next(0, 256)), $"Selected: {effect.DisplayName}");

            return true;
        }
    }
}
