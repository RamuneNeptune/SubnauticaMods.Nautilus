

namespace Ramune.RadiantDepths.Items.Resources
{
    public static class Brimstone
    {    
        public static CustomPrefab Prefab = ItemUtils.CreateResource("Brimstone", "Brimstone", "It's a Brimstone, yoooooo", TechType.Nickel, TechCategory.BasicMaterials);

        public static void Patch() => Prefab.Register();
    }
}