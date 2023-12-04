

namespace Ramune.BloodTweaks
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class BloodTweaks : BaseUnityPlugin
    {
        public static BloodTweaks Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.BloodTweaks";
        public const string Name = "Blood Tweaks";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }

        public IEnumerator WaitForDamageFX()
        {
            yield return new WaitUntil(()=> DamageFX.main);
        }
    }
}