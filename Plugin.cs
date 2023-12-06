using BepInEx;

namespace CompanyExecutive
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // man fuck this shit this shit is a MONOBEHAVIOUR?? WHAT THE FUCK?
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            
        }
    }
}
