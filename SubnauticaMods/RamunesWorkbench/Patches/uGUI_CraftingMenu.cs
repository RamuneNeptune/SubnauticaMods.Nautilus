

namespace Ramune.RamunesWorkbench.Patches
{
    [HarmonyPatch(typeof(uGUI_CraftingMenu))]
    public static class uGUI_CraftingMenuPatches
    {
        public static Atlas.Sprite backgroundSprite = Utilities.GetSprite("Background1.Sprite");
        public static bool isRamuneWorkbench = false;


        [HarmonyPatch(nameof(uGUI_CraftingMenu.Open)), HarmonyPrefix]
        public static void Open(CraftTree.Type treeType, ITreeActionReceiver receiver)
        {
            if(treeType != Buildables.RamunesWorkbench.craftTreeType) return;
            isRamuneWorkbench = true;
        }


        [HarmonyPatch(nameof(uGUI_CraftingMenu.Close)), HarmonyPrefix]
        public static void Close()
        {
            if(isRamuneWorkbench)
            {
                isRamuneWorkbench = false;
            }
        }


        [HarmonyPatch(nameof(uGUI_CraftingMenu.CreateIcon)), HarmonyPostfix]
        public static void CreateIcon(uGUI_CraftingMenu.Node node, RectTransform canvas, float size, float x, float y)
        {
            if(!isRamuneWorkbench)
                return;

            if (node is null) 
                return;

            if(node.icon is null)
                return;

            if(node.action != TreeAction.Expand)
                return;
            
            node.icon.SetBackgroundSprite(backgroundSprite);

            ErrorMessage.AddError(" >> node.icon.SetBackgroundSprite(backgroundSprite)");
        }
    }
}