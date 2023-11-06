

namespace Ramune.Seal.UITweaks.Patches
{
    [HarmonyPatch(typeof(PowerUIManager))]
    public static class PowerUIManagerPatch
    {
        public static string PowerStable = "Power: <color=#1ed724>stable</color>";
        public static string PowerLow = "Power: <color=#fbd03c>low</color>";
        public static string PowerCritical = "Power: <color=#ff3f00>critical</color>";
        public static string toDisplay = "";

        public static bool isInitial = true;

        [HarmonyPatch(nameof(PowerUIManager.UpdateUI)), HarmonyPrefix]
        public static bool UpdateUI(PowerUIManager __instance)
        {
            if(isInitial)
            {
                __instance.powerText.rectTransform.anchoredPosition += new Vector2(0f, -58f);
                OnPercentageChanged(__instance.lastDisplayedPowerPercentage);
                isInitial = false;
            }

            float currentPower = __instance.subRoot.powerRelay.GetPower();
            float maxPower = __instance.subRoot.powerRelay.GetMaxPower();

            int num = (__instance.subRoot.powerRelay.GetMaxPower() == 0f) ? 0 : Mathf.CeilToInt(currentPower / maxPower * 100f);
            string currentVersusTotal = string.Format("\n<color=#c0c2c0>({0} / {1})</color>", Mathf.Round(currentPower), maxPower);

            __instance.powerText.text = $"<align=left>{num}%</align>\n<align=left><size=45>{toDisplay}{currentVersusTotal}</size></align>";

            if(__instance.lastDisplayedPowerPercentage != num)
            {
                __instance.lastDisplayedPowerPercentage = num;
                OnPercentageChanged(__instance.lastDisplayedPowerPercentage);
            }

            return false;
        }

        public static void OnPercentageChanged(float percentage)
        {
            if(percentage <= 100f && percentage >= 31f)
                toDisplay = PowerStable;

            else if(percentage <= 30f && percentage >= 11f)
                toDisplay = PowerLow;

            else if(percentage <= 10f)
                toDisplay = PowerCritical;
        }
    }
}