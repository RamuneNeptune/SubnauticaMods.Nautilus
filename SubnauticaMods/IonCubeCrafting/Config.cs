

namespace Ramune.IonCubeCrafting
{
    [Menu("Ion Cube Crafting")]
    public class Config : ConfigFile
    {
        [Choice(label:"Recipe to use (requires restart)", options:)]
        public bool isEnabled = true;

        [Button("Close game")]
        public void CloseGame(ButtonClickedEventArgs _)
        {
            Application.Quit();
        }
    }
}