

namespace Ramune.RadiantBlade.Monos
{
    public partial class RadiantBlade : HeatBlade
    {
        public void Update()
        {
            if(!energy.HasItem())
            {
                HandReticle.main.SetText(HandReticle.TextType.Use, "Missing power source", false);
                HandReticle.main.SetIcon(HandReticle.IconType.None, 1f);
                return;
            }

            if(Input.GetKeyDown(KeyCode.Q) & !Cursor.visible) return;

            HandReticle.main.SetText(HandReticle.TextType.Use, "Switch mode", false, GameInput.Button.Deconstruct);
            HandReticle.main.SetIcon(HandReticle.IconType.None, 1f);
        }
    }
}