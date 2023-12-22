

namespace RamuneLib.Utils
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
        /// <param name="verbose">If true, logs a message after patching.</param>
        public static void ApplyPatch(Type targetType, string methodName, HarmonyMethod patchMethod, HarmonyPatchType patchType, bool verbose = false)
        {
            try
            {
                var harmony = Variables.harmony;

                if(harmony is null)
                    return;

                if(patchMethod is null || string.IsNullOrEmpty(methodName) || targetType is null)
                {
                    LoggerUtils.LogError(">> Invalid parameters provided for patching.");
                    return;
                }

                MethodInfo targetMethod = targetType.GetMethod(methodName);

                if(targetMethod is null)
                {
                    LoggerUtils.LogError($">> '{targetType}.{methodName}' was not found");
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

                if(verbose)
                    LoggerUtils.LogInfo($">> Manual patch for: '{targetType}.{methodName}' as '{patchType}' called");
            }
            catch(Exception ex)
            {
                LoggerUtils.LogError($">> Error applying patch for '{targetType}.{methodName}' as '{patchType}', see next line for exception");
                LoggerUtils.LogError($">> {ex.GetType()}: {ex.Message}");
            }
        }
    }
}