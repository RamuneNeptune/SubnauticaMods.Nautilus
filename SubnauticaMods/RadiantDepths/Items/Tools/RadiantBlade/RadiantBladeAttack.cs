

namespace Ramune.RadiantDepths.Items.Tools.RadiantBlade
{
    public struct RadiantBladeAttack
    {
        public string Name;


        public string HandText;


        public Color Color;


        public Action<GameObject, Renderer> Attack;


        public RadiantBladeAttack(string name, string handText, Color color, Action<GameObject, Renderer> attack)
        {
            Name = name;
            HandText = handText;
            Color = color;
            Attack = attack;
        }
    }
}