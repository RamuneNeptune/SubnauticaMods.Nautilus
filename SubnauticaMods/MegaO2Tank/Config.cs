

namespace Ramune.MegaO2Tank
{
    [Menu("Mega O2 Tank")]
    public class Config : ConfigFile
    {
        [Slider("Tank oxygen capacity", Format = "{0:F1}", DefaultValue = 360f, Min = 180f, Max = 720f, Step = 10f, Tooltip = "Changes are applied on restart", Order = 0)]
        public float oxygenCapacity = 360f;

        [Button("Close game (to apply changes)")]
        public void Close(ButtonClickedEventArgs _)
        {
            Application.Quit();
        }
    }
}