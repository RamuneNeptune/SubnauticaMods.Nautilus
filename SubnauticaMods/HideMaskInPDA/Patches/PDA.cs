

namespace Ramune.HideMaskInPDA.Patches
{
    [HarmonyPatch(typeof(PDA))]
    public static class PDAPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(PDA), nameof(PDA.Open))]
        public static void Open()
        {
            Player.main.SetScubaMaskState(Player.ScubaMaskState.Off);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PDA), nameof(PDA.Close))]
        public static void Close() 
        {
            Player.main.SetScubaMaskState(Player.ScubaMaskState.On);
        }
    }
}