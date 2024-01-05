

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Monos
        {
            public class NightyNight : MonoBehaviour
            {
                public DayNightCycle _DayNightCycle;


                public void Start()
                {
                    var gradient = new Gradient
                    {
                        colorKeys = new GradientColorKey[]
                        {
                            new(new Color(1f, 0f, 0f), 10f)
                        }
                    };
                    _DayNightCycle = DayNightCycle.main;
                    _DayNightCycle.atmosphereColor = gradient;
                }


                public void Update()
                {
                    _DayNightCycle._dayNightSpeed = 0f;
                    _DayNightCycle.timePassedAsDouble = 1200;
                    _DayNightCycle.skipTimeMode = false;
                    _DayNightCycle.UpdateAtmosphere();
                }
            }
        }
    }
}