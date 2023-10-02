

namespace Ramune.RadiantBlade.Monos
{
    public partial class RadiantBlade : HeatBlade
    {
        public static GameObject AssetSeismicDebris;
        public MeshRenderer renderer;
        public EnergyMixin energy;


        public void Start()
        {
            renderer = GetComponentInChildren<MeshRenderer>();
            energy = GetComponent<EnergyMixin>();

            attackDist = 10000f;
            damage = 10000f;

            CoroutineHost.StartCoroutine((FetchExplosivePrefab()));
        }

        public IEnumerator FetchExplosivePrefab()
        {
            yield return new WaitUntil(() => Player.main);

            var task = GetPrefabForTechTypeAsync(TechType.Crash);
            yield return task;

            var result = task.GetResult();
            var crash = result.GetComponentInChildren<Crash>();

            AssetSeismicDebris = crash.detonateParticlePrefab;

            yield break;
        }
    }
}