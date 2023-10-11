

namespace Ramune.PassiveWarpersAfterQuarantineShutdown.Monos
{
    public class WarperBefriender : MonoBehaviour
    {
        public Creature creature;
        public bool isFriend = false;

        public void Start()
        {
            creature = gameObject.GetComponent<Warper>();
        }

        public void Update()
        {
            if(isFriend) Destroy(this);

            if(!StoryGoalCustomEventHandler.main.gunDisabled) return;
            
            creature.SetFriend(Player.main.gameObject, float.PositiveInfinity);   
            isFriend = true;

            Log("ur my friend now :D").WithColor(Colors.Yellow);
        }
    }
}