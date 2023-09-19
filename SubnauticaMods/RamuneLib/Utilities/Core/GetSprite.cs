

namespace RamuneLib
{
    public static partial class Utilities
    {
        /// <summary>
        /// Get a sprite from the game by TechType, or from the Assets folder by string
        /// </summary>
        /// <param name="techType"></param>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns>A <see cref="Atlas.Sprite"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Atlas.Sprite GetSprite(object techTypeOrFilename, string? foldername = null)
        {
            if(techTypeOrFilename is TechType techType) return SpriteManager.Get(techType);

            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return string.IsNullOrEmpty(foldername)
                ? ImageUtils.LoadSpriteFromFile(Path.Combine(path, "Assets", techTypeOrFilename.ToString() + ".png"))
                : ImageUtils.LoadSpriteFromFile(Path.Combine(path, foldername, techTypeOrFilename.ToString() + ".png"));
        }
    }
}