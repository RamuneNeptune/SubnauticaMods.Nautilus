

namespace Ramune.RamunesWorkbench
{
    [Menu("Ramune's Workbench")]
    public class Config : ConfigFile
    {
        public enum NodeStyle
        {
            Vanilla,
            Fancy
        };

        [Choice("Tab node style")]
        public NodeStyle tabStyle = NodeStyle.Fancy;
    }
}