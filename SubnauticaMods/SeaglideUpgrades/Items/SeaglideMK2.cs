

namespace Ramune.SeaglideUpgrades.Items
{
    public static class SeaglideMK2
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("SeaglideMK2", "Seaglide <color=#bde170>MK2</color>", "SPEED: +25%\nConverts torque into thrust underwater via propeller.", ImageUtils.GetSprite("SeaglideMK2.Sprite"))
            .WithJsonRecipe("SeaglideMK2.Recipe")
            .WithEquipment(EquipmentType.Hand)
            .WithUnlock(TechType.Seaglide)
            .WithSize(2, 3);

        public static Texture2D TextureMain = ImageUtils.GetTexture("SeaglideMK2.Tex");
        public static Texture2D TextureIllum = ImageUtils.GetTexture("SeaglideMK2.TexIllum");

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.Seaglide)
            {
                ModifyPrefab = go =>
                {
                    var colorizer = go.EnsureComponent<Monos.SeaglideLightColorizer>();
                    colorizer.thisSeaglide = Monos.SeaglideLightColorizer.UpgradedSeaglide.MK2;

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