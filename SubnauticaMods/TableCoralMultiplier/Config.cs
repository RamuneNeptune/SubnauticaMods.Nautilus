

namespace Ramune.TableCoralMultiplier
{
    [Menu("Table Coral Multiplier")]
    public class Config : ConfigFile
    {
        [Slider("Table coral to spawn", Format = "{0:F0}", DefaultValue = 1f, Min = 1f, Max = 20f, Step = 1f, Tooltip = "Amount of table coral to spawn")]
        public float tableCoralToSpawn = 1f;
    }
}