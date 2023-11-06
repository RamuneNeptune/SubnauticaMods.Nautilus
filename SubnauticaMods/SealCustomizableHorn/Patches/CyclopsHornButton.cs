

namespace Ramune.Seal.CustomizableHorn.Patches
{
    [HarmonyPatch(typeof(CyclopsHornButton))]
    public static class CyclopsHornButtonPatch
    {
        public static FMOD_CustomEmitter emitter;

        [HarmonyPatch(nameof(CyclopsHornButton.OnPress)), HarmonyPrefix]
        public static bool OnPress(CyclopsHornButton __instance)
        {
            if(Player.main.currentSub.GetType() != typeof(SealSubRoot))
                return true;

            emitter ??= __instance.hornSFX;

            emitter.SetAsset(Monos.CustomHornManager.GetCurrent());
            emitter.Play();

            var instance = emitter.GetEventInstance();

            instance.setVolume(SealCustomizableHorn.config.volume / 100f);
            instance.setPitch(SealCustomizableHorn.config.pitch / 100f);

            return false;
        }
    }
}