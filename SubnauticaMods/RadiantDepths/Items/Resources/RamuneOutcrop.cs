

namespace Ramune.RadiantDepths.Items.Resources
{
    public static class RamuneOutcrop
    {
        public static Dictionary<BiomeType, float> BiomeSpawnData = new()
        {
            { BiomeType.Dunes_ThermalVent, 0.5f },
            { BiomeType.Dunes_ThermalVent_Rock, 0.5f },
            { BiomeType.Dunes_ThermalVent_Grass, 0.5f },
            { BiomeType.BonesField_ThermalVent, 0.5f },
            { BiomeType.GrandReef_ThermalVent, 0.5f },
            { BiomeType.LostRiverCorridor_ThermalVents, 0.5f },
            { BiomeType.LostRiverJunction_ThermalVent, 0.5f },
            { BiomeType.Mountains_ThermalVent, 0.5f }
        };

        public static Dictionary<TechType, float> ItemDrops = new()
        {
            { TechType.Quartz, 0.50f },
            { TechType.Silver, 0.50f },
            { TechType.Nickel, 0.25f },
            { TechType.Marki2, 0.10f },
        };

        public static CustomPrefab Prefab = ItemUtils.CreateOutcrop("RamuneOutcrop", "Ramune outcrop", "An outcrop comprised of pure Ramune.", TechType.SandstoneChunk, 1, ItemUtils.ConvertToBiomeData(BiomeSpawnData), ItemDrops);

        public static void Patch() => Prefab.Register();
    }
}