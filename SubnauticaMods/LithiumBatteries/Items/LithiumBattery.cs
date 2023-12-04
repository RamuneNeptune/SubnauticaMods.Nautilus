

namespace Ramune.LithiumBatteries.Items
{
    public static class LithiumBattery
    {
        public static Texture2D Texture = ImageUtils.GetTexture("LithiumBatteryTexture");
        public static Texture2D TextureIllum = ImageUtils.GetTexture("LithiumBatteryTextureIllum");

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("LithiumBattery", "Lithium battery", "Battery optimized with a high-efficiency lithium-ion core for extended capacity.", ImageUtils.GetSprite("LithiumBattery"))
            .WithPDACategory(TechGroup.Workbench, TechCategory.Workbench)
            .WithEquipment(EquipmentType.BatteryCharger)
            .WithJsonRecipe("LithiumBattery");

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.Battery)
            {
                ModifyPrefab = go =>
                {
                    var battery = go.EnsureComponent<Battery>();
                    battery._capacity = 200f;

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