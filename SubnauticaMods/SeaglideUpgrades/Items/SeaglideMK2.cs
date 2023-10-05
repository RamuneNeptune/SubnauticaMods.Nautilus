

namespace Ramune.SeaglideUpgrades.Items
{
    public static class SeaglideMK2
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("SeaglideMK2", "Seaglide <color=#bde170>MK2</color>", "SPEED: +25%\nMay need to re-equip to apply speed", Utilities.GetSprite("SeaglideMK2.Sprite"))
            .WithPDACategoryAfter(TechGroup.Workbench, TechCategory.Workbench, TechType.RepulsionCannon)
            .WithJsonRecipe("SeaglideMK2.Recipe", CraftTree.Type.Workbench, 5.5f, "Seaglides")
            .WithEquipment(EquipmentType.Hand)
            .WithUnlock(TechType.Seaglide)
            .WithSize(2, 3);

        public static Texture2D TextureMain = Utilities.GetTexture("SeaglideMK2.Tex");
        public static Texture2D TextureIllum = Utilities.GetTexture("SeaglideMK2.TexIllum");

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.Seaglide)
            {
                ModifyPrefab = go =>
                {
                    var component = go.EnsureComponent<Monos.UpgradedSeaglide>();

                    component.acceleration = 50f;
                    component.speed = 50f;
                    component.isMk2 = true;

                    var renderers = go.GetComponentsInChildren<SkinnedMeshRenderer>(true);

                    if(SeaglideUpgrades.config.glossyBool) renderers.ForEach(x => x.material.SetTexture(ShaderPropertyID._SpecTex, TextureMain));
                    renderers.ForEach(x => x.material.SetTexture(ShaderPropertyID._MainTex, TextureMain));
                    renderers.ForEach(x => x.material.SetTexture(ShaderPropertyID._Illum, TextureIllum));
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}