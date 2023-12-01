namespace CompanyExecutive;

public class Main : MelonMod
{
    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        Terminal terminal = Object.FindObjectOfType<Terminal>();
        terminal.groupCredits = 999999999;
    }
}