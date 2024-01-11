

namespace Ramune.RadiantDepths.Items.Tools.RadiantBlade
{
    public static class RadiantBlade
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("RadiantBlade", "Radiant blade", "Cooks and sterilizes small organisms for immediate consumption.\n\nDAMAGE: +100%\nRANGE: +50%.", false)
            .WithJsonRecipe("RadiantBlade", RadiantFabricator.CraftTreeType, RadiantFabricator.Tabs.Tools)
            .WithPDACategory(TechGroup.Personal, TechCategory.Tools)
            .WithAutoUnlock();

        public static void Patch()
        {
            Prefab.SetEquipment(EquipmentType.Hand).WithQuickSlotType(QuickSlotType.Selectable);

            var clone = new CloneTemplate(Prefab.Info, TechType.HeatBlade)
            {
                ModifyPrefab = go =>
                {
                    var energy = Utility.PrefabUtils.AddEnergyMixin(go, Prefab.Id() + "EnergySlot", RadiantCube.Prefab.Info.TechType, new() { RadiantCube.Prefab.Info.TechType });
                    energy.allowBatteryReplacement = true;

                    var heatBlade = go.GetComponent<HeatBlade>();
                    var radiantBlade = go.EnsureComponent<RadiantBladeBehaviour>().CopyComponent(heatBlade);
                    UnityEngine.Object.DestroyImmediate(heatBlade);

                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer, true))
                        throw new MissingComponentException($"Couldn't find renderer while setting up {Prefab.Id()}");

                    renderer
                        .SetTexture(TextureType.Main, ImageUtils.GetTexture(Prefab.Id() + "Texture"))
                        .SetTexture(TextureType.Specular, ImageUtils.GetTexture(Prefab.Id() + "Texture"))
                        .SetTexture(TextureType.Illum, ImageUtils.GetTexture(Prefab.Id() + "Illum"))
                        .material.SetColor(ShaderPropertyID._GlowColor, new(0.67f, 0.1f, 0.85f, 0.4f));
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}