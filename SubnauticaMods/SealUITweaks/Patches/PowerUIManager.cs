

namespace Ramune.Seal.UITweaks.Patches
{
    [HarmonyPatch(typeof(PowerUIManager))]
    public static class PowerUIManagerPatch
    {
        public static PowerUIManager manager;
        public static string PowerStable = "Power: <color=#1ed724>stable</color>";
        public static string PowerLow = "Power: <color=#fbd03c>low</color>";
        public static string PowerCritical = "Power: <color=#ff3f00>critical</color>";
        public static string powerStatus = "";
        public static bool isInitial = true;


        [HarmonyPatch(nameof(PowerUIManager.UpdateUI)), HarmonyPrefix]
        public static bool UpdateUI(PowerUIManager __instance)
        {
            if(!SealUITweaks.config.displayCurrentPower && !SealUITweaks.config.displayPowerStatus)
                return true;

            if(isInitial)
            {
                manager = __instance;
                __instance.powerText.rectTransform.anchoredPosition += new Vector2(0f, -58f);
                OnPercentageChanged(__instance.lastDisplayedPowerPercentage);
                isInitial = false;
            }

            float currentPower = __instance.subRoot.powerRelay.GetPower();
            float maxPower = __instance.subRoot.powerRelay.GetMaxPower();
            int num = (__instance.subRoot.powerRelay.GetMaxPower() == 0f) ? 0 : Mathf.CeilToInt(currentPower / maxPower * 100f);

            string textToDisplay = $"{num}%";
            string formatText = "";

            if(SealUITweaks.config.displayPowerStatus)
                textToDisplay += $"\n<size=45>{powerStatus}</size>";

            if(SealUITweaks.config.displayCurrentPower)
            {
                switch(SealUITweaks.config.powerStatusFormat)
                {
                    case string format when format == Config.powerStatusOptions[0]:
                        formatText += string.Format("\n<color=#c0c2c0>({0} / {1})</color>", Mathf.Round(currentPower), maxPower);
                        break;

                    case string format when format == Config.powerStatusOptions[1]:
                        formatText += string.Format("\n<color=#c0c2c0>({0} / {1})</color>", maxPower, Mathf.Round(currentPower));
                        break;

                    case string format when format == Config.powerStatusOptions[2]:
                        formatText += string.Format("\n<color=#c0c2c0>({0})</color>", Mathf.Round(currentPower));
                        break;

                    case string format when format == Config.powerStatusOptions[3]:
                        formatText += string.Format("\n<color=#c0c2c0>({0})</color>", maxPower);
                        break;
                }

                textToDisplay += $"\n<size=45>{formatText}</size>";
            }
            __instance.powerText.text = textToDisplay;


            if(__instance.lastDisplayedPowerPercentage != num)
            {
                __instance.lastDisplayedPowerPercentage = (int)num;
                OnPercentageChanged(__instance.lastDisplayedPowerPercentage);
            }
            return false;
        }

        public static void OnPercentageChanged(float percentage)
        {
            if(percentage < 0f)
                return;

            if(percentage <= SealUITweaks.config.stable && percentage >= SealUITweaks.config.low + 1)
                powerStatus = PowerStable;

            else if(percentage <= SealUITweaks.config.low && percentage >= SealUITweaks.config.critical + 1)
                powerStatus = PowerLow;

            else if(percentage <= SealUITweaks.config.critical)
                powerStatus = PowerCritical;
        }

        public static float GetPercentage()
        {
            if(manager is null)
                return -1;

            return manager.lastDisplayedPowerPercentage;
        }
    }
}