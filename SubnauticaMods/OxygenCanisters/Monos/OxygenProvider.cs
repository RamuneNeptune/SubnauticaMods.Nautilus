

namespace Ramune.OxygenCanisters.Monos
{
    public class OxygenProvider : MonoBehaviour
    {
        public ItemsContainer inv;

        public void Start()
        {
            inv = Inventory.main._container;
        }

        public void Update()
        {
            if(GameInput.GetKeyDown(KeyCode.V) && !Cursor.visible && !Player.main.IsInsidePoweredVehicle() && !Player.main.IsInside())
            {
                if(GameModeUtils.currentGameMode != GameModeOption.Survival && GameModeUtils.currentGameMode != GameModeOption.Hardcore)
                {
                    ErrorMessage.AddError("<color=#fbc361><b>WARNING:</b></color> Must be in survival or hardcore!");
                    return;
                }

                if(!inv.Contains(Items.OxygenCanister.Prefab.Info.TechType)) 
                { 
                    ErrorMessage.AddError("<color=#fbc361><b>WARNING:</b></color> Must have an Oxygen Canister available!");
                    return;
                };

                var canisters = inv.GetItems(Items.OxygenCanister.Prefab.Info.TechType);

                Inventory.main.ExecuteItemAction(ItemAction.Eat, canisters.FirstOrDefault());
                ErrorMessage.AddError($"<color=#fbc361>1x</color> Oxygen Canister\n<color=#fbc361>+35</color> Oxygen ({canisters.Count - 1} remaining)");
            }


            if(GameInput.GetKeyDown(KeyCode.B) && !Cursor.visible && !Player.main.IsInsidePoweredVehicle() && !Player.main.IsInside())
            {
                if(GameModeUtils.currentGameMode != GameModeOption.Survival && GameModeUtils.currentGameMode != GameModeOption.Hardcore)
                {
                    ErrorMessage.AddError("<color=#fbc361><b>WARNING:</b></color> Must be in survival or hardcore!");
                    return;
                }

                if(!inv.Contains(Items.OxygenCanister.Prefab.Info.TechType)) 
                { 
                    ErrorMessage.AddError("<color=#fbc361><b>WARNING:</b></color> Must have a Large Oxygen Canister available!");
                    return;
                };

                var canisters = inv.GetItems(Items.OxygenCanister.Prefab.Info.TechType);

                Inventory.main.ExecuteItemAction(ItemAction.Eat, canisters.FirstOrDefault());
                ErrorMessage.AddError($"<color=#fbc361>1x</color> Large Oxygen Canister\n<color=#fbc361>+35</color> Oxygen ({canisters.Count - 1} remaining)");
            }
        }
    }
}