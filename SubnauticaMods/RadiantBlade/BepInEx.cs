
using SuitLib;


namespace Ramune.RadiantBlade
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("Indigocoder.SuitLib")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class RadiantBlade : BaseUnityPlugin
    {
        public static RadiantBlade Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.RadiantBlade";
        public const string Name = "Radiant Blade";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
            Items.RadiantBlade.Patch();

            Items.RainbowSuit.Patch();
            Items.RainbowGloves.Patch();

            var SuitKVP = new Dictionary<string, Texture2D> { { "_MainTex", Items.RainbowSuit.TextureMain }, { "_SpecTex", Items.RainbowSuit.TextureMain } };
            var RamuneSuit = new ModdedSuit(SuitKVP, ModdedSuitsManager.VanillaModel.Reinforced, Items.RainbowSuit.Prefab.Info.TechType);
            ModdedSuitsManager.AddModdedSuit(RamuneSuit);

            var GlovesKVP = new Dictionary<string, Texture2D> { { "_MainTex", Items.RainbowGloves.TextureMain }, { "_SpecTex", Items.RainbowGloves.TextureMain } };
            var RamuneGloves = new ModdedGloves(GlovesKVP, ModdedSuitsManager.VanillaModel.Reinforced, Items.RainbowGloves.Prefab.Info.TechType);
            ModdedSuitsManager.AddModdedGloves(RamuneGloves);
        }
    }
}