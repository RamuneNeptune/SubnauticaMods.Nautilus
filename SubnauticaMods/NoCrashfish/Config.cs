

namespace Ramune.NoCrashfish
{
    [Menu("Cyclops Customizable Colors")]
    public class Config : ConfigFile
    {
        [ColorPicker("Main walls", Advanced = true)]
        public Color one;

        [ColorPicker("Main lights", Advanced = true)]
        public Color two;

        [ColorPicker("Walls floor (bottom)", Advanced = true)]
        public Color three;

        [ColorPicker("Floor outer", Advanced = true)]
        public Color four;

        [ColorPicker("Floor inner", Advanced = true)]
        public Color five;

        [ColorPicker("Floor outer ring", Advanced = true)]
        public Color six;

        [ColorPicker("???", Advanced = true)]
        public Color seven;

        [ColorPicker("Rest of floor (some inner missing)", Advanced = true)]
        public Color eight;

        [ColorPicker("Locker wall", Advanced = true)]
        public Color nine;

        [ColorPicker("Main roof lights", Advanced = true)]
        public Color ten;

        [ColorPicker("Main roof outer", Advanced = true)]
        public Color eleven;

        [ColorPicker("Main roof inner", Advanced = true)]
        public Color twelve;

        [ColorPicker("Doorway trim decoy launcher", Advanced = true)]
        public Color thirteen;

        [ColorPicker("Doorway trim hatch room", Advanced = true)]
        public Color fourteen;

        [ColorPicker("Hatch room roof", Advanced = true)]
        public Color fifteen;

        [ColorPicker("Most wall decals (mainly hatch room & locker wall)", Advanced = true)]
        public Color sixteen;

        [ColorPicker("Hatch room decals", Advanced = true)]
        public Color seventeen;

        [ColorPicker("Doorway trim main doors floor (bottom)", Advanced = true)]
        public Color eighteen;

        [ColorPicker("> Left door (next to decoys)", Advanced = true)]
        public Color leftdoor;

        [ColorPicker("> Right door (next to decoys)", Advanced = true)]
        public Color rightdoor;
    }
}