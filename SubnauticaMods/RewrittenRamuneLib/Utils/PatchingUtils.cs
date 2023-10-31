

namespace RamuneLib
{
    public static class PatchingUtils
    {
        /// <summary>
        /// Runs a specific Harmony patch on a target method within a given type. The patch type can be one of Prefix, Postfix, or Transpiler.
        /// </summary>
        /// <param name="targetType">The type containing the target method.</param>
        /// <param name="methodName">The name of the target method to be patched.</param>
        /// <param name="patchMethod">The Harmony method to be applied as a patch.</param>
        /// <param name="patchType">The type of Harmony patch (Prefix, Postfix, or Transpiler) to be applied.</param>
        public static void RunSpecificPatch(Type targetType, string methodName, HarmonyMethod patchMethod, HarmonyPatchType patchType)
        {
            var harmony = Variables.harmony;

            if(harmony is null)
                return;

            MethodInfo targetMethod = targetType.GetMethod(methodName);

            if(targetMethod is null)
            {
                LoggerUtils.LogError($">> Manual patch for: '{targetType}.{methodName}' as '{patchType}' not found");
                return;
            }

            switch(patchType)
            {
                case HarmonyPatchType.Prefix:
                    harmony.Patch(targetMethod, prefix: patchMethod);
                    break;

                case HarmonyPatchType.Postfix:
                    harmony.Patch(targetMethod, postfix: patchMethod);
                    break;

                case HarmonyPatchType.Transpiler:
                    harmony.Patch(targetMethod, transpiler: patchMethod);
                    break;

                default:
                    LoggerUtils.LogError($">> Manual patch for: '{targetType}.{methodName}' as '{patchType}' could not be run because '{patchType}' is not a valid option (prefix, postfix, or transpiler)");
                    return;
            }

            LoggerUtils.LogInfo($">> Manual patch for: '{targetType}.{methodName}' as '{patchType}' called");
        }
    }
}