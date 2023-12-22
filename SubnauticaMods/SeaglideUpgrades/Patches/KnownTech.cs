

using Newtonsoft.Json.Converters;

namespace Ramune.SeaglideUpgrades.Patches
{
    [HarmonyPatch(typeof(KnownTech))]
    public static class KnownTechPatch
    {
        [HarmonyPatch(nameof(KnownTech.Initialize)), HarmonyPostfix]
        public static void Initialize()
        {
            var analysisTech = new List<TechType>();

            foreach(var at in KnownTech.analysisTech)
            {
                analysisTech.Add(at.techType);
            }

            string json = JsonConvert.SerializeObject(analysisTech, Formatting.Indented, new TechTypeConverter());
            string path = Path.Combine(Variables.Paths.AssetsFolder, "AnalysisTech.json");

            File.WriteAllText(path, json);
        }
    }

    public class TechTypeConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}