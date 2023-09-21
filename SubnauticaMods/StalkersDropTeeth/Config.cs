

namespace Ramune.StalkersDropTeethWhenTheyDie
{
    [Menu("Stalkers Drop Teeth When They Die")]
    public class Config : ConfigFile
    {
        [Slider("Amount of teeth to drop", Format = "{0:F0}", DefaultValue = 1f, Min = 1f, Max = 25f, Step = 1f, Tooltip = "Changes are applied automatically")]
        public float teethToDrop = 1f;
    }
}