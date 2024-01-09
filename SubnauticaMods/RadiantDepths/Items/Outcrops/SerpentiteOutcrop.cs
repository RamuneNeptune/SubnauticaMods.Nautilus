

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
        };

        public static CustomPrefab Prefab = ItemUtils.CreateOutcrop("SerpentiteOutcrop", "Serpentite outcrop", "An outcrop comprised of pure Serpentite.", TechType.SandstoneChunk, 1, ItemUtils.ConvertToBiomeData(BiomeSpawnData), ItemDrops);

        public static void Patch() => Prefab.Register();
    }
}