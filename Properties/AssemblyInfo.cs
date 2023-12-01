[assembly:
    MelonInfo(typeof(CompanyExecutive.Main), "CompanyExecutive", "1.0.0.0",
        "SoulWithMae", null)]
[assembly: MelonColor(ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("ZeekerssRBLX", "Lethal Company")]