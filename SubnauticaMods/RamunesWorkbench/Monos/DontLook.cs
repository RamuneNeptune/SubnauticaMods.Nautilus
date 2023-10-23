

namespace Ramune.RamunesWorkbench.Monos
{
    public class DontLook : MonoBehaviour
    {
        public List<KeyCode> zxnskwnqdsp = new() { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow,KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A };
        public Sound sound;
        public int currentIndex = 0;


        public void Start()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "g2vjb2ld70kcgijheglu7h01m.wav");
            sound = AudioUtils.CreateSound(path, AudioUtils.StandardSoundModes_3D);
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
                        AudioUtils.TryPlaySound(sound, AudioUtils.BusPaths.PDAVoice, out Channel _);
                        currentIndex = 0;
                    }
                }
                else currentIndex = 0;
            }
        }
    }
}