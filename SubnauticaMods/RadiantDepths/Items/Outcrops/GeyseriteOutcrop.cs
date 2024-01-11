

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
            { BrimstoneOre.Prefab.Info.TechType, 0.20f },
            { TechType.Gold,                     0.30f },
            { TechType.Lead,                     0.30f },
        };

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("GeyseriteOutcrop", "Geyserite outcrop", "An outcrop comprised of pure Geyserite.", false)
            .WithOutcrop("GeyseriteOutcrop", TechType.ShaleChunk, 1, BiomeSpawnData.AsBiomeData(), ItemDrops)
            .WithAutoUnlock();

        public static void Patch() => Prefab.Register();
    }
}