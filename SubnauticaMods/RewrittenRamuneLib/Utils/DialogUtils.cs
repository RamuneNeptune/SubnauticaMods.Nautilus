

namespace RamuneLib.Utils
{
    public static class DialogUtils
    {
        public static Dialog.DialogButton CreateButton(string text, Action action) => new(text, action);


        public class Dialog
        {
            internal DialogButton LB = DialogButton.Empty;
            internal DialogButton RB = DialogButton.Empty;
            internal string text = "";


            private static IEnumerator ShowCoroutine()
            {
                yield break;
            }


            public static void Show()
            {
                CoroutineHost.StartCoroutine(ShowCoroutine());
            }


            public class DialogButton
            {
                public Action Action = null;
                public string Text = null;


                internal DialogButton() { }


                internal DialogButton(string text, Action action)
                {
                    Text = text;
                    Action = action;
                }


                internal static readonly DialogButton Empty = new();
            }
        }
    }
}