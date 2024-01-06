

namespace Ramune.NukeEm.Monos
{
    public class BulletControl : MonoBehaviour
    {
        public Rigidbody rb;

        public void Update() => rb.velocity = rb.velocity.normalized * 200f;

        public void OnCollisionEnter(Collision col)
        {
            if(col.collider.TryGetComponent<LiveMixin>(out var livemixin))
                livemixin.TakeDamage(500f, default, DamageType.Normal, null);

            if(!col.collider.TryGetComponent<BreakableResource>(out var breakable))
                return;

            breakable.BreakIntoResources();
            transform.GetChild(0).parent = null;
            GameObject.Destroy(gameObject);
        }
    }
}