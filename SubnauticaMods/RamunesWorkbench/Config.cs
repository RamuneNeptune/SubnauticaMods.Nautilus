

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

        [Toggle("Toggle light/glow", Tooltip = "Requires restart! Toggles the purple light/glow around the workbench when you open it.")]
        public bool light = true;

        [Toggle("Toggle fade animation", Tooltip = "Toggles the smooth rise & fall animation of the workbench texture.")]
        public bool animation = true;
    }
}