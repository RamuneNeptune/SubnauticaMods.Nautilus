

namespace RamuneLib
{
    public static class JsonUtils
    {
        public static void DeleteJsonRecipe(string filename) => File.Delete(Path.Combine(Variables.Paths.RecipeFolder, filename + ".json"));


        public static string GetJsonRecipe(string filename) => Path.Combine(Variables.Paths.RecipeFolder, filename + ".json");
    }
}