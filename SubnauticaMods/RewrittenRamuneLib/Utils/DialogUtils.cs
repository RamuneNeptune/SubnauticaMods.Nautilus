

namespace RamuneLib.Utils
{
    public static class DialogUtils
    {
        public class BasicMenuComponent : uGUI_InputGroup, uGUI_IButtonReceiver
        {
            public void Start() => this.Select();

            public bool OnButtonDown(GameInput.Button button)
            {
                if(button == GameInput.Button.UICancel && IngameMenu.main.CanClose())
                {
                    Close();
                    GameInput.ClearInput();
                    return true;
                }
                return false;
            }

            public void Close()
            {
                Deselect();
                Destroy(gameObject);
            }

            public void OnEnable()
            {
                uGUI_LegendBar.ClearButtons();
                //uGUI_LegendBar.ChangeButton(0, uGUI.FormatButton(GameInput.Button.UICancel, false, " / ", true), Language.main.GetFormat("Back"));
                //uGUI_LegendBar.ChangeButton(1, uGUI.FormatButton(GameInput.Button.UISubmit, false, " / ", true), Language.main.GetFormat("ItemSelectorSelect"));
            }

            public override void OnDisable()
            {
                base.OnDisable();
                uGUI_LegendBar.ClearButtons();
                Destroy(gameObject);
            }

            public override void OnSelect(bool lockMovement)
            {
                base.OnSelect(lockMovement);
                gameObject.SetActive(true);
                FreezeTime.Begin(FreezeTime.Id.IngameMenu);
                UWE.Utils.lockCursor = false;
            }

            public override void OnDeselect()
            {
                base.OnDeselect();
                FreezeTime.End(FreezeTime.Id.IngameMenu);
                Destroy(gameObject);
            }
        }
    }
}