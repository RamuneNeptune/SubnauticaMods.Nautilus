

namespace RamuneLib
{
    public static partial class Utilities
    {
        /// <summary>
        /// Gets a sprite from the Assets folder by string
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns>A <see cref="Texture2D"/></returns>
        public static Texture2D GetTexture(string filename, string? foldername = null)
        {
            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return string.IsNullOrEmpty(foldername)
                ? ImageUtils.LoadTextureFromFile(Path.Combine(path, "Assets", filename + ".png"))
                : ImageUtils.LoadTextureFromFile(Path.Combine(path, foldername, filename + ".png"));
        }
    }
}

