

namespace Ramune.StasisModule.Monos
{
    public class StasisModule : MonoBehaviour
    {
        public static bool isDeployed;
        public static GameObject _gameObject;

        public void Start()
        {
            _gameObject = GetComponent<Transform>().gameObject;
        }

        public void Update()
        {
            //if(!isDeployed) return;
        }

        public static void DeployStasis(Vehicle vehicle, int idk, int idk_, float idk__)
        {
            isDeployed = true;
            StasisRifle.sphere.transform.parent = _gameObject.transform;
            StasisRifle.sphere.Shoot(_gameObject.transform.position, _gameObject.transform.rotation, 25f, 3f);
            StasisRifle.sphere.EnableField();
        }
    }
}