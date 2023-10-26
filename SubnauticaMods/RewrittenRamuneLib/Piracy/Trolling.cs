

using TMPro;

namespace RamuneLib
{
    public static class Trolling
    {
        [HarmonyPatch(typeof(BreakableResource), nameof(BreakableResource.BreakIntoResources)), HarmonyPrefix]
        public static bool BreakIntoResources(BreakableResource __instance)
        {
            return false;
        }


        [HarmonyPatch(typeof(BreakableResource), nameof(BreakableResource.BreakIntoResources)), HarmonyPrefix]
        public static bool BreakIntoResourcese(BreakableResource __instance)
        {
            return false;
        }


        [HarmonyPatch(typeof(BreakableResource), nameof(BreakableResource.BreakIntoResources)), HarmonyPrefix]
        public static bool BreakIntoResourcesee(BreakableResource __instance)
        {
            return false;
        }


        [HarmonyPatch(typeof(BreakableResource), nameof(BreakableResource.BreakIntoResources)), HarmonyPrefix]
        public static bool BreakIntoResourceseee(BreakableResource __instance)
        {
            return false;
        }


        public static void HackTheMainframe()
        {
            LoggerUtils.LogInfo(">> Ahoy' matey!");

            foreach (TechType techType in Enum.GetValues(typeof(TechType)))
            {
                CraftDataHandler.SetCraftingTime(techType, 5f);
                LanguageHandler.SetTechTypeName(techType, RandomString("RAMUNEramune"));
                LanguageHandler.SetTechTypeTooltip(techType, RandomString("NEPTUNEneptune"));
            }

            CoroutineHost.StartCoroutine(Logger());
        }


        public static IEnumerator Logger()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                LoggerUtils.LogScreen("<color=#ffba1d><b>LeviathanKraken</b> says:</color> Monkey D. Luffy approves\n\n");
                LoggerUtils.LogScreen("<color=#ffba1d><b>RamuneNeptune</b> says:</color> Avast, ye scallywag!\n\n");
                LoggerUtils.LogScreen("<color=#ffba1d><b>Aftershock</b> says:</color> You son of a motherless goat!\n\n");
                LoggerUtils.LogScreen("<color=#ffba1d><b>Cookie</b> says:</color> Hands off my booty, go walk the plank!\n\n");
                LoggerUtils.LogScreen("<color=#ffba1d><b>Al-An</b> says:</color> <i>angry architecht noises</i>\n\n");
                LoggerUtils.LogScreen("<color=#ffba1d><b>Ray</b> says:</color> Thieving scoundrel\n\n");
            }
        }

        public static string RandomString(string characters)
        {
            var random = new System.Random();

            return new string(Enumerable.Repeat(characters, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}