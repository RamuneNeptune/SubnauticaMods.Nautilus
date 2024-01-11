

namespace Ramune.RadiantDepths.Items.Tools.RadiantBlade
{
    public class FreezeBitch : MonoBehaviour
    {
        public Animator[] animators;
        public Rigidbody rigid;
        public float timeStart;
        public float duration;


        public void Start()
        {
            timeStart = Time.time;
            duration = Time.time + 1.3f;
            rigid = GetComponent<Rigidbody>();
            animators = GetComponentsInChildren<Animator>(true);
        }


        public void Update()
        {
            timeStart = Time.time;
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
            
            if(animators.Length > 0) 
                animators.ForEach(a => a.enabled = false);

            if(timeStart < duration) 
                return;

            if(animators.Length > 0)
                animators.ForEach(a => a.enabled = true);

            DestroyImmediate(this);
        }
    }
}