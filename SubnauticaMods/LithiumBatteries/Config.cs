

namespace Ramune.LithiumBatteries
{
    [Menu("Lithium Batteries")]
    public class Config : ConfigFile
    {
        [Button("Open recipe folder")]
        public void Open(ButtonClickedEventArgs _) => Process.Start(Variables.Paths.RecipeFolder);
    }
}