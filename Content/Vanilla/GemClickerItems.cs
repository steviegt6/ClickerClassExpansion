using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ClickerClassExpansion.Content.Vanilla
{
    public class AmethystGemClicker : GemClickerItem
    {
        public override int DamageIncrease => 0;

        public override float RadiusIncrease => 0.2f;

        public override int GemItem => ItemID.Amethyst;

        public override int DustType => 86;

        public override Color GemColor => Color.Purple;

        public override void SafeSetStaticDefaults() => DisplayName.SetDefault("Amethyst Clicker");
    }

    public class TopazGemClicker : GemClickerItem
    {
        public override int DamageIncrease => 0;

        public override float RadiusIncrease => 0.2f;

        public override int GemItem => ItemID.Topaz;

        public override int DustType => 87;

        public override Color GemColor => Color.Orange;

        public override void SafeSetStaticDefaults() => DisplayName.SetDefault("Topaz Clicker");
    }

    public class SapphireGemClicker : GemClickerItem
    {
        public override int DamageIncrease => 1;

        public override float RadiusIncrease => 0.3f;

        public override int GemItem => ItemID.Sapphire;

        public override int DustType => 88;

        public override Color GemColor => Color.Blue;

        public override void SafeSetStaticDefaults() => DisplayName.SetDefault("Sapphire Clicker");
    }

    public class EmeraldGemClicker : GemClickerItem
    {
        public override int DamageIncrease => 1;

        public override float RadiusIncrease => 0.3f;

        public override int GemItem => ItemID.Emerald;

        public override int DustType => 89;

        public override Color GemColor => Color.Green;

        public override void SafeSetStaticDefaults() => DisplayName.SetDefault("Emerald Clicker");
    }

    public class RubyGemClicker : GemClickerItem
    {
        public override int DamageIncrease => 2;

        public override float RadiusIncrease => 0.45f;

        public override int GemItem => ItemID.Topaz;

        public override int DustType => 90;

        public override Color GemColor => Color.Red;

        public override void SafeSetStaticDefaults() => DisplayName.SetDefault("Ruby Clicker");
    }

    public class DiamondGemClicker : GemClickerItem
    {
        public override int DamageIncrease => 2;

        public override float RadiusIncrease => 0.45f;

        public override int GemItem => ItemID.Diamond;

        public override int DustType => 91;

        public override Color GemColor => Color.LightBlue;

        public override void SafeSetStaticDefaults() => DisplayName.SetDefault("Diamond Clicker");
    }

    public class AmberGemClicker : GemClickerItem
    {
        public override int DamageIncrease => 3;

        public override float RadiusIncrease => 0.6f;

        public override int GemItem => ItemID.Amber;

        public override int DustType => DustID.AmberBolt;

        public override Color GemColor => Color.Goldenrod;

        public override void SafeSetStaticDefaults() => DisplayName.SetDefault("Amber Clicker");
    }
}
