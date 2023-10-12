

namespace Ramune.RadiantBlade.Items
{
    public static class RainbowSuit
    {
        public static Texture2D TextureMain = Utilities.GetTexture("RamuneSuit.TextureMain");

        public static CustomPrefab Prefab = Utilities.CreatePrefab("RamuneSuit", "Ramune suit", "A ramune suit, because it's amazing.", Utilities.GetSprite("RamuneSuit.Sprite"))
            .WithJsonRecipe("RamuneSuit.Recipe", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorEquipment)
            .WithUnlock(TechType.ReinforcedDiveSuit)
            .WithEquipment(EquipmentType.Body);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.ReinforcedDiveSuit);

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public static class RainbowGloves
    {
        public static Texture2D TextureMain = Utilities.GetTexture("RamuneGloves.TextureMain");

        public static CustomPrefab Prefab = Utilities.CreatePrefab("RamuneGloves", "Ramune gloves", "Ramune gloves, because they're amazing.", Utilities.GetSprite("RamuneGloves.Sprite"))
            .WithJsonRecipe("RamuneGloves.Recipe", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorEquipment)
            .WithUnlock(TechType.ReinforcedGloves)
            .WithEquipment(EquipmentType.Gloves);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.ReinforcedGloves);

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}
