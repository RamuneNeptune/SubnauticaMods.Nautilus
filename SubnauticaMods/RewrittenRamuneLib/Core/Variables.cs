

namespace RamuneLib
{
    public static class Variables
    {
        public static Harmony harmony { get; set; }

        public static ManualLogSource logger { get; set; }

        public static class Paths
        {
            public static string PluginFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            public static string AssetsFolder => Path.Combine(PluginFolder, "Assets");

            public static string RecipeFolder => Path.Combine(PluginFolder, "Recipes");
        }
    }
}