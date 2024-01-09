

namespace Ramune.RadiantDepths.Items.Outcrops
{
    internal class GeyseriteOutcrop
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
            { Brimstone.Prefab.Info.TechType, 0.20f },
            { TechType.Gold,                  0.40f },
            { TechType.Lead,                  0.40f },
        };

        public static CustomPrefab Prefab = ItemUtils.CreateOutcrop("GeyseriteOutcrop", "Geyserite outcrop", "An outcrop comprised of pure Geyserite.", TechType.ShaleChunk, 1, ItemUtils.ConvertToBiomeData(BiomeSpawnData), ItemDrops);

        public static void Patch() => Prefab.Register();
    }
}