

using Nautilus.Utility;
using TMPro;

namespace Ramune.RamunesWorkbench.Patches
{
    [HarmonyPatch(typeof(Player))]
    public static class PlayerPatch
    {
        [HarmonyPatch(nameof(Player.Start))]
        public static void Start()
        {
            //CoordinatedSpawnsHandler.RegisterCoordinatedSpawnsForOneTechType(TechType.DrillableKyanite, new SpawnLocation(new(-1798f, -389f, 122f)));

            GameObject go = new("TestTest");

            var gui = go.EnsureComponent<TextMeshProUGUI>();
            gui.text = "Hello, world!";
            gui.color = Color.green;
            gui.alignment = TextAlignmentOptions.TopJustified;
            gui.enabled = true;
            gui.font = FontUtils.Aller_Rg;
            gui.gameObject.transform.SetParent(uGUI.main.screenCanvas.transform, false);
            gui.fontStyle = uGUI.main.intro.mainText.text.fontStyle;
            gui.alignment = uGUI.main.intro.mainText.text.alignment;
            gui.fontSize = uGUI.main.intro.mainText.text.fontSize;
            gui.canvas.overrideSorting = true;
            gui.gameObject.layer = 31;
            gui.enabled = true;
        }
    }
}