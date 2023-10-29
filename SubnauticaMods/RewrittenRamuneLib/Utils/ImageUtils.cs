

namespace RamuneLib
{
    public static class ImageUtils
    {
        public static string GetAssetPath(string filename) => Path.Combine(Variables.Paths.AssetsFolder, filename + ".png");


        /// <summary>
        /// Loads and returns an <see cref="Atlas.Sprite"/> loaded from the Assets folder using the filename provided
        /// </summary>
        /// <param name="filename">The filename of the sprite to load.</param>
        /// <returns>The loaded <see cref="Atlas.Sprite"/>.
        public static Atlas.Sprite GetSprite(string filename)
        {
            return Nautilus.Utility.ImageUtils.LoadSpriteFromFile(GetAssetPath(filename));
        }


        /// <summary>
        /// Gets and returns an <see cref="Atlas.Sprite"/> associated with the given TechType.
        /// </summary>
        /// <param name="techType">The TechType of the sprite to retrieve.</param>
        /// <returns>The retrieved <see cref="Atlas.Sprite"/>.
        public static Atlas.Sprite GetSprite(TechType techType)
        {
            return SpriteManager.Get(techType);
        }


        /// <summary>
        /// Loads and returns a <see cref="Sprite"/> loaded from the Assets folder using the filename provided.
        /// </summary>
        /// <param name="filename">The filename of the sprite to load.</param>
        /// <returns>The loaded <see cref="Sprite"/>.
        public static Sprite GetUnitySprite(string filename)
        {
            var sprite = Nautilus.Utility.ImageUtils.LoadSpriteFromFile(GetAssetPath(filename));

            return Sprite.Create(sprite.texture, new Rect(0f, 0f, sprite.texture.width, sprite.texture.height), new Vector2(0.5f, 0.5f));
        }


        /// <summary>
        /// Loads and returns a <see cref="Texture2D"/> loaded from the Assets folder using the filename provided.
        /// </summary>
        /// <param name="filename">The filename of the texture to load.</param>
        /// <returns>The loaded <see cref="Texture2D"/>.
        public static Texture2D GetTexture(string filename)
        {
            return Nautilus.Utility.ImageUtils.LoadTextureFromFile(GetAssetPath(filename));
        }
    }
}