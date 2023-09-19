

namespace Ramune.RadiantBlade.Items
{
    public static class RadiantBlade
    {            
        public static Texture2D TextureMain = Utilities.GetTexture("RadiantBlade.TextureMain");
        public static Texture2D TextureIllum = Utilities.GetTexture("RadiantBlade.TextureIllum");

        public static CustomPrefab Prefab = Utilities.CreatePrefab("RadiantBlade", "Radiant blade", "A radiant blade, cause it's radiant.", Utilities.GetSprite("RadiantBlade.Sprite"))
            .WithJsonRecipe("RadiantBlade", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorMachines)
            .WithEquipment(EquipmentType.Hand)
            .WithUnlock(TechType.Knife);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.HeatBlade)
            {
                ModifyPrefab = go =>
                {
                    var energy = PrefabUtils.AddEnergyMixin(go, "RadiantBladeEnergySlot", TechType.Battery, new() { TechType.Battery });
                    energy.allowBatteryReplacement = true;

                    var renderer = go.GetComponentInChildren<MeshRenderer>(true);
                    foreach (var m in renderer.materials)
                    {
                        m.SetTexture(ShaderPropertyID._MainTex, TextureMain);
                        m.SetTexture(ShaderPropertyID._SpecTex, TextureMain);
                        m.SetTexture(ShaderPropertyID._Illum, TextureIllum);
                        m.SetColor(ShaderPropertyID._GlowColor, new Color(0.67f, 0.1f, 0.85f, 0.4f));
                    }

                    var heatblade = go.GetComponent<HeatBlade>();
                    var radiantblade = go.EnsureComponent<Monos.RadiantBlade>().CopyComponent(heatblade);
                    UnityEngine.Object.DestroyImmediate(heatblade);
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}