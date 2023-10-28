

namespace Ramune.RamunesWorkbench.Patches
{
    [HarmonyPatch(typeof(uGUI_CraftingMenu))]
    public static class uGUI_CraftingMenuPatches
    {
        public static Atlas.Sprite VanillaTabNode = ImageUtils.GetSprite("Vanilla.TabNode");
        public static Atlas.Sprite VanillaTabNodeHover = ImageUtils.GetSprite("Vanilla.TabNodeHover");
        public static Atlas.Sprite FancyTabNode = ImageUtils.GetSprite("Fancy.TabNode");
        public static Atlas.Sprite FancyTabNodeHover = ImageUtils.GetSprite("Fancy.TabNodeHover");

        public static Atlas.Sprite[] GetTabNodeSprites()
        {
            if(RamunesWorkbench.config.tabStyle == Config.NodeStyle.Vanilla)
                return new Atlas.Sprite[] { VanillaTabNode, VanillaTabNodeHover };

            if(RamunesWorkbench.config.tabStyle == Config.NodeStyle.Fancy)
                return new Atlas.Sprite[] { FancyTabNode, FancyTabNodeHover };

            return null;
        }

        public static CraftTree.Type CurrentCraftTreeType;


        [HarmonyPatch(nameof(uGUI_CraftingMenu.Open)), HarmonyPrefix]
        public static void Open(CraftTree.Type treeType, ITreeActionReceiver receiver)
        {
            CurrentCraftTreeType = treeType;
        }


        [HarmonyPatch(nameof(uGUI_CraftingMenu.Close)), HarmonyPrefix]
        public static void Close()
        {
            CurrentCraftTreeType = CraftTree.Type.None;
        }


        [HarmonyPatch(nameof(uGUI_CraftingMenu.CreateIcon)), HarmonyPostfix]
        public static void CreateIcon(uGUI_CraftingMenu.Node node, RectTransform canvas, float size, float x, float y)
        {
            if(CurrentCraftTreeType != Buildables.RamunesWorkbench.craftTreeType)
                return;

            if(node is null) 
                return;

            if(node.icon is null)
                return;

            if(node.action != TreeAction.Expand)
                return;

            node.icon.SetBackgroundSprite(GetTabNodeSprites()[0]);
        }


        [HarmonyPatch("uGUI_IIconManager.OnPointerEnter"), HarmonyPostfix]
        public static void OnPointerEnter(uGUI_CraftingMenu __instance, uGUI_ItemIcon icon)
        {            
            if(CurrentCraftTreeType != Buildables.RamunesWorkbench.craftTreeType)
                return;

            var node = __instance.GetNode(icon);

            if(node is null)
                return;

            if(node.action != TreeAction.Expand)
                return;

            node.icon.SetBackgroundSprite(GetTabNodeSprites()[1]);
        }


        [HarmonyPatch("uGUI_IIconManager.OnPointerExit"), HarmonyPostfix]
        public static void OnPointerExit(uGUI_CraftingMenu __instance, uGUI_ItemIcon icon)
        {
            if(CurrentCraftTreeType != Buildables.RamunesWorkbench.craftTreeType)
                return;

            var node = __instance.GetNode(icon);

            if(node is null)
                return;

            if(node.action != TreeAction.Expand)
                return;

            node.icon.SetBackgroundSprite(GetTabNodeSprites()[0]);
        }
    }
}