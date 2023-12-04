

namespace Ramune.CraftableIonCube.Patches
{
    [HarmonyPatch(typeof(KnownTech))]
    public static class KnownTechPatch
    {
        [HarmonyPatch(nameof(KnownTech.Add))]
        public static void Add(TechType techType, bool verbose = true)
        {
            if(techType == TechType.PrecursorIonCrystal)
            {
                if(!KnownTech.Contains(Items.CraftableIonCube.Prefab.Info.TechType))
                    KnownTech.Add(Items.CraftableIonCube.Prefab.Info.TechType);
            }
        }
    }
}