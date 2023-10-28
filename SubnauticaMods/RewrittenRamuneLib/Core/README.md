## 🌐 **Welcome to RamuneLib**
An extremely cool shared project I created to make mod development way easier for myself!

### **Contents:**
- [⚡️ Core](#Core)
- [❔ Other](#Other)
- [🏴‍☠️ Piracy](#Piracy)
- [🧰 Utils](#Utils)

<br>

<!-------------------------------------------------------------------------------------->

## ⚡️ **[Core]()**
- **Initializer.cs**
  - Patches all harmony patches and checks for piracy, all in one line of code

- **Variables.cs**
  - Stores `public static` variables for:
    - Harmony instance for `PatchingUtils.RunSpecificPatch(..)`, set via `Initializer.Initialize(..)`
    - Logger used for `LoggerUtils`, set via `Initializer.Initialize(..)`
    - Path to `BepInEx\plugins\YourMod`
    - Path to `BepInEx\plugins\YourMod\Assets`
    - Path to `BepInEx\plugins\YourMod\Recipes` (used for `.WithJsonRecipe(..)`)

<br>

<!-------------------------------------------------------------------------------------->

## ❔ **[Other]()**
- **CustomPrefabExtensions.cs**
  - Extensions for `PrefabUtils.CreatePrefab(..)` so you can do this for example:
    ```cs
    var Prefab = PrefabUtils.CreatePrefab("GarryFishStew", "Garry fish stew", "A stew made from cooked garryfish.", ImageUtils.GetSprite("GarryFishStew"))
        .WithJsonRecipe("GarryFishStew", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorCookedFood)
        .WithUnlock(TechType.GarryFish)
        .WithSize(2, 1);
    ```

- **GlobalReferences.cs**
  - Contains a bunch of common `global using XYZ;` so I never have to add these to the top of every file ever again

<br>

<!-------------------------------------------------------------------------------------->

## 🏴‍☠️ **[Piracy]()**
- **Example**
  - Example

- **Example**
  - Example

- **Example**
  - Example

<br>

<!-------------------------------------------------------------------------------------->

## 🧰 **[Utils]()**
- **ImageUtils.cs**
  - Contains methods to grab sprites and textures from `BepInEx\plugins\YourMod\Assets`

- **JsonUtils.cs**
  - Contains a method to fetch a json recipe from `BepInEx\plugins\YourMod\Recipes`, you shouldn't ever need to use this because `.WithJsonRecipe(..)` already calls it for you

- **LoggerUtils.cs**
  - Contains methods to log to console, to screen (`ErrorMessage.AddMessage(..)`), and to subtitles (with optional delay and duration parameters)

- **PatchingUtils.cs**
  - Contains a method to run a specific harmony patch, currently only used to run piracy trolls

- **PrefabUtils.cs**
  - Contains methods to create a `CustomPrefab` and `RecipeData`

<!-------------------------------------------------------------------------------------->