

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
            { TechType.Titanium,  0.40f },
            { TechType.Lithium,   0.40f },
            { TechType.Magnetite, 0.25f },
            { TechType.Diamond,   0.25f },
        };

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("LodestoneOutcrop", "Lodestone outcrop", "An outcrop comprised of pure Lodestone.", false)
            .WithOutcrop("LodestoneOutcrop", TechType.ShaleChunk, 1, BiomeSpawnData.AsBiomeData(), ItemDrops)
            .WithAutoUnlock();

        public static void Patch() => Prefab.Register();
    }
}