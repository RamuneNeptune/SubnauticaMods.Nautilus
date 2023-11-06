

namespace Ramune.Seal.CustomizableHorn
{
    [Menu("Seal Customizable Horn")]
    public class Config : ConfigFile
    {
        [Keybind("Switch to next sound keybind")]
        public KeyCode keybind = KeyCode.Period;

        [Slider("Horn sound pitch (affects speed)", Format = "{0:F0}%", DefaultValue = 100f, Min = 1f, Max = 250f, Step = 1f)]
        public float pitch = 100f;

        [Slider("Horn sound volume", Format = "{0:F0}%", DefaultValue = 100f, Min = 1f, Max = 250f, Step = 1f)]
        public float volume = 100f;

        [Button("Open sounds (mp3) folder")]
        public void Open(ButtonClickedEventArgs _) => Process.Start(Path.Combine(Variables.Paths.PluginFolder, "Sounds"));
    }
}