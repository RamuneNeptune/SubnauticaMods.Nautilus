

using Story;

namespace Ramune.SimpleCoordinates.Patches
{
    [HarmonyPatch(typeof(Player))]
    public static class PlayerPatch
    {
        [HarmonyPatch(nameof(Player.Start)), HarmonyPostfix]
        public static void Start(Player __instance)
        {
            __instance.gameObject.EnsureComponent<Monos.CoordinateDisplay>();

            /*
            PDALog.Entry entry = new();
            entry.data.sound = AudioUtils.GetFmodAsset("event:/player/story/VO/RadioKelp28");
            entry.data.type = PDALog.EntryType.NowOrNever;
            entry.data.key = "This is a test!";
            */

            LanguageHandler.SetLanguageLine("ramune", "[1/3] Wow this is a test message. \n[2/3] Wow this is a test message. \n[3/3] Wow this is a test message. \n");

            PDAHandler.AddLogEntry("ramune", "ramune", AudioUtils.GetFmodAsset("event:/player/story/VO/RadioKelp28"));

            StoryGoalManager.main.AddPendingRadioMessage("ramune");
        }
    }
}