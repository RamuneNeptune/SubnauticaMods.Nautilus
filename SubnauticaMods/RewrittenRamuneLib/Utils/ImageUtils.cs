

namespace RamuneLib.Utils
{
    public static class ImageUtils
    {
        public static string GetAssetPath(string filename, string extension = ".png") => Path.Combine(Variables.Paths.AssetsFolder, filename + extension);


        /// <summary>
        /// Loads and returns an <see cref="Atlas.Sprite"/> loaded from the Assets folder using the filename provided
        /// </summary>
        /// <param name="filename">The filename of the sprite to load.</param>
        /// <returns>The loaded <see cref="Atlas.Sprite"/>.
        public static Atlas.Sprite GetSprite(string filename, string extension = ".png") => Nautilus.Utility.ImageUtils.LoadSpriteFromFile(GetAssetPath(filename, extension));


        /// <summary>
        /// Gets and returns an <see cref="Atlas.Sprite"/> associated with the given TechType.
        /// </summary>
        /// <param name="techType">The TechType of the sprite to retrieve.</param>
        /// <returns>The retrieved <see cref="Atlas.Sprite"/>.
        public static Atlas.Sprite GetSprite(TechType techType) => SpriteManager.Get(techType);


        /// <summary>
        /// Loads and returns a <see cref="Sprite"/> loaded from the Assets folder using the filename provided.
        /// </summary>
        /// <param name="filename">The filename of the sprite to load.</param>
        /// <returns>The loaded <see cref="Sprite"/>.
        public static Sprite GetUnitySprite(string filename, string extension = ".png") => GetSprite(filename, extension).AsUnitySprite();


        /// <summary>
        /// Returns the passed <see cref="Atlas.Sprite"/> as a <see cref="Sprite"/> 
        /// </summary>
        public static Sprite AsUnitySprite(this Atlas.Sprite sprite) => Sprite.Create(sprite.texture, new Rect(0f, 0f, sprite.texture.width, sprite.texture.height), new Vector2(0.5f, 0.5f));


        /// <summary>
        /// Loads and returns a <see cref="Texture2D"/> loaded from the Assets folder using the filename provided.
        /// </summary>
        /// <param name="filename">The filename of the texture to load.</param>
        /// <returns>The loaded <see cref="Texture2D"/>.
        public static Texture2D GetTexture(string filename, string extension = ".png") => Nautilus.Utility.ImageUtils.LoadTextureFromFile(GetAssetPath(filename, extension));
    }
}