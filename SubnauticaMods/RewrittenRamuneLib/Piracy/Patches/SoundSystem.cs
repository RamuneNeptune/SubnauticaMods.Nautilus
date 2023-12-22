

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            [HarmonyPatch(typeof(SoundSystem), nameof(SoundSystem.SetMusicVolume)), HarmonyPostfix]
            public static void SoundSystem_SetMusicVolume(SoundSystem __instance)
            {
                SoundSystem.musicVolume = 0f;

                if(SoundSystem.musicVCA.hasHandle())
                    SoundSystem.musicVCA.setVolume(0f);
            }
        }
    }
}