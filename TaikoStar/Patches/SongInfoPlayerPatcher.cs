using System;
using System.Diagnostics.CodeAnalysis;
using HarmonyLib;

namespace TaikoStar.Patches;
//I don't know what this is for so I'm just keeping this here
[HarmonyPatch]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SongInfoPlayerPatcher {
    public EventHandler OnSongInfoPlayerFinished;

    public static SongInfoPlayerPatcher Instance { get; private set; } = new ();
    
    [HarmonyPatch(typeof(SongInfoPlayer), nameof(SongInfoPlayer.Start))]
    [HarmonyPostfix]
    public static void SongInfoPlayer_Postfix(SongInfoPlayer __instance) {
        Instance.OnSongInfoPlayerFinished?.Invoke(__instance, EventArgs.Empty);
    } 
}