

namespace Ramune.RadiantDepths.Items.Outcrops
{
    internal class SerpentiteOutcrop
    {
        public static Dictionary<BiomeType, float> BiomeSpawnData = new()
        {
            { BiomeType.LostRiverCorridor_Ceiling, 0.5f },
            { BiomeType.LostRiverCorridor_Wall, 0.5f },
            { BiomeType.LostRiverJunction_Ceiling, 0.5f },
            { BiomeType.LostRiverJunction_Wall, 0.5f },
            { BiomeType.BloodKelp_TrenchWall, 0.5f },
            { BiomeType.BloodKelp_CaveWall, 0.5f },
            { BiomeType.BloodKelp_Wall, 0.5f },
        };

        public static Dictionary<TechType, float> ItemDrops = new()
        {
            { TechType.Nickel,  0.33f },
            { TechType.Diamond, 0.33f },
            { TechType.Silver,  0.33f },
            { TechType.Copper,  0.33f },
        };
        
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("SerpentiteOutcrop", "Serpentite outcrop", "An outcrop comprised of pure Serpentite.", false)
            .WithOutcrop("SerpentiteOutcrop", TechType.SandstoneChunk, 1, BiomeSpawnData.AsBiomeData(), ItemDrops)
            .WithAutoUnlock();

        public static void Patch() => Prefab.Register();

        /*
        public static Action<GameObject> ModifyPrefab = go =>
        {
            LoggerUtils.Screen.LogInfo("Additional modify prefab");
            var light = go.EnsureComponent<AreaLight>();
            light.color = new(0f, 1f, 0f);
        };
        */
    }
}