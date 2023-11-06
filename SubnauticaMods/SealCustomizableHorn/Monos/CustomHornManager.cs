
using Nautilus.Utility;


namespace Ramune.Seal.CustomizableHorn.Monos
{
    public class CustomHornManager : MonoBehaviour
    {
        public static FMODAsset[] SoundAssets;

        public static BasicText text;

        public static string SoundsPath = Path.Combine(Variables.Paths.PluginFolder, "Sounds");

        public static int currentIndex = 0;


        public void Start()
        {
            SoundAssets.Add(AudioUtils.GetFmodAsset("event:/sub/cyclops/horn"));

            var files = Directory.GetFiles(SoundsPath, "*", SearchOption.AllDirectories)
                .Where(file => file.EndsWith(".mp3") || file.EndsWith(".wav"));

            foreach(var file in files)
            {
                var filename = Path.GetFileName(file);
                var sound = AudioUtils.CreateSound(file, AudioUtils.StandardSoundModes_3D);

                CustomSoundHandler.RegisterCustomSound(filename, sound, AudioUtils.BusPaths.PlayerSFXs);

                SoundAssets.Add(AudioUtils.GetFmodAsset(filename));
            }

            text = new BasicText();
            text.SetAlign(TMPro.TextAlignmentOptions.TopFlush);
            text.SetFontStyle(TMPro.FontStyles.Normal);
            text.SetFont(FontUtils.Aller_Rg);
            text.SetSize(24);

            text.ShowMessage(" ", 1f);
        }


        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Period))
            {
                if(currentIndex < SoundAssets.Length) currentIndex++;
                else currentIndex = 0;

                var current = currentIndex + 1;

                var length = SoundAssets.Length;

                var name = currentIndex == 0 
                    ? SoundAssets[currentIndex].name
                    : "Default horn";

                text.ShowMessage($"<color=#ffc02a>Selected {current}/{length}</color>: {name}", 3);
            }
        }


        public static FMODAsset GetCurrent() => SoundAssets[currentIndex];
    }
}