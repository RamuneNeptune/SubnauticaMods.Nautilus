

namespace Ramune.RamunesWorkbench.Patches
{
    [HarmonyPatch(typeof(KnownTech))]
    public static class KnownTechPatch
    {
        public static List<string> ModdedTechTypeStrings = new()
        {
            "LithiumBattery",
            "LithiumPowerCell",
            "IonBatteryAlt",
            "IonPowerCellAlt",
            "KioniteBattery",
            "KionitePowerCell",
            "MegaO2Tank",
            "SeaglideMK1",
            "SeaglideMK2",
            "SeaglideMK3",
            "StasisModule",
            "RadiantBlade",
            "OxygenCanister",
            "LargeOxygenCanister",
        };

        [HarmonyPatch(nameof(KnownTech.GetTechUnlockState), new[] { typeof(TechType), typeof(int), typeof(int) }, new[] { ArgumentType.Normal, ArgumentType.Out, ArgumentType.Out }), HarmonyPostfix]
        public static void GetTechUnlockState(TechType techType, ref TechUnlockState __result)
        {
            if(!ModdedTechTypeStrings.Contains(techType.AsString()))
                return;

            if(EnumHandler.TryGetValue(techType.AsString(), out TechType _))
            {
                if(__result != TechUnlockState.Available || !CrafterLogic.IsCraftRecipeUnlocked(techType))
                    __result = TechUnlockState.Locked;
            }
        }
    }
}