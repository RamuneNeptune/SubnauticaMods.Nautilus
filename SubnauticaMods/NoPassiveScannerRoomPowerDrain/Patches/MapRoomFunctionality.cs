

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