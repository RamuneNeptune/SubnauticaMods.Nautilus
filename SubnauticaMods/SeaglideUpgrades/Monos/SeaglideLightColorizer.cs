

namespace Ramune.SeaglideUpgrades.Monos
{
    public class Seaglides
    {
        public static List<SeaglideLightColorizer> Colorizers = new();
    }


    public class SeaglideLightColorizer : MonoBehaviour
    {
        public Light[] lights;

        public Color color;

        public enum UpgradedSeaglide
        {
            MK1,
            MK2,
            MK3
        };

        public UpgradedSeaglide thisSeaglide;

        public void OnEnable() => Seaglides.Colorizers.Add(this);

        public void OnDisable() => Seaglides.Colorizers.Remove(this);

        public void Start() => lights = gameObject.FindChild("lights_parent").GetComponentsInChildren<Light>(true);

        public void Refresh(UpgradedSeaglide seaglideToAdjust, ref float r, ref float g, ref float b, ref float intensityMultiplier, ref float rangeMultiplier, ref float conesizeMultiplier)
        {
            if(seaglideToAdjust != thisSeaglide)
                return;

            for(int i = 0; i < lights.Length; i++)
            {
                color.r = r;
                color.g = g;
                color.b = b;

                lights[i].color = color;
                lights[i].intensity = 0.9f * intensityMultiplier;
                lights[i].range = 200f * rangeMultiplier;
                lights[i].spotAngle = 70 * conesizeMultiplier;
            }
        }
    }
}