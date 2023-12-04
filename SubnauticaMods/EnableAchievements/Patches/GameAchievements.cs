

namespace Ramune.EnableAchievements.Patches
{
    [HarmonyPatch(typeof(GameAchievements), nameof(GameAchievements.Unlock))]
    public class GameAchievementsPatch
    {
        public static bool Prefix(GameAchievements.Id id)
        {
            PlatformUtils.main.GetServices().UnlockAchievement(id);
            LoggerUtils.LogInfo($">> Unlocked '{id}' (if you already have this achievement that's fine, the game runs this code anyways)");

            return false;
        }
    }
}