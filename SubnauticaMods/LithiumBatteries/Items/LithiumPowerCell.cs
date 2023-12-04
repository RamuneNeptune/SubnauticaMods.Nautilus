

namespace Ramune.LithiumBatteries.Items
{
    public static class LithiumPowerCell
    {
        public static Texture2D Texture = ImageUtils.GetTexture("LithiumPowerCellTexture");
        public static Texture2D TextureIllum = ImageUtils.GetTexture("LithiumPowerCellTextureIllum");

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("LithiumPowerCell", "Lithium power cell", "Power cell optimized with a high-efficiency lithium-ion core for extended capacity.", ImageUtils.GetSprite("LithiumPowerCell"))
            .WithPDACategory(TechGroup.Workbench, TechCategory.Workbench)
            .WithEquipment(EquipmentType.PowerCellCharger)
            .WithJsonRecipe("LithiumPowerCell");

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.PowerCell)
            {
                ModifyPrefab = go =>
                {
                    var battery = go.EnsureComponent<Battery>();
                    battery._capacity = 400f;

                    var renderer = go.GetComponentInChildren<MeshRenderer>(true);
                    renderer.material.SetTexture(ShaderPropertyID._MainTex, Texture);
                    renderer.material.SetTexture(ShaderPropertyID._Illum, TextureIllum);
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}