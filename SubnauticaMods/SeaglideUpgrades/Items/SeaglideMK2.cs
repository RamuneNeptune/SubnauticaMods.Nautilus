

using Ramune.SeaglideUpgrades.Mono;

namespace Ramune.SeaglideUpgrades.Items
{
    public static class SeaglideMK2
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("SeaglideMK2", "Seaglide <color=#bde170>MK2</color>", "SPEED: +25%\nMay need to re-equip to apply speed", Utilities.GetSprite("SeaglideMK2.Sprite"))
            .WithJsonRecipe("SeaglideMK2.Recipe", CraftTree.Type.Workbench, "Seaglide")
            .WithUnlock(TechType.Seaglide);

        public static Texture2D TextureMain = Utilities.GetTexture("SeaglideMK2.Tex");
        public static Texture2D TextureIllum = Utilities.GetTexture("SeaglideMK2.TexIllum");

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