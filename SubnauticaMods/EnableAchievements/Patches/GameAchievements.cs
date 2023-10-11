

namespace Ramune.EnableAchievements.Patches
{
    [HarmonyPatch(typeof(GameAchievements), nameof(GameAchievements.Unlock))]
    public class GameAchievementsPatch
    {
        public static bool Prefix(GameAchievements.Id id)
        {
            PlatformUtils.main.GetServices().UnlockAchievement(id);
            Logger.LogInternal($">> Unlocked '{id}'", LogLevel.Info);

            return false;
        }
    }
}