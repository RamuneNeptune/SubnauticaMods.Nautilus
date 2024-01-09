

namespace Ramune.RadiantDepths.Items.Outcrops
{
    internal class SiltstoneOutcrop
    {
        public static Dictionary<BiomeType, float> BiomeSpawnData = new()
        {
            { BiomeType.SafeShallows_Wall, 0.1f },
            { BiomeType.SafeShallows_CaveWall, 0.1f },
            { BiomeType.MushroomForest_RockWall, 0.5f },
            { BiomeType.MushroomForest_CaveWall, 0.5f },
            { BiomeType.MushroomForest_MushroomTreeTrunk, 0.5f },
            { BiomeType.MushroomForest_GiantTreeInteriorWall, 0.5f },
            { BiomeType.MushroomForest_GiantTreeExterior, 0.5f },
        };

        public static Dictionary<TechType, float> ItemDrops = new()
        {
            { TechType.Titanium, 0.50f },
            { TechType.Lithium,  0.40f },
            { TechType.Copper,   0.30f },
            { TechType.Silver,   0.20f },
        };

        public static CustomPrefab Prefab = ItemUtils.CreateOutcrop("SiltstoneOutcrop", "Siltstone outcrop", "An outcrop comprised of pure Siltstone.", TechType.LimestoneChunk, 1, ItemUtils.ConvertToBiomeData(BiomeSpawnData), ItemDrops);

        public static void Patch() => Prefab.Register();
    }
}