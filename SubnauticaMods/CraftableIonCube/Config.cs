

namespace Ramune.CraftableIonCube
{
    [Menu("Craftable Ion Cube")]
    public class Config : ConfigFile
    {
        [Button("Open recipe file")]
        public void Open(ButtonClickedEventArgs _)
        {
            Process.Start(Path.Combine(Variables.Paths.RecipeFolder, "CraftableIonCube.json"));
        }
    }
}