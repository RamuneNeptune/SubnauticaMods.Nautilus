

namespace Ramune.RamunesWorkbench.Monos
{
    public class DontLook : MonoBehaviour
    {
        public List<KeyCode> zxnskwnqdsp = new() { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow,KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A };
        public Sound theReallyCoolSound;
        public int currentIndex = 0;


        public void Start()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "g2vjb2ld70kcgijheglu7h01m.wav");

            theReallyCoolSound = Nautilus.Utility.AudioUtils.CreateSound(path, Nautilus.Utility.AudioUtils.StandardSoundModes_2D);
        }


        public void Update()
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetKeyDown(zxnskwnqdsp[currentIndex]))
                {
                    currentIndex++;
                    if(currentIndex == zxnskwnqdsp.Count)
                    {
                        Nautilus.Utility.AudioUtils.TryPlaySound(theReallyCoolSound, Nautilus.Utility.AudioUtils.BusPaths.PDAVoice, out Channel _);
                        Subtitles.Add("UNKNOWN: ▚┣ ▛┣ ▚┏ life ┗▄▖┅┗▖┣ down here ▞┛┏▛┣┗");
                        Subtitles.Add("PDA: Attempting to decode..");
                        Subtitles.Add("PDA: Transmission origin co-ordinates partially corrupted.");
                        currentIndex = 0;
                    }
                }
                else currentIndex = 0;
            }
        }
    }
}