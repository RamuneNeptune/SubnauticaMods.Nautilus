

namespace RamuneLib
{
    public static class ImageUtils
    {
        public static string GetAssetPath(string filename) => Path.Combine(Variables.Paths.AssetsFolder, filename + ".png");


        public static Atlas.Sprite GetSprite(string filename)
        {    
            return Nautilus.Utility.ImageUtils.LoadSpriteFromFile(GetAssetPath(filename));
        }


        public static Atlas.Sprite GetSprite(TechType techType)
        {
            return SpriteManager.Get(techType);
        }


        public static Sprite GetUnitySprite(string filename)
        {
            var sprite = Nautilus.Utility.ImageUtils.LoadSpriteFromFile(GetAssetPath(filename));

            return Sprite.Create(sprite.texture, new(0f, 0f, sprite.texture.width, sprite.texture.height), new(0.5f, 0.5f)); 
        }

    
        public static Texture2D GetTexture(string filename)
        {
            return Nautilus.Utility.ImageUtils.LoadTextureFromFile(GetAssetPath(filename));
        }
    }
}