

namespace RamuneLib.Extensions
{
    public static class TechTypeExtensions
    {
        public static string DisplayName(this TechType techType) => Language.main.Get(techType);

        public static string Tooltip(this TechType techType) => Language.main.Get("Tooltip_" + techType);

        public static Atlas.Sprite Sprite(this TechType techType) => SpriteManager.Get(techType);
    }
}