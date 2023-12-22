

namespace Ramune.SeaglideUpgrades.Items
{
    public static class SeaglideMK1
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("SeaglideMK1", "Seaglide <color=#03f0f1>MK1</color>", "SPEED: +15%\nConverts torque into thrust underwater via propeller.", ImageUtils.GetSprite("SeaglideMK1.Sprite"))
            .WithJsonRecipe("SeaglideMK1.Recipe")
            .WithEquipment(EquipmentType.Hand)
            .WithUnlock(TechType.Seaglide)
            .WithSize(2, 3);

        public static Texture2D TextureMain = ImageUtils.GetTexture("SeaglideMK1.Tex");
        public static Texture2D TextureIllum = ImageUtils.GetTexture("SeaglideMK1.TexIllum");

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.Seaglide)
            {
                ModifyPrefab = go =>
                {
                    var colorizer = go.EnsureComponent<Monos.SeaglideLightColorizer>();
                    colorizer.thisSeaglide = Monos.SeaglideLightColorizer.UpgradedSeaglide.MK1;

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