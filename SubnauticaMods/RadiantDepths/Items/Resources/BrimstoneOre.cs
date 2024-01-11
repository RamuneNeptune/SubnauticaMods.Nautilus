

namespace Ramune.RadiantDepths.Items.Resources
{
    public static class BrimstoneOre
    {    
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("BrimstoneOre", "Brimstone ore", "GsH. Volatile mineral found within Geyserite Outcrops. Rich in sulfur content.", false)
            .WithResource(TechType.Nickel, TechCategory.BasicMaterials)
            .WithAutoUnlock();

        public static void Patch() => Prefab.Register();
    }
}