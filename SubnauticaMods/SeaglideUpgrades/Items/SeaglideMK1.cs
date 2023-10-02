

using Ramune.SeaglideUpgrades.Mono;

namespace Ramune.SeaglideUpgrades.Items
{
    public static class SeaglideMK1
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("SeaglideMK1", "Seaglide <color=#03f0f1>MK1</color>", "SPEED: +15%\nMay need to re-equip to apply speed", Utilities.GetSprite("SeaglideMK1.Sprite"))
            .WithJsonRecipe("SeaglideMK1.Recipe", CraftTree.Type.Workbench, "Seaglide")
            .WithUnlock(TechType.Seaglide);

        public static Texture2D TextureMain = Utilities.GetTexture("SeaglideMK1.Tex");
        public static Texture2D TextureIllum = Utilities.GetTexture("SeaglideMK1.TexIllum");

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.Seaglide)
            {
                ModifyPrefab = go =>
                {
                    var component = go.EnsureComponent<UpgradedSeaglide>();

                    component.acceleration = 50f;
                    component.speed = 50f;

                    var renderers = go.GetComponentsInChildren<SkinnedMeshRenderer>(true);

                    renderers.ForEach(x => x.material.SetTexture(ShaderPropertyID._MainTex, TextureMain));
                    renderers.ForEach(x => x.material.SetTexture(ShaderPropertyID._Illum, TextureIllum));
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}