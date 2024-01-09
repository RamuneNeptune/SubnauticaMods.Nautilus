

namespace Ramune.RadiantDepths.Monos
{
    public class RadiantLight : MonoBehaviour
    {
        public Light light;
        public float duration;

        public void Start()
        {
            duration = 3f;
            light = gameObject.EnsureComponent<Light>();
            light.name = name + "Light";
            light.range = 1.5f;
            light.intensity = 2f;
            light.color = new Color(0.75f, 0f, 1f);
        }

        public void Update()
        {

        }
    }
}