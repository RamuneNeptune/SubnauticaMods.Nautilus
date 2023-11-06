

namespace Ramune.Seal.UITweaks.Patches
{
    [HarmonyPatch(typeof(SealUpgradeConsole))]
    public static class SealUpgradeConsolePatch
    {
        [HarmonyPatch(nameof(SealUpgradeConsole.OnHandHover)), HarmonyPrefix]
        public static bool OnHandHover(SealUpgradeConsole __instance, GUIHand hand)
        {
            HandReticle main = HandReticle.main;

            string[] modules = EquippedModules(__instance);

            string text = 
                  $"Slots free"
                + $"<color=#ffc029>Slot 1:</color> {(modules[0] is null ? "Empty" : Language.main.GetOrFallback(modules[0], modules[0]))}\n"
                + $"<color=#ffc029>Slot 2:</color> {(modules[1] is null ? "Empty" : Language.main.GetOrFallback(modules[1], modules[1]))}\n"
                + $"<color=#ffc029>Slot 3:</color> {(modules[2] is null ? "Empty" : Language.main.GetOrFallback(modules[2], modules[2]))}\n"
                + $"<color=#ffc029>Slot 4:</color> {(modules[3] is null ? "Empty" : Language.main.GetOrFallback(modules[3], modules[3]))}";

            main.SetText(HandReticle.TextType.Hand, "UpgradeConsole", true, GameInput.Button.LeftHand);
            main.SetText(HandReticle.TextType.HandSubscript, text, false, GameInput.Button.None);
            main.SetIcon(HandReticle.IconType.Hand, 1f);

            return false;
        }

        public static string[] EquippedModules(SealUpgradeConsole console)
        {
            return console?.modules?.equipment?.Values?.Select(item => item?.item?.GetTechType().AsString()).ToArray();
        }
    }
}