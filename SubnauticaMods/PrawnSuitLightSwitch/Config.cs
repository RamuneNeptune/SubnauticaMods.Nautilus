

namespace Ramune.PrawnSuitLightSwitch
{
    [Menu("Prawn Suit Light Switch")]
    public class Config : ConfigFile
    {
        [Keybind("Toggle lights key")]
        public KeyCode toggle = KeyCode.Mouse2;

        [Toggle("Enable toggle on/off UI text")]
        public bool ui = true;

        [Toggle("Enable toggle on/off sounds")]
        public bool sounds = true;

        [Toggle("Enable toggle on/off subtitles")]
        public bool debug = true;
    }
}