

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
            var knownTech = PDAScanner.complete.Contains(techType);

            if(PDAScanner.scanTarget.isPlayer) return;

            multiplier = FasterScanning.config.multiplier;

            one = 2.0f / multiplier;
            two = entryData.scanTime / multiplier;

            if(knownTech) num = one;
            if(entryData is not null) num = two;
            
            PDAScanner.scanTarget.progress = PDAScanner.scanTarget.progress + Time.deltaTime / num;
        }
    }
}