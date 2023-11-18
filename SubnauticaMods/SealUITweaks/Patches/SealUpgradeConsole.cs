

namespace Ramune.Seal.UITweaks.Patches
{
    [HarmonyPatch(typeof(SealUpgradeConsole))]
    public static class SealUpgradeConsolePatch
    {
        [HarmonyPatch(nameof(SealUpgradeConsole.OnHandHover)), HarmonyPrefix]
        public static bool OnHandHover(SealUpgradeConsole __instance, GUIHand hand)
        {
            if(!SealUITweaks.config.displayExtendedSlotInfo)
                return true;

            HandReticle main = HandReticle.main;

            string[] modules = EquippedModules(__instance);
            float available = modules.Count(item => item == null);

            string textToDisplay = "";

            if(SealUITweaks.config.extendedSlotInfoSlotsFreeCount)
            {
                textToDisplay += "<color=#ffc029>Available slots:</color> ";

                _ = available > 0 
                    ? textToDisplay += available + "\n"
                    : textToDisplay += "None" + "\n";
            }

            if(SealUITweaks.config.extendedSlotInfoShowEmpty)
            {
                for (int i = 0; i < modules.Length; i++)
                {
                    if(SealUITweaks.config.extendedSlotInfoShowFull)
                    {
                        _ = modules[i] is null
                            ? textToDisplay += $"<color=#ffc029>Slot {i + 1}:</color> Empty\n"
                            : textToDisplay += $"<color=#ffc029>Slot {i + 1}:</color> " + Language.main.GetOrFallback(modules[i], modules[i]) + "\n";
                    }
                    else
                    {
                        _ = modules[i] is null
                            ? textToDisplay += $"<color=#ffc029>Slot {i + 1}:</color> Empty\n"
                            : textToDisplay += $"";
                    }
                }
            }
            else
            {
                for(int i = 0; i < modules.Length; i++)
                {
                    if(SealUITweaks.config.extendedSlotInfoShowFull)
                    {
                        _ = modules[i] is null
                            ? textToDisplay += $""
                            : textToDisplay += $"<color=#ffc029>Slot {i + 1}:</color> " + Language.main.GetOrFallback(modules[i], modules[i]) + "\n";
                    }
                    else
                    {
                        _ = modules[i] is null
                            ? textToDisplay += $""
                            : textToDisplay += $"";
                    }
                }
            }

            main.SetText(HandReticle.TextType.Hand, "UpgradeConsole", true, GameInput.Button.LeftHand);
            main.SetText(HandReticle.TextType.HandSubscript, textToDisplay, false, GameInput.Button.None);
            main.SetIcon(HandReticle.IconType.Hand, 1f);

            return false;
        }

        public static string[] EquippedModules(SealUpgradeConsole console)
        {
            return console?.modules?.equipment?.Values?.Select(item => item?.item?.GetTechType().AsString()).ToArray();
        }
    }
}