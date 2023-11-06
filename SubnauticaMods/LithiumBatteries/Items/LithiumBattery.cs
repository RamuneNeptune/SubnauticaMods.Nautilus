

namespace Ramune.LithiumBatteries.Items
{
    public static class LithiumBattery
    {
        public static Texture2D Texture = ImageUtils.GetTexture("LithiumBatteryTexture");
        public static Texture2D TextureIllum = ImageUtils.GetTexture("LithiumBatteryTextureIllum");

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("LithiumBattery", "Lithium battery", "A Lithium battery that can hold 200 power.", ImageUtils.GetSprite("LithiumBattery"))
            .WithEquipment(EquipmentType.BatteryCharger)
            .WithJsonRecipe("LithiumBattery");
        //.WithPDACategory();


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