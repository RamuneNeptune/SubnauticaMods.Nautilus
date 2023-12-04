

namespace Ramune.BuildableBrainCoral
{
    [Menu("Buildable Brain Coral")]
    public class Config : ConfigFile
    {
        [Button("Open recipe file")]
        public void Open(ButtonClickedEventArgs _) => Process.Start(Path.Combine(Variables.Paths.RecipeFolder, "BuildableBrainCoral.json"));
    }
}