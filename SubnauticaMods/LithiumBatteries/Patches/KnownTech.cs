

namespace Ramune.LithiumBatteries.Patches
{
    [HarmonyPatch(typeof(KnownTech))]
    public static class KnownTechPatch
    {
        [HarmonyPatch(nameof(KnownTech.Analyze)), HarmonyPostfix]
        public static void Analyze(TechType techType, bool verbose = true)
        {
            if(techType is TechType.PrecursorIonBattery)
            {
                if(!KnownTech.Contains(Items.IonBatteryAlt.Prefab.Info.TechType))
                    KnownTech.Add(Items.IonBatteryAlt.Prefab.Info.TechType);

                if(!KnownTech.Contains(Items.IonPowerCellAlt.Prefab.Info.TechType))
                    KnownTech.Add(Items.IonPowerCellAlt.Prefab.Info.TechType);
            }

            if(techType is TechType.Lithium)
            {
                if(!KnownTech.Contains(Items.LithiumBattery.Prefab.Info.TechType))
                    KnownTech.Add(Items.LithiumBattery.Prefab.Info.TechType);

                if(!KnownTech.Contains(Items.LithiumPowerCell.Prefab.Info.TechType))
                    KnownTech.Add(Items.LithiumPowerCell.Prefab.Info.TechType);
            }
        }
    }
}