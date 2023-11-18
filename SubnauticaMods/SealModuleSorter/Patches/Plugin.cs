

namespace Ramune.Seal.ModuleSorter.Patches
{
    [HarmonyPatch(typeof(Plugin))]
    public static class PluginPatch
    {
        [HarmonyPatch(nameof(Plugin.RegisterUpgradeModulePrefab)), HarmonyPostfix]
        public static void RegisterUpgradeModulePrefab(PrefabInfo info, RecipeData recipe)
        {

        }
    }
}