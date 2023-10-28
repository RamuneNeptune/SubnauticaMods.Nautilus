

namespace Ramune.OxygenCanisters.Items
{
    public static class LargeOxygenCaniser
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("LargeOxygenCanister", "Large oxygen canister", $"O2: +{OxygenCanisters.config.largeCanisterCapacity}\nEncapsulated oxygen from the Bladderfish.", ImageUtils.GetSprite("LargeOxygenCanister"))
            .WithPDACategory(TechGroup.Personal, TechCategory.Equipment)
            .WithJsonRecipe("LargeOxygenCanister")
            .WithUnlock(TechType.None);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.FilteredWater)
            {
                ModifyPrefab = go =>
                {
                    //CraftDataHandler.SetEatingSound(Prefab.Info.TechType, "event:/player/bubbles");
                    SurvivalHandler.GiveOxygenOnConsume(Prefab.Info.TechType, OxygenCanisters.config.largeCanisterCapacity, false);

                    var renderer = go.GetComponentInChildren<MeshRenderer>(true);
                    renderer.material.SetTexture(ShaderPropertyID._MainTex, OxygenCanister.Texture);
                    renderer.material.SetTexture(ShaderPropertyID._SpecTex, OxygenCanister.Texture);
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}