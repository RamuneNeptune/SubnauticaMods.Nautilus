

namespace Ramune.OxygenCanisters.Items
{
    public static class OxygenCanister
    {
        public static Texture2D Texture = ImageUtils.GetTexture("OxygenCanister.Texture1");

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("OxygenCanister", "Oxygen canister", $"O2: +{OxygenCanisters.config.canisterCapacity}\nEncapsulated oxygen from the Bladderfish.", ImageUtils.GetSprite("OxygenCanister"))
            .WithPDACategory(TechGroup.Personal, TechCategory.Equipment)
            .WithJsonRecipe("OxygenCanister")
            .WithUnlock(TechType.None);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.FilteredWater)
            {
                ModifyPrefab = go => 
                {
                    //CraftDataHandler.SetEatingSound(Prefab.Info.TechType, "event:/player/bubbles");
                    SurvivalHandler.GiveOxygenOnConsume(Prefab.Info.TechType, OxygenCanisters.config.canisterCapacity, false);

                    var renderer = go.GetComponentInChildren<MeshRenderer>(true);
                    renderer.material.SetTexture(ShaderPropertyID._MainTex, Texture);
                    renderer.material.SetTexture(ShaderPropertyID._SpecTex, Texture);
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}