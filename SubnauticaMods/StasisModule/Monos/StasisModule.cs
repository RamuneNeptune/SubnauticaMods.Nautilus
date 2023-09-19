

namespace Ramune.StasisModule.Monos
{
    public class StasisModule : MonoBehaviour
    {
        public bool isDeployed;

        public void Start()
        {
            gameObject.GetComponentInChildren<Vehicle>();

            if (vehicle.GetType() == typeof(SeaMoth)) return;
            else if (vehicle.GetType() == typeof(Exosuit)) return;
        }

        public void Update()
        {
            if(!isDeployed) return;

        }

        public void DeployStasis()
        {
            isDeployed = true;
        }
    }
}