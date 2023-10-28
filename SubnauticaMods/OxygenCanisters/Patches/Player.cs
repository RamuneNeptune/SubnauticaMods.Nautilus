

namespace Ramune.OxygenCanisters.Patches
{
    [HarmonyPatch(typeof(Player))]
    public static class PlayerPatch
    {
        [HarmonyPatch(nameof(Player.Update)), HarmonyPostfix]
        public static void Update(Player __instance)
        {
            if(!Input.anyKeyDown) 
                return;

            if(Cursor.visible)
                return;

            var inventory = Inventory.main.container;
            var hasCanister = inventory.Contains(Items.OxygenCanister.Prefab.Info.TechType);

            if(!hasCanister) 
                return;

            if(!Input.GetKeyDown(KeyCode.V))
                return;

            if(Player.main.IsInside())
            {
                LoggerUtils.LogSubtitle("Cannot consume oxygen canister while inside breathable space", 5f, 0.05f);
                return;
            }

            var canisters = inventory.GetItems(Items.OxygenCanister.Prefab.Info.TechType);
            Inventory.main.ExecuteItemAction(ItemAction.Eat, canisters.FirstOrDefault());

            var count = canisters.Count == 1 ? 0 : canisters.Count;
            LoggerUtils.LogSubtitle($"Received +35 oxygen, canisters remaining: {count}", 5f, 0.05f);
        }
    }
}