

namespace Ramune.RadiantDepths.Monos
{
    public class AreaLight : MonoBehaviour
    {
        private Light light;
        private float currentFadeTime = 0f;
        private bool fadingIn = true;
        public Color color;


        public void Start()
        {
            light = gameObject.EnsureComponent<Light>();
            light.name = name.TrimClone() + "Light";
            light.range = 1.5f;
            light.intensity = 2f;
            light.color = color;
        }


        public void Update()
        {
            currentFadeTime += Time.deltaTime;
            float time = Mathf.Clamp01(currentFadeTime/3f);
            float start = fadingIn ? 0.0f : 2.0f;
            float end = fadingIn ? 2.0f : 0.0f;
            float intensity = Mathf.Lerp(start, end, time);
            light.intensity = intensity;

            if(time >= 1.0f)
            {
                fadingIn = !fadingIn;
                currentFadeTime = 0.0f;
            }
        }
    }
}