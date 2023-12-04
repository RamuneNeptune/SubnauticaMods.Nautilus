

namespace Ramune.PersistentCommands
{
    [Menu("Persistent Commands")]
    public class Config : ConfigFile
    {
        [Choice("Show FPS", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string optio = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Craft everything for free", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option1 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("No blueprint requirements", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option2 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("No energy usage/cost", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option3 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("No oxygen usage/cost", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option4 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("No crush depth damage", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option5 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("No radiation damage", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option6 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("No hunger & thirst", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Invisible to creatures", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option7 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Give godmode to creatures", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option8 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Instant kill creatures", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option9 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Fast building", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option10 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Fast growing", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option11 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Fast hatching", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option12 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Fast scanning", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option13 = "<color=#b74855><b>Disabled</b></color>";

        [Choice("Fast filtration machine", Options = new string[] { "<color=#1BD769><b>Enabled</b></color>", "<color=#b74855><b>Disabled</b></color>" })]
        public string option14 = "<color=#b74855><b>Disabled</b></color>";
    }
}