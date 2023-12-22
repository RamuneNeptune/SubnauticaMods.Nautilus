

namespace Ramune.SeaglideUpgrades.Monos
{
    public static class Seaglides
    {
        public static List<SeaglideLightColorizer> Colorizers = new();
    }


    public class SeaglideLightColorizer : MonoBehaviour
    {
        public UpgradedSeaglide thisSeaglide;
        public enum UpgradedSeaglide
        {
            MK1,
            MK2,
            MK3
        };
        public Light[] lights;
        public Color color;


        public void Start()
        {
            if(LoggerUtils.Debug)
                LoggerUtils.Screen.LogDebug($"SeaglideLightColorizer.Start() -- [1/2]: {thisSeaglide}");

            lights = gameObject.GetComponentsInChildren<Light>(true);
            lights.ForEach(li => li.gameObject.SetActive(true));

            if(LoggerUtils.Debug)
                LoggerUtils.Screen.LogDebug($"SeaglideLightColorizer.Start() -- [2/2]: {thisSeaglide}");
        }


        public void OnEnable() => Seaglides.Colorizers.Add(this);


        public void OnDisable() => Seaglides.Colorizers.Remove(this);


        public void Refresh(UpgradedSeaglide seaglideToAdjust, ref float r, ref float g, ref float b, ref float intensityMultiplier, ref float rangeMultiplier, ref float conesizeMultiplier)
        {
            if(seaglideToAdjust != thisSeaglide)
                return;

            if(LoggerUtils.Debug)
                LoggerUtils.Screen.LogInfo($"Attempting to change light colors for: {seaglideToAdjust}");

            if(lights.Length == 0)
                return;

            for(int i = 0; i < lights.Length; i++)
            {
                if(lights[i] is null)
                    continue;

                color.r = r;
                color.g = g;
                color.b = b;

                lights[i].color = color;
                lights[i].intensity = 0.9f * intensityMultiplier;
                lights[i].range = 200f * rangeMultiplier;
                lights[i].spotAngle = 70 * conesizeMultiplier;
            }


            if(LoggerUtils.Debug)
                LoggerUtils.Screen.LogSuccess($"Changed light colors for: {seaglideToAdjust}");
        }
    }
}