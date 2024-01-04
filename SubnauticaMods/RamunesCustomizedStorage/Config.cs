

namespace Ramune.RamunesCustomizedStorage
{
    [Menu("Ramune's Customized Storage")]
    public class Config : ConfigFile
    {
        public const string tooltip = "Changes are applied on game restart. Vanilla: ";
        public const float heightMinValue = 1f;
        public const float heightMaxValue = 30f;
        public const float widthMinValue = 1f;
        public const float widthMaxValue = 10f;
        public const float step = 1f;

        /*
        public void OnChangeAutomatic(ToggleChangedEventArgs args)
        {
            if(args.Value is true)
            {
                
            }
        }
        */

        [Button("Close game", Tooltip = "Use this shortcut to apply changes faster", Order = 0)]
        public void Restart(ButtonClickedEventArgs _) => Application.Quit();

        [Toggle("<color=#f1c353>Inventory size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 1)]
        public bool divider_inventory;

        [Slider(" • Inventory width (x)", Format = "{0:F1}", DefaultValue = 6f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "6", Order = 2)]
        public float width_inventory = 6f;

        [Slider(" • Inventory height (y)", Format = "{0:F1}", DefaultValue = 8f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "8", Order = 3)]
        public float height_inventory = 8f;

        //[Toggle(" • Automatically apply changes without restart (be careful)"), OnChange(nameof(OnChangeAutomatic))]
        //public bool inventory_automatic = false;


        [Toggle("<color=#f1c353>Lifepod storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 5)]
        public bool divider_lifepod;

        [Slider(" • Lifepod storage width (x)", Format = "{0:F1}", DefaultValue = 4f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "4", Order = 6)]
        public float width_lifepod = 4f;

        [Slider(" • Lifepod storage height (y)", Format = "{0:F1}", DefaultValue = 8f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "8", Order = 7)]
        public float height_lifepod = 8f;
        /*
        [Button("Apply lifepod changes", Order = 8)]
        public void ApplyLifepod(ButtonClickedEventArgs _)
        {
            if(EscapePod.main is null)
                return;

            if(EscapePod.main.storageContainer is null)
                return;

            _Resize(EscapePod.main.storageContainer, "Lifepod storage", ref width_lifepod, ref height_lifepod);
        }
        */


        [Toggle("<color=#f1c353>Standing locker storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 9)]
        public bool divider_locker;

        [Slider(" • Standing locker storage width (x)", Format = "{0:F1}", DefaultValue = 6f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "6", Order = 10)]
        public float width_locker = 6f;

        [Slider(" • Standing locker storage height (y)", Format = "{0:F1}", DefaultValue = 8f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "8", Order = 11)]
        public float height_locker = 8f;



        [Toggle("<color=#f1c353>Wall locker storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 12)]
        public bool divider_wallLocker;

        [Slider(" • Wall locker storage width (x)", Format = "{0:F1}", DefaultValue = 5f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "5", Order = 13)]
        public float width_wallLocker = 5f;

        [Slider(" • Wall locker storage height (y)", Format = "{0:F1}", DefaultValue = 6f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "6", Order = 14)]
        public float height_wallLocker = 6f;



        [Toggle("<color=#f1c353>Prawn Suit storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 15)]
        public bool divider_prawnSuit;

        [Slider(" • Prawn Suit storage width (x)", Format = "{0:F1}", DefaultValue = 6f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "6", Order = 16)]
        public float width_prawnSuit = 4f;

        [Slider(" • Prawn Suit storage height (y)", Format = "{0:F1}", DefaultValue = 4f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "4", Order = 17)]
        public float height_prawnSuit = 6f;

        [Slider(" • Prawn Suit storage height per module", Format = "{0:F1}", DefaultValue = 1f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "1", Order = 18)]
        public float height_prawnSuitModule = 1f;



        [Toggle("<color=#f1c353>Seamoth storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 19)]
        public bool divider_seamoth;

        [Slider(" • Seamoth storage width per module", Format = "{0:F1}", DefaultValue = 4f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "4", Order = 20)]
        public float width_seamoth = 4f;

        [Slider(" • Seamoth storage height per module", Format = "{0:F1}", DefaultValue = 4f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "4", Order = 21)]
        public float height_seamoth = 4f;



        [Toggle("<color=#f1c353>Cyclops storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 22)]
        public bool divider_cyclops;

        [Slider(" • Cyclops storage width (x)", Format = "{0:F1}", DefaultValue = 3f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "3", Order = 23)]
        public float width_cyclops = 3f;

        [Slider(" • Cyclops storage height (y)", Format = "{0:F1}", DefaultValue = 6f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "6", Order = 24)]
        public float height_cyclops = 6f;



        [Toggle("<color=#f1c353>Bio reactor storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 25)]
        public bool divider_bioReactor;

        [Slider(" • Bio reactor storage width (x)", Format = "{0:F1}", DefaultValue = 4f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "4", Order = 26)]
        public float width_bioReactor = 4f;

        [Slider(" • Bio reactor storage height (y)", Format = "{0:F1}", DefaultValue = 4f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "4", Order = 27)]
        public float height_bioReactor = 4f;



        [Toggle("<color=#f1c353>Waterproof locker storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 28)]
        public bool divider_waterproofLocker;

        [Slider(" • Waterproof locker storage width (x)", Format = "{0:F1}", DefaultValue = 4f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "4", Order = 29)]
        public float width_waterproofLocker = 4f;

        [Slider(" • Waterproof locker storage height (y)", Format = "{0:F1}", DefaultValue = 4f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "4", Order = 30)]
        public float height_waterproofLocker = 4f;



        [Toggle("<color=#f1c353>Carry-all storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 31)]
        public bool divider_carryAll;

        [Slider(" • Carry-all storage width (x)", Format = "{0:F1}", DefaultValue = 3f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "3", Order = 32)]
        public float width_carryAll = 3f;

        [Slider(" • Carry-all storage height (y)", Format = "{0:F1}", DefaultValue = 3f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "3", Order = 33)]
        public float height_carryAll = 3f;



        [Toggle("<color=#f1c353>Water filtration storage size:</color> <alpha=#00>----------------------------------------------------------------------------</alpha>", Order = 34)]
        public bool divider_filtration;

        [Slider(" • Water filtration storage width (x)", Format = "{0:F1}", DefaultValue = 2f, Min = widthMinValue, Max = widthMaxValue, Step = step, Tooltip = tooltip + "2", Order = 35)]
        public float width_filtration = 2f;

        [Slider(" • Water filtration storage height (y)", Format = "{0:F1}", DefaultValue = 2f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "2", Order = 36)]
        public float height_filtration = 2f;

        [Slider(" • Water filtration max salt", Format = "{0:F1}", DefaultValue = 2f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "2", Order = 37)]
        public float salt_filtration = 2f;

        [Slider(" • Water filtration max water", Format = "{0:F1}", DefaultValue = 2f, Min = heightMinValue, Max = heightMaxValue, Step = step, Tooltip = tooltip + "2", Order = 38)]
        public float water_filtration = 2f;
    }
}