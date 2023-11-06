

namespace Ramune.RadiantBlade.Items
{
    public static class RadiantBlade
    {            
        public static Texture2D TextureMain = ImageUtils.GetTexture("RadiantBlade.TextureMain");
        public static Texture2D TextureIllum = ImageUtils.GetTexture("RadiantBlade.TextureIllum");

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("RadiantBlade", "Radiant blade", "A radiant blade, because it's radiant.", ImageUtils.GetSprite("RadiantBlade.Sprite"))
            .WithJsonRecipe("RadiantBlade", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorMachines)
            .WithEquipment(EquipmentType.Hand)
            .WithUnlock(TechType.Knife);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.HeatBlade)
            {
                ModifyPrefab = go =>
                {   
                    var heatblade = go.GetComponent<HeatBlade>();
                    var radiantBlade = go.EnsureComponent<Monos.RadiantBlade>().CopyComponent(heatblade);
                    UnityEngine.Object.DestroyImmediate(heatblade);
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}