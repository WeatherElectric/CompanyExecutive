namespace CompanyExecutive;

public class Main : MelonMod
{
    private static readonly MelonPreferences_Category Category = MelonPreferences.CreateCategory("Company Executive");
    
    private static MelonPreferences_Entry<bool> Enabled { get; set; } = null!;
    private static MelonPreferences_Entry<bool> ConsistentGive { get; set; } = null!;
    private static MelonPreferences_Entry<int> MoneyAmount { get; set; } = null!;
    private static MelonPreferences_Entry<bool> OverrideAmount { get; set; } = null!;

    private static bool _hasGiven;
    
    public override void OnInitializeMelon()
    {
        Category.CreateEntry("Enabled", true, "Enabled", "Self explanatory");
        ConsistentGive = Category.CreateEntry("ConsistentGive", true, "Consistently Give Money", "If enabled, your money will be set to a high amount every time the level is changed.");
        MoneyAmount = Category.CreateEntry("MoneyAmount", 99999999, "Money Amount", "The amount of money to give.");
        OverrideAmount = Category.CreateEntry("OverrideAmount", true, "Override Money Amount", "If enabled, your money will be set to the amount specified instead of added to. If disabled, it adds to your original starting money.");
        Category.SaveToFile(false);
    }
    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        if (!Enabled.Value) return;
        if (ConsistentGive.Value)
        {
            Terminal terminal = Object.FindObjectOfType<Terminal>();
            if (terminal == null) return;
            if (OverrideAmount.Value) terminal.groupCredits = MoneyAmount.Value;
            else terminal.groupCredits += MoneyAmount.Value;
        }
        else if (!_hasGiven)
        {
            Terminal terminal = Object.FindObjectOfType<Terminal>();
            if (terminal == null) return;
            if (OverrideAmount.Value) terminal.groupCredits = MoneyAmount.Value;
            else terminal.groupCredits += MoneyAmount.Value;
            _hasGiven = true;
        }
    }
}