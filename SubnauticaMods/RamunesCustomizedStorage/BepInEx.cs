

namespace Ramune.RamunesCustomizedStorage
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class RamunesCustomizedStorage : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static RamunesCustomizedStorage Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.RamunesCustomizedStorage";
        public const string Name = "Ramune's Customized Storage";
        public const string Version = "1.1.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
            //CoroutineHost.StartCoroutine(SetupDialog());
        }

        /*
        public IEnumerator SetupDialog()
        {
            yield return new WaitUntil(() => IngameMenu.main);

            var unstuck = IngameMenu.main.gameObject.GetComponentInChildren<IngameMenuUnstuckConfirmation>(true);
            var unstuckGo = unstuck.gameObject;

            var dialogGo = GameObject.Instantiate(unstuckGo, unstuckGo.transform.parent);
            dialogGo.name = "RamuneWarning";
        }
        */
    }
}