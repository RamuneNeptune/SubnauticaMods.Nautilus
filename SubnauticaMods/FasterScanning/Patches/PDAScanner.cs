

namespace Ramune.FasterScanning.Patches
{
    [HarmonyPatch(typeof(PDAScanner))]
    public static class PDAScannerPatch
    {
        public static float num = 2f;
        public static float one, two, multiplier;

        [HarmonyPatch(nameof(PDAScanner.Scan)), HarmonyPostfix]
        public static void Scan()
        {
            var techType = PDAScanner.scanTarget.techType;
            var entryData = PDAScanner.GetEntryData(techType);
            var isKnownTech = PDAScanner.complete.Contains(techType);

            if(PDAScanner.scanTarget.isPlayer) return;

            multiplier = FasterScanning.config.multiplier;

            one = 2.0f / multiplier;

            if(entryData is not null) num = entryData.scanTime / multiplier;
            else num = one;

            if(isKnownTech) num = one;
            
            PDAScanner.scanTarget.progress = PDAScanner.scanTarget.progress + Time.deltaTime / num;
        }
    }
}