
using Nautilus.Utility;
using Newtonsoft.Json.Linq;


namespace Ramune.SimpleCoordinates.Monos
{
    public class CoordinateDisplay : MonoBehaviour
    {
        public static BasicText text, targetText;
        public bool textHidden, targetTextHidden;
        public static string targetCoordinatesJson = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TargetCoordinates.json");
        public static float x, y, z;

        public void Start()
        {
            text = new();
            text.ShowMessage("", 1);
            text.SetColor(new(1f, 0.75f, 0.16f));
            text.SetAlign(TextAlignmentOptions.Center);
            text.SetLocation(SimpleCoordinates.config.textX, SimpleCoordinates.config.textY);
            text.SetSize((int)SimpleCoordinates.config.textSize);

            targetText = new();
            targetText.ShowMessage("", 1);
            targetText.SetColor(new(1f, 0.75f, 0.16f));
            targetText.SetAlign(TextAlignmentOptions.Center);
            targetText.SetLocation(SimpleCoordinates.config.targetTextX, SimpleCoordinates.config.targetTextY);
            targetText.SetSize((int)SimpleCoordinates.config.targetTextSize);

            RefreshJson();
        }


        public void Update()
        {
            if(!SimpleCoordinates.config.display && !textHidden)
            {
                text.Hide();
                textHidden = true;
            }

            if(!SimpleCoordinates.config.targetDisplay && !targetTextHidden)
            {
                targetText.Hide();
                targetTextHidden = true;
            }

            if(SimpleCoordinates.config.display)
            {
                if(textHidden) textHidden = false;

                var p = Player.main.transform.position;
                text.ShowMessage($"X:<color=#FFFFFF>{Mathf.Round(p.x)}</color>  Y:<color=#FFFFFF>{Mathf.Round(p.y)}</color>  Z:<color=#FFFFFF>{Mathf.Round(p.z)}</color>");
            }

            if(SimpleCoordinates.config.targetDisplay)
            {
                if(targetTextHidden) targetTextHidden = false;

                targetText.ShowMessage($"Target - X:<color=#FFFFFF>{x}</color>  Y:<color=#FFFFFF>{y}</color>  Z:<color=#FFFFFF>{z}</color>");
            }
        }


        public static void AdjustForConfig()
        {
            if(text != null)
            {
                text.SetSize((int)SimpleCoordinates.config.textSize);
                text.SetLocation(SimpleCoordinates.config.textX, SimpleCoordinates.config.textY);
            }

            if(targetText != null)
            {
                targetText.SetSize((int)SimpleCoordinates.config.targetTextSize);
                targetText.SetLocation(SimpleCoordinates.config.targetTextX, SimpleCoordinates.config.targetTextY);
            }
        }


        public static void RefreshJson()
        {
            var text = File.ReadAllText(targetCoordinatesJson);
            var json = JObject.Parse(text);

            x = (float)json["X"];
            y = (float)json["Y"];
            z = (float)json["Z"];
        }
    }
}