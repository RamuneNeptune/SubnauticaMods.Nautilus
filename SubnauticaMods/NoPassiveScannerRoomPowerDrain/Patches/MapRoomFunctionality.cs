

using System.Reflection.Emit;

namespace Ramune.NoPassiveScannerRoomPowerDrain.Patches
{
    [HarmonyPatch(typeof(MapRoomFunctionality), nameof(MapRoomFunctionality.UpdateScanning))]
    public static class MapRoomFunctionalityPatch
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach(var instruction in instructions)
            {
                if(instruction.opcode == OpCodes.Ldc_R4 && (float)instruction.operand == 0.15f) yield return new CodeInstruction(OpCodes.Ldc_R4, 0f);
                else yield return instruction;
            }
        }
    }
}

/*
    [HarmonyPatch(typeof(MapRoomFunctionality), nameof(MapRoomFunctionality.UpdateScanning))]
    public static class MapRoomFunctionalityPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(MapRoomFunctionality __instance)
        {
            DayNightCycle main = DayNightCycle.main;
            if (!main)
            {
                return false;
            }
            Material materialInstance = __instance.miniWorld.materialInstance;
            double timePassed = main.timePassed;
            if (__instance.timeLastScan + (double)__instance.scanInterval <= timePassed && __instance.powered)
            {
                __instance.timeLastScan = timePassed;
                __instance.UpdateBlips();
                __instance.UpdateCameraBlips();
                float num = __instance.scanRange * __instance.mapScale;
                if (__instance.prevFadeRadius != num)
                {
                    materialInstance.SetFloat(ShaderPropertyID._FadeRadius, num);
                    __instance.prevFadeRadius = num;
                }
            }
            if (__instance.scanActive != __instance.prevScanActive || __instance.scanInterval != __instance.prevScanInterval)
            {
                float num2 = 1f / __instance.scanInterval;
                materialInstance.SetFloat(ShaderPropertyID._ScanIntensity, __instance.scanActive ? __instance.scanIntensity : 0f);
                materialInstance.SetFloat(ShaderPropertyID._ScanFrequency, __instance.scanActive ? num2 : 0f);
                __instance.prevScanActive = __instance.scanActive;
                __instance.prevScanInterval = __instance.scanInterval;
            }
            if (__instance.powered && __instance.timeLastPowerDrain + 1f < Time.time)
            {
                float num3;
                __instance.powerConsumer.ConsumePower(__instance.scanActive ? 0.5f : 0f, out num3);
                __instance.timeLastPowerDrain = Time.time;
            }

            return false;
        }
    }
}
*/