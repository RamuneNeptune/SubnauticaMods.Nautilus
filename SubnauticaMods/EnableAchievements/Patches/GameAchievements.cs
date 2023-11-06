

namespace Ramune.EnableAchievements.Patches
{
    [HarmonyPatch(typeof(GameAchievements), nameof(GameAchievements.Unlock))]
    public class GameAchievementsPatch
    {
        public static bool Prefix(GameAchievements.Id id)
        {
            PlatformUtils.main.GetServices().UnlockAchievement(id);
            LoggerUtils.LogInfo($">> Unlocked '{id}'");

            return false;
        }
    }
}