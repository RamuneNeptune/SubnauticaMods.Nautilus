

namespace Ramune.LeviathanRadarChip.Monos
{
    public static class BasicMenu
    {
        public static GameObject MenuClone;
        public static Button templateButton;
        public static bool isFirst = true;

        public static void ShowTeleportMenu()
        {
            var template = IngameMenu.main?.GetComponentInChildren<IngameMenuTopLevel>();

            if(template is null)
            {
                ErrorMessage.AddWarning("Menu template not found!");
                return;
            }

            try
            {
                MenuClone = GameObject.Instantiate(template.gameObject, uGUI.main.hud.transform);
                MenuClone.name = "TeleportMenu";
                MenuClone.gameObject.GetComponent<Image>().color = new Color(1f, 0.1f, 0f, 0.8f);

                var menu = MenuClone.AddComponent<BasicMenuComponent>();
                var buttons = MenuClone.GetComponentsInChildren<Button>(true);

                foreach(var button in buttons)
                {
                    if (isFirst)
                    {
                        templateButton = button;
                        isFirst = false;
                    }
                    else GameObject.Destroy(button.gameObject);
                }

                isFirst = true;

                var headerText = MenuClone.transform.Find("Header").GetComponent<TextMeshProUGUI>();
                headerText.text = "Select leviathan to track";

                BasicMenu.AddButton(templateButton.gameObject, "Reefback");
                BasicMenu.AddButton(templateButton.gameObject, "Sea Dragon");
                BasicMenu.AddButton(templateButton.gameObject, "Sea Treader");
                BasicMenu.AddButton(templateButton.gameObject, "Reaper Leviathan");
                BasicMenu.AddButton(templateButton.gameObject, "Ghost Leviathan");
                BasicMenu.AddButton(templateButton.gameObject, "Ghost Leviathan Juvenile");

                uGUI_INavigableIconGrid grid = MenuClone.GetComponentInChildren<uGUI_INavigableIconGrid>();

                if(grid is null) grid = MenuClone.GetComponent<uGUI_INavigableIconGrid>();
                else GamepadInputModule.current.SetCurrentGrid(grid);
            }
            catch(Exception ex) 
            {
                LoggerUtils.LogError(ex.Message);
            }
        }


        public static void AddButton(GameObject gameObject, string text)
        {
            GameObject buttonGo;

            if(isFirst)
            {
                buttonGo = gameObject;
                isFirst = false;
            }
            else buttonGo = GameObject.Instantiate(templateButton.gameObject, templateButton.transform.parent);

            buttonGo.GetComponent<Image>().color = new Color(0.6f, 0f, 0f, 1f);

            var button = buttonGo.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(()=> LoggerUtils.Screen.LogDebug($"button.onClick"));

            var TMPro = buttonGo.transform.GetComponentInChildren<TextMeshProUGUI>();
            TMPro.text = text;
        }
    }


    public class BasicMenuComponent : uGUI_InputGroup, uGUI_IButtonReceiver
    {
        public void Start()
        {
            this.Select();
            
        }

        public bool OnButtonDown(GameInput.Button button)
        {
            if(button == GameInput.Button.UICancel && IngameMenu.main.CanClose())
            {
                //Close();
                //GameInput.ClearInput();
                return true;
            }
            return false;
        }

        public void Close()
        {
            /*
            Deselect();
            Destroy(gameObject);
            */
        }

        public void OnEnable()
        {
            uGUI_LegendBar.ClearButtons();
            uGUI_LegendBar.ChangeButton(0, uGUI.FormatButton(GameInput.Button.UICancel, false, " / ", true), Language.main.GetFormat("Back"));
            uGUI_LegendBar.ChangeButton(1, uGUI.FormatButton(GameInput.Button.UISubmit, false, " / ", true), Language.main.GetFormat("ItemSelectorSelect"));
        }

        public override void OnDisable()
        {
            /*
            base.OnDisable();
            uGUI_LegendBar.ClearButtons();
            Destroy(gameObject);
            */
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
            /*
            base.OnDeselect();
            FreezeTime.End(FreezeTime.Id.IngameMenu);
            Destroy(gameObject);
            */
        }
    }
}