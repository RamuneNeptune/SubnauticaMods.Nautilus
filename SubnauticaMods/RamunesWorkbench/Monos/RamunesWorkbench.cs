

namespace Ramune.RamunesWorkbench.Monos
{
    public class RamunesWorkbench : Workbench
    {
        public Renderer renderer;
        public Light light = new();

        public Color color = new(191f / 255f, 116f / 255f, 255f / 255f);
        public float duration = 3.50f;
        public float initial = 2.35f;
        public float result = -0.15f;
        public float elapsed = 0.00f;
        public bool isIncreasing = true;


        public override void Start()
        {
            base.Start();
            InitializeSparkInstances();

            fxLaserBeam?.ForEach(lb => lb.GetComponent<MeshRenderer>().material.color = color);

            light = gameObject.EnsureComponent<Light>();
            light.transform.parent = gameObject.transform;
            light.intensity = 0f;
            light.range = 1.7f;
            light.color = color;
            light.enabled = true;
        }


        public void Update()
        {
            if(renderer is null) return;

            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / duration);

            float glowStrength = isIncreasing
                ? Mathf.Lerp(result, initial, t)
                : Mathf.Lerp(initial, result, t);

            renderer.material.SetFloat(ShaderPropertyID._GlowStrength, glowStrength);

            if(elapsed >= duration)
            {
                isIncreasing = !isIncreasing;
                elapsed = 0f;
            }
        }


        public override void OnOpenedChanged(bool opened)
        {
            base.OnOpenedChanged(opened);
            if(animator != null) animator.SetBool(AnimatorHashID.open_workbench, opened);
            FMODUWE.PlayOneShot(opened ? openSound : closeSound, soundOrigin.position, 1f);

            if(opened)
            {
                StartCoroutine(FadeLight(0f, 10f, 1f));
                gameObject.EnsureComponent<DontLook>();
            }
            else
            {
                StartCoroutine(FadeLight(10f, 0f, 0.4f));
                DestroyImmediate(gameObject.GetComponent<DontLook>());
            }
        }


        public IEnumerator FadeLight(float num1, float num2, float duration)
        {
            float elapsedTime = 0f;

            while(elapsedTime < duration)
            {
                light.intensity = Mathf.Lerp(num1, num2, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            light.intensity = num2;
        }
    }
}