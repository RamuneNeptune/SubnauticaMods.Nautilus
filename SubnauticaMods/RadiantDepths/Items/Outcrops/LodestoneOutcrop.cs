

namespace Ramune.RadiantDepths.Items.Outcrops
{
    internal class LodestoneOutcrop
    {
        public static Dictionary<BiomeType, float> BiomeSpawnData = new()
        {
            { BiomeType.JellyshroomCaves_CaveFloor, 0.5f },
            { BiomeType.JellyshroomCaves_CaveWall, 0.5f },
        };

        public static Dictionary<TechType, float> ItemDrops = new()
        {
            { TechType.Titanium,  0.50f },
            { TechType.Lithium,   0.50f },
            { TechType.Magnetite, 0.25f },
            { TechType.Diamond,   0.25f },
        };

        public static CustomPrefab Prefab = ItemUtils.CreateOutcrop("LodestoneOutcrop", "Lodestone outcrop", "An outcrop comprised of pure Lodestone.", TechType.ShaleChunk, 1, ItemUtils.ConvertToBiomeData(BiomeSpawnData), ItemDrops);

        public static void Patch() => Prefab.Register();
    }
}