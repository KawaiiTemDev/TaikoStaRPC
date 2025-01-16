using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using TaikoStar.Modules.RPC;
using TaikoStar.Patches;

namespace TaikoStar;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin {
    public new static ManualLogSource Log;

    public override void Load() {
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        
        //removed features as these mods already exist
        //Harmony.CreateAndPatchAll(typeof(ReplaceVersionText));
        //Harmony.CreateAndPatchAll(typeof(SkipSplashScreen));
        //Harmony.CreateAndPatchAll(typeof(SkipCoinAndReward));
        
        // Discord Rich Presence
        DiscordRichPresence.Instance.Initialize();
        AddComponent<RPCMonoBehavior>();
        Harmony.CreateAndPatchAll(typeof(SongInfoPlayerPatcher));
    }
}