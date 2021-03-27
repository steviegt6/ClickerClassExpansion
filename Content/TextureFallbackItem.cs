using Terraria.ModLoader;

namespace ClickerClassExpansion.Content 
{
    public abstract class TextureFallbackItem : ModItem
    {        
        // If no image for our item is found, use Clicker Class' The Clicker item.
        public override string Texture
        {
            get
            {
                if (ModContent.TextureExists(base.Texture))
                    return base.Texture;

                mod.Logger.Warn($"Item image for {Name} ({base.Texture}) not found! Falling back to ClickerClass' \"The Clicker\"...");

                return "ClickerClass/Items/Weapons/Clickers/TheClicker";
            }
        }
    }
}
