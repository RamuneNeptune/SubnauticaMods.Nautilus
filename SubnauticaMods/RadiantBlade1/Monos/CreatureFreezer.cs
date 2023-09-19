

namespace RadiantBlade.Monos
{
    public class CreatureFreezer : MonoBehaviour
    {
        public Animator[] animators;
        public Rigidbody rigid;
        public float timeStart;
        public float duration;

        public void Start()
        {
            timeStart = Time.time;
            duration = Time.time + 0.8f;
            rigid = GetComponent<Rigidbody>();
            animators = GetComponentsInChildren<Animator>(true);
        }

        public void Update()
        {
            timeStart = Time.time;
            rigid.velocity = Vector3.zero;

            if(animators.Length > 0) foreach (var a in animators) a.enabled = false;

            if(timeStart < duration) return;

            if(animators.Length > 0) foreach (var a in animators) a.enabled = true;
            DestroyImmediate(this);
        }
    }
}