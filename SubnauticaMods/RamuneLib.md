## 🌐 **Welcome to RamuneLib**
**Note:** RamuneLib is **NOT** a mod, it's a [shared project](https://learn.microsoft.com/en-us/xamarin/cross-platform/app-fundamentals/shared-projects?tabs=windows#what-is-a-shared-project) that compiles itself into your mod's .dll

A super cool shared project I created to make mod development easier, troll pirates, and reduce the number of lines of code on my screen (Sponsored by [OCD](https://iocdf.org/about-ocd/))

### **Contents:**
- [⚡️ Core](#Core)
- [❔ Other](#Other)
- [🏴‍☠️ Piracy](#Piracy)
- [🧰 Utils](#Utils)

<br>

<!-------------------------------------------------------------------------------------->

## ⚡️ **[Core]()**
- ### **Initializer.cs**
  - Patches all harmony patches and checks for piracy, all in one line of code

- ### **Variables.cs**
  - Stores `public static` variables for:
    - Harmony instance for `PatchingUtils.RunSpecificPatch(..)`, set via `Initializer.Initialize(..)`
    - Logger used for `LoggerUtils`, set via `Initializer.Initialize(..)`
    - Path to `BepInEx\plugins\YourMod`
    - Path to `BepInEx\plugins\YourMod\Assets`
    - Path to `BepInEx\plugins\YourMod\Recipes` (used for `.WithJsonRecipe(..)`)

<br>

<!-------------------------------------------------------------------------------------->

## ❔ **[Other]()**
- ### **CustomPrefabExtensions.cs**
  - Extensions for `PrefabUtils.CreatePrefab(..)` so you can do this for example:
    ```cs
    var Prefab = PrefabUtils.CreatePrefab("GarryFishStew", "Garry fish stew", "A stew made from cooked garryfish.", ImageUtils.GetSprite("GarryFishStew"))
        .WithJsonRecipe("GarryFishStew", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorCookedFood)
        .WithUnlock(TechType.GarryFish)
        .WithSize(2, 1);
    ```

- ### **GlobalReferences.cs**
  - Contains a bunch of common `global using XYZ;` so I never have to add these to the top of every file ever again

<br>

<!-------------------------------------------------------------------------------------->

## 🏴‍☠️ **[Piracy]()**
- ### **Example**
  - Example

- ### **Example**
  - Example

- ### **Example**
  - Example

<br>

<!-------------------------------------------------------------------------------------->

## 🧰 **[Utils]()**
- ### **ImageUtils.cs**
  - Contains methods to load custom sprites and textures

    - `ImageUtils.GetSprite(string filename) : Atlas.Sprite`
      - Returns: an Atlas.Sprite using a .png image from `BepInEx\plugins\YourMod\Assets\filename.png`
      - Example:
        ```cs
        var sprite = ImageUtils.GetSprite("MegaBlade");
        ```

    - `ImageUtils.GetSprite(TechType techType) : Atlas.Sprite`
      - Returns: an Atlas.Sprite from the input TechType
      - Example:
        ```cs
        var sprite = ImageUtils.GetSprite(TechType.Knife);
        ```

    - `ImageUtils.GetSprite(string filename) : UnityEngine.Sprite`
      - Returns: a UnityEngine.Sprite using a .png image from `BepInEx\plugins\YourMod\Assets\filename.png`
      - Example:
        ```cs
        var sprite = ImageUtils.GetUnitySprite("MegaBlade");
        ```

- ### **JsonUtils.cs**
  - Contains a method to fetch a json recipe from `BepInEx\plugins\YourMod\Recipes`, you shouldn't ever need to use this because `.WithJsonRecipe(..)` already calls it for you

- ### **LoggerUtils.cs**
  - Contains methods to log to console, to screen (`ErrorMessage.AddMessage(..)`), and to subtitles (with optional delay and duration parameters)

    - `LoggerUtils.LogScreen(string message)`
      - What it does: logs a message on screen using the games `ErrorMessage.AddMessage(..)` system
      - Example:
        ```cs
        LoggerUtils.LogScreen("We've been trying to reach you about your cars extended warranty.");
        ```

    - `LoggerUtils.LogInfo(string message)`
      - What it does: logs a message to the BepInEx console / logfile as `[Info : YourMod] Message`
      - Example:
        ```cs
        LoggerUtils.LogInfo("This is an info message.");
        ```

    - `LoggerUtils.LogDebug(string message)`
      - What it does: logs a message to the BepInEx console / logfile as `[Debug : YourMod] Message`
      - Example:
        ```cs
        LoggerUtils.LogDebug("This is a debug message.");
        ```

    - `LoggerUtils.LogWarning(string message)`
      - What it does: logs a message to the BepInEx console / logfile as `[Warning : YourMod] Message`
      - Example:
        ```cs
        LoggerUtils.LogWarning("This is a warning message.");
        ```

    - `LoggerUtils.LogError(string message)`
      - What it does: logs a message to the BepInEx console / logfile as `[Error : YourMod] Message`
      - Example:
        ```cs
        LoggerUtils.LogError("This is an error message.");
        ```

    - `LoggerUtils.LogFatal(string message)`
      - What it does: logs a message to the BepInEx console / logfile as `[Fatal : YourMod] Message`
      - Example:
        ```cs
        LoggerUtils.LogFatal("This is a fatal message.");
        ```

    - `LoggerUtils.LogSubtitle(string message, float duration = 5f, float delay = -1f)`
      - What it does: logs a message on screen using the games `Subtitles.Add(..)`
      - Example:
        ```cs
        // Adds a subtitle that lasts 20 seconds
        LoggerUtils.LogSubtitle("PDA: Transmission coordinates received", 20f);
        ```

- ### **PatchingUtils.cs**
  - Contains a method to run a specific harmony patch

    - `PatchingUtils.RunSpecificPatch(Type targetType, string methodName, HarmonyMethod patchMethod, HarmonyPatchType patchType)`
      - What it does: Runs a singular specified harmony patch
      - Example: 
      ```cs
      // Prefix
      PatchingUtils.RunSpecificPatch(typeof(Player), nameof(Player.Awake), new HarmonyMethod(typeof(YourPatchingClass), nameof(YourPatchingClass.PatchMethod)), HarmonyPatchType.Prefix);

      // Postfix
      PatchingUtils.RunSpecificPatch(typeof(Player), nameof(Player.Awake), new HarmonyMethod(typeof(YourPatchingClass), nameof(YourPatchingClass.PatchMethod)), HarmonyPatchType.Postfix);

      // Transpiler
      PatchingUtils.RunSpecificPatch(typeof(Player), nameof(Player.Awake), new HarmonyMethod(typeof(YourPatchingClass), nameof(YourPatchingClass.PatchMethod)), HarmonyPatchType.Transpiler);
      ```

- ### **PrefabUtils.cs**
  - Contains methods to create a `CustomPrefab` and `RecipeData`

    - `PrefabUtils.CreatePrefab(string id, string name, string description, Atlas.Sprite sprite) : CustomPrefab`

      - Returns: A custom prefab set with all the specified arguments
      - Example:
        ```cs
        var Prefab = PrefabUtils.CreatePrefab("MegaBlade", "Mega blade", "An absolutely devestating mega blade.", ImageUtils.GetSprite("MegaBlade"));
        ```

    - `PrefabUtils.CreatePrefab(string id, string name, string description, UnityEngine.Sprite sprite) : CustomPrefab`

      - Returns: A custom prefab set with all the specified arguments
      - Example:
        ```cs
        var Prefab = PrefabUtils.CreatePrefab("MegaBlade", "Mega blade", "An absolutely devestating mega blade.", ImageUtils.GetUnitySprite("MegaBlade"));
        ```

    - `PrefabUtils.CreateRecipe(int craftAmount, params Ingredient[] ingredients) : RecipeData`

      - Returns: A new RecipeData set with all the specified arguments
      - Example:
        ```cs
        var Recipe = PrefabUtils.CreateRecipe(1, 
            new Ingredient(TechType.Titanium, 4),
            new Ingredient(TechType.Lithium, 3),
            new Ingredient(TechType.Copper, 2),
            new Ingredient(TechType.Quartz, 1));
        ```

<!-------------------------------------------------------------------------------------->