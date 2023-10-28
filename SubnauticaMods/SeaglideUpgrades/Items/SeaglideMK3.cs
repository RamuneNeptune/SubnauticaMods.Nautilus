

namespace Ramune.SeaglideUpgrades.Items
{
    public static class SeaglideMK3
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("SeaglideMK3", "Seaglide <color=#f81117>MK3</color>", "SPEED: +40%\nMay need to re-equip to apply speed", ImageUtils.GetSprite("SeaglideMK3.Sprite"))
            .WithJsonRecipe("SeaglideMK3.Recipe")
            .WithEquipment(EquipmentType.Hand)
            .WithUnlock(TechType.Seaglide)
            .WithSize(2, 3);

        public static Texture2D TextureMain = ImageUtils.GetTexture("SeaglideMK3.Tex");
        public static Texture2D TextureIllum = ImageUtils.GetTexture("SeaglideMK3.TexIllum");

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.Seaglide)
            {
                ModifyPrefab = go =>
                {
                    var component = go.EnsureComponent<Monos.UpgradedSeaglide>();

                    component.acceleration = 58f;
                    component.speed = 58f;
                    component.isMk3 = true;

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