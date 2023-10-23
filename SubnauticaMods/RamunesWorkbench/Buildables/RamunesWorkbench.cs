

namespace Ramune.RamunesWorkbench.Buildables
{
    public static class RamunesWorkbench
    {
        public static Texture2D MainTex = Utilities.GetTexture("RamunesWorkbench.TexMain");
        public static Texture2D Illum = Utilities.GetTexture("RamunesWorkbench.TexIllum_1");
        public static CraftTree.Type craftTreeType;

        public static CustomPrefab Prefab = Utilities.CreatePrefab("RamunesWorkbench", "Ramune's workbench", "Used to create items from RamuneNeptune's mods", Utilities.GetSprite(TechType.Workbench)) //"RamunesWorkbench.Sprite"
            .WithPDACategoryAfter(TechGroup.InteriorModules, TechCategory.InteriorModule, TechType.Fabricator)
            .WithJsonRecipe("RamunesWorkbench.Recipe")
            .WithFabricator(out craftTreeType);


        public static void Patch()
        {
            var model = new FabricatorTemplate(Prefab.Info, craftTreeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Workbench,
                ModifyPrefab = go =>
                {
                    Color color = new(191f/ 255f, 116f/ 255f, 255f/255f);

                    CraftTreeHandler.AddTabNode(craftTreeType, "Test", "Test", Utilities.GetSprite(TechType.AcidMushroom));
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Knife, "Test");


                    var renderer = go.GetComponentInChildren<Renderer>();
                    renderer.material.SetTexture(ShaderPropertyID._MainTex, MainTex);
                    renderer.material.SetTexture(ShaderPropertyID._SpecTex, MainTex);
                    renderer.material.SetTexture(ShaderPropertyID._Illum, Illum);
                    renderer.material.EnableKeyword("MARMO_EMISSION");


                    var mono = go.EnsureComponent<ColorMono>();
                    mono.renderer = renderer;


                    ParticleSystem[] particles = go.GetComponentsInChildren<ParticleSystem>(true);
                    if(particles != null)
                    {
                        foreach(var p in particles)
                        {
                            if(p is null) break;
                            p.startColor = color;
                        }
                    }


                    MeshRenderer[] beams = go.GetComponentsInChildren<MeshRenderer>(true);
                    if(beams != null)
                    {
                        foreach(var b in beams)
                        {
                            if(b is null) break;
                            b.material.color = color;
                        }
                    }
                }
            };

            Prefab.SetGameObject(model);
            Prefab.Register();
        }
    }

    public class ColorMono : MonoBehaviour
    {
        public Renderer renderer;
        public float transitionDuration = 3.5f;
        public float elapsedTime = 0.0f;
        public float glowStrength;
        public bool isIncreasing = true;

        public float initial = 2.35f;
        public float result = -0.15f;

        public void Update()
        {
            if(renderer is null) return;

            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / transitionDuration);

            glowStrength = isIncreasing
                ? Mathf.Lerp(result, initial, t)
                : Mathf.Lerp(initial, result, t);

            renderer.material.SetFloat(ShaderPropertyID._GlowStrength, glowStrength);

            if(elapsedTime >= transitionDuration)
            {
                isIncreasing = !isIncreasing;
                elapsedTime = 0.0f;
            }
        }
    }
}