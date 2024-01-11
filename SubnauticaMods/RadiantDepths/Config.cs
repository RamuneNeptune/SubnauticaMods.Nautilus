

namespace Ramune.RadiantDepths
{
    [Menu("Radiant Depths")]
    public class Config : ConfigFile
    {
        public int counter = 0;

        public void DoNothing(ToggleChangedEventArgs _)
        {
            counter++;
            if(counter == 1) LoggerUtils.Screen.LogWarning("Don't touch that");
            else if(counter == 15) LoggerUtils.Screen.LogWarning("I just told you not to fucking touch that");
            else if(counter == 25) LoggerUtils.Screen.LogWarning("Bro. Seriously?");
            else if(counter == 35) LoggerUtils.Screen.LogWarning("I swear to god if you do that one more time..");
            else if(counter == 45) CoroutineHost.StartCoroutine(DoMoreNothing());
        }

        public IEnumerator DoMoreNothing()
        {
            LoggerUtils.Screen.LogWarning("Firing AGM-114's in 3..");
            yield return new WaitForSeconds(1);

            LoggerUtils.Screen.LogWarning("Firing AGM-114's in 2..");
            yield return new WaitForSeconds(1);

            LoggerUtils.Screen.LogWarning("Firing AGM-114's in 1..");
            yield return new WaitForSeconds(1);

            LoggerUtils.Screen.LogSuccess("Fired. Prepare for hellfire.");
        }

        [Toggle("Nothing to see here.."), OnChange(nameof(DoNothing))]
        public bool Nothing = false;

        [Slider("Radiant blade damage multiplier (x)")]
        public float RadiantBladeDamage = 1f;

        [Slider("Radiant blade range multiplier (x)")]
        public float RadiantBladeRange = 1f;
    }
}