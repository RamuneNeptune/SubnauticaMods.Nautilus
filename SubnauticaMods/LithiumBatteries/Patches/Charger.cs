
using static Charger;


namespace Ramune.LithiumBatteries.Patches
{
    [HarmonyPatch(typeof(Charger))]
    public class ChargerPatches
    {
        public static Texture2D BatteryTexture => ImageUtils.GetTexture("BatteryTexture");
        public static Texture2D BatteryTextureIllum => ImageUtils.GetTexture("BatteryTextureIllum");
        public static Texture2D IonBatteryTexture => ImageUtils.GetTexture("IonBatteryTexture");
        public static Texture2D IonBatteryTextureIllum => ImageUtils.GetTexture("IonBatteryTextureIllum");


        [HarmonyPatch(nameof(Charger.OnEquip)), HarmonyPostfix]
        public static void OnEquip(Charger __instance, string slot, InventoryItem item, Dictionary<string, SlotDefinition> ___slots)
        {
            if(___slots.TryGetValue(slot, out SlotDefinition slotDefinition))
            {
                GameObject battery = slotDefinition.battery;  // Get the battery GameObject from the slot definition
                Pickupable pickupable = item.item;  // Get the Pickupable component from the item

                if(battery != null && pickupable != null)  // If both battery and pickupable exist
                {
                    GameObject model;

                    switch(__instance)
                    {
                        case BatteryCharger _:
                            model = pickupable.gameObject.transform.Find("model/battery_01")?.gameObject ?? pickupable.gameObject.transform.Find("model/battery_ion")?.gameObject;

                            if(model != null && model.TryGetComponent(out Renderer ModelRenderer_0) && battery.TryGetComponent(out Renderer ChargerRenderer_0))
                            {
                                switch(item.item.name)
                                {
                                    case "LithiumBattery(Clone)":
                                        ChargerRenderer_0.material.SetTexture(ShaderPropertyID._MainTex, Items.LithiumBattery.Texture);
                                        ChargerRenderer_0.material.SetTexture(ShaderPropertyID._Illum, Items.LithiumBattery.TextureIllum);
                                        break;

                                    case "PrecursorIonBattery(Clone)":
                                        ChargerRenderer_0.material.SetTexture(ShaderPropertyID._MainTex, BatteryTexture);
                                        ChargerRenderer_0.material.SetTexture(ShaderPropertyID._Illum, BatteryTextureIllum);
                                        break;

                                    case "Battery(Clone)":
                                        ChargerRenderer_0.material.SetTexture(ShaderPropertyID._MainTex, IonBatteryTexture);
                                        ChargerRenderer_0.material.SetTexture(ShaderPropertyID._Illum, IonBatteryTextureIllum);
                                        break;
                                }
                            }
                            break;

                        case PowerCellCharger _:
                            model = pickupable.gameObject.FindChild("engine_power_cell_ion");

                            if(model != null && model.TryGetComponent(out Renderer ModelRenderer_1) && battery.TryGetComponent(out Renderer ChargerRenderer_1) && model.TryGetComponent(out MeshFilter ModelMeshFilter_1) && battery.TryGetComponent(out MeshFilter BatteryMeshFilter_1))
                            {
                                BatteryMeshFilter_1.mesh = ModelMeshFilter_1.mesh;
                                ChargerRenderer_1.material.CopyPropertiesFromMaterial(ModelRenderer_1.material);

                                switch(item.item.name)
                                {
                                    case "LithiumPowerCell(Clone)":
                                        ChargerRenderer_1.material.SetTexture(ShaderPropertyID._MainTex, Items.LithiumPowerCell.Texture);
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}