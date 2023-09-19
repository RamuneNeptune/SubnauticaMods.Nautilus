

namespace RamuneLib
{
    public static partial class Utilities
    {
        public class ScreenLogger
        {
            private readonly string text;

            public ScreenLogger(string text)
            {
                this.text = text;
            }

            public static ScreenLogger Log(string text)
            {
                return new ScreenLogger(text);
            }

            public void WithColor(Colors color)
            {
                ErrorMessage.AddMessage($"{color.GetValue()}{text}</color>");
            }
        }
    }
}