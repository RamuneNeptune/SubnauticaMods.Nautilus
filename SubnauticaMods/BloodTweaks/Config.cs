

namespace Ramune.BloodTweaks
{
    public class Config : ConfigFile
    {
        [Toggle("Show blood FX")]
        public bool showBlood = true;

        [Toggle("Use custom blood color")]
        public bool useColor = false;

        [ColorPicker("Custom blood color")]
        public Color color = Color.red;

        public void OnChange()
        {
            if(DamageFX.main is null)
                return;
        }
    }
}