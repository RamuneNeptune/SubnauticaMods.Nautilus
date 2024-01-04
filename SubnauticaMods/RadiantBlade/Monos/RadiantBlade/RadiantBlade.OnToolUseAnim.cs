

namespace Ramune.RadiantBlade.Monos
{
    public partial class RadiantBlade : HeatBlade
    {
        public override void OnToolUseAnim(GUIHand hand)
        {
            base.OnToolUseAnim(hand);

            Vector3 vector = default;
            GameObject gameObject = null;
            UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, attackDist, ref gameObject, ref vector, true);

            if (gameObject == null) return;
            var livemixin = gameObject.FindAncestor<LiveMixin>();

            if(IsValidTarget(livemixin))
            {
                if(livemixin)
                {
                    UseSeismic(gameObject.GetComponent<Creature>());
                }
            }
        }
    }
}