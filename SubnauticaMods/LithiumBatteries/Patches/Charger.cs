
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
            if (!___slots.TryGetValue(slot, out SlotDefinition slotDefinition))
                return;

            GameObject battery = slotDefinition.battery; // Get the battery GameObject from the slot definition
            Pickupable pickupable = item.item;

            if(battery != null && pickupable != null)
            {
                GameObject model;

                switch (__instance)
                {
                    case BatteryCharger:
                        model = pickupable.gameObject.transform.Find("model/battery_01")?.gameObject
                            ?? pickupable.gameObject.transform.Find("model/battery_ion")?.gameObject;

                        if(model != null && model.TryGetComponent(out Renderer ModelRenderer_0) && battery.TryGetComponent(out Renderer ChargerRenderer_0))
                            ApplyTextureBattery(item.item.name, ChargerRenderer_0, Items.LithiumBattery.Texture, Items.LithiumBattery.TextureIllum);

                        break;

                    case PowerCellCharger:
                        model = pickupable.gameObject.FindChild("engine_power_cell_ion");

                        //if(model != null && model.TryGetComponent(out Renderer ModelRenderer_1) && battery.TryGetComponent(out Renderer ChargerRenderer_1) && model.TryGetComponent(out MeshFilter ModelMeshFilter_1) && battery.TryGetComponent(out MeshFilter BatteryMeshFilter_1))
                            //ApplyPowerCellTexture(item.item.name, ChargerRenderer_1, ModelMeshFilter_1, BatteryMeshFilter_1);

                        break;
                }
            }
        }


        public static void ApplyTextureBattery(string itemName, Renderer chargerRenderer, Texture mainTex, Texture illumTex)
        {
            switch(itemName)
            {
                case "LithiumBattery(Clone)":
                    chargerRenderer.material.SetTexture(ShaderPropertyID._MainTex, mainTex);
                    chargerRenderer.material.SetTexture(ShaderPropertyID._Illum, illumTex);
                    break;

                case "PrecursorIonBattery(Clone)":
                    chargerRenderer.material.SetTexture(ShaderPropertyID._MainTex, mainTex);
                    chargerRenderer.material.SetTexture(ShaderPropertyID._Illum, illumTex);
                    break;

                case "Battery(Clone)":
                    chargerRenderer.material.SetTexture(ShaderPropertyID._MainTex, mainTex);
                    chargerRenderer.material.SetTexture(ShaderPropertyID._Illum, illumTex);
                    break;
            }
        }


        public static void ApplyPowerCellTexture(string itemName, Renderer chargerRenderer, MeshRenderer modelRenderer, MeshFilter batteryMeshFilter)
        {
            batteryMeshFilter.mesh = modelMeshFilter.mesh;
            chargerRenderer.material.CopyPropertiesFromMaterial(modelMeshFilter.material);

            switch (itemName)
            {
                case "LithiumPowerCell(Clone)":
                    chargerRenderer.material.SetTexture(ShaderPropertyID._MainTex, Items.LithiumPowerCell.Texture);
                    break;
            }
        }
    }
}   