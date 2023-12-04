

namespace Ramune.BZEnameledGlass
{
    [Menu("BZ Enameled Glass")]
    public class Config : ConfigFile
    {
        [Button("Open recipe file")]
        public void OpenRecipeFile(ButtonClickedEventArgs _) => Process.Start(Path.Combine(Variables.Paths.RecipeFolder, "EnameledGlassClone.json"));
    }
}