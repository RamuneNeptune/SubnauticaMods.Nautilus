

namespace Ramune.RadiantDepths.Items.Tools.RadiantBlade
{
    public struct RadiantBladeAttack
    {
        public string Name;


        public string HandText;


        public Action<GameObject> Attack;


        public RadiantBladeAttack(string name, string handText, Action<GameObject> attack)
        {
            Name = name;
            HandText = handText;
            Attack = attack;
        }
    }
}