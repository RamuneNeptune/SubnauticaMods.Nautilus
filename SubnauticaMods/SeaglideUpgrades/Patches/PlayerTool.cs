

using Ramune.SeaglideUpgrades.Monos;

namespace Ramune.SeaglideUpgrades.Patches
{
    [HarmonyPatch(typeof(PlayerTool))]
    public static class PlayerToolPatches
    {
        public static float one = 1f;
        public static List<TechType?> Seaglides = new()
        {
            Items.SeaglideMK1.Prefab.Info.TechType,
            Items.SeaglideMK2.Prefab.Info.TechType,
            Items.SeaglideMK3.Prefab.Info.TechType,
        };


        [HarmonyPatch(nameof(PlayerTool.animToolName), MethodType.Getter), HarmonyPostfix]
        public static void Postfix(PlayerTool __instance, ref string __result)
        {
            if(Seaglides.Contains(__instance.pickupable?.GetTechType())) 
                __result = "seaglide";
        }

        
        [HarmonyPatch(nameof(PlayerTool.OnDraw)), HarmonyPrefix]
        public static void OnDraw(PlayerTool __instance)
        {
            var techType = __instance.pickupable?.GetTechType();

            if(!Seaglides.Contains(TechType.Seaglide))
                Seaglides.Add(TechType.Seaglide);

            if(Seaglides.Contains(techType))    
            {
                switch(true)
                {
                    case bool _ when techType == TechType.Seaglide:
                        SetSpeeds(25f, 36.56f, ref one);
                        break;

                    case bool _ when techType == Items.SeaglideMK1.Prefab.Info.TechType:
                        Monos.Seaglides.Colorizers.ForEach(s => s.Refresh(SeaglideLightColorizer.UpgradedSeaglide.MK1,
                            ref SeaglideUpgrades.config.redmk1,
                            ref SeaglideUpgrades.config.greenmk1,
                            ref SeaglideUpgrades.config.bluemk1,
                            ref SeaglideUpgrades.config.intensitymk1,
                            ref SeaglideUpgrades.config.rangemk1,
                            ref SeaglideUpgrades.config.conesizemk1));

                        SetSpeeds(42f, 42f, ref SeaglideUpgrades.config.speedmk1);
                        break;

                    case bool _ when techType == Items.SeaglideMK2.Prefab.Info.TechType:
                        Monos.Seaglides.Colorizers.ForEach(s => s.Refresh(SeaglideLightColorizer.UpgradedSeaglide.MK2,
                            ref SeaglideUpgrades.config.redmk2,
                            ref SeaglideUpgrades.config.greenmk2,
                            ref SeaglideUpgrades.config.bluemk2,
                            ref SeaglideUpgrades.config.intensitymk2,
                            ref SeaglideUpgrades.config.rangemk2,
                            ref SeaglideUpgrades.config.conesizemk2));

                        SetSpeeds(50f, 50f, ref SeaglideUpgrades.config.speedmk2);
                        break;

                    case bool _ when techType == Items.SeaglideMK3.Prefab.Info.TechType:
                        Monos.Seaglides.Colorizers.ForEach(s => s.Refresh(SeaglideLightColorizer.UpgradedSeaglide.MK3,
                            ref SeaglideUpgrades.config.redmk3,
                            ref SeaglideUpgrades.config.greenmk3,
                            ref SeaglideUpgrades.config.bluemk3,
                            ref SeaglideUpgrades.config.intensitymk3,
                            ref SeaglideUpgrades.config.rangemk3,
                            ref SeaglideUpgrades.config.conesizemk3));

                        SetSpeeds(58f, 58f, ref SeaglideUpgrades.config.speedmk3);
                        break;
                }
            }
        }


        public static void SetSpeeds(float speed, float accel, ref float multiplier)
        {
            Player.main.playerController.seaglideForwardMaxSpeed = speed * multiplier;
            Player.main.playerController.seaglideWaterAcceleration = accel * multiplier;
            Player.main.UpdateMotorMode();
        }
    }
}