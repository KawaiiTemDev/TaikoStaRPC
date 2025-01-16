using System.Diagnostics.CodeAnalysis;
using UnityEngine.SceneManagement;

namespace TaikoStar.Modules.RPC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class RPCHelpers
    {
        private static readonly DiscordRichPresence Instance = DiscordRichPresence.Instance;

        public static void SceneChange(Scene scene, LoadSceneMode mode)
        {
            switch (scene.name)
            {
                case "Boot":
                    Instance.RichPresence.Details = "Loading the game..."; // Translated
                    Instance.RichPresence.State = "";
                    Instance.RichPresence.Assets.SmallImageKey = "";
                    Instance.RichPresence.Assets.SmallImageText = "";
                    Instance.RichPresence.Assets.LargeImageKey = ""; // Reset large image
                    Instance.RichPresence.Assets.LargeImageText = ""; // Reset large image text
                    break;
                case "Title":
                    Instance.RichPresence.Details = "Title screen"; // Translated
                    Instance.RichPresence.State = "";
                    Instance.RichPresence.Assets.SmallImageKey = "";
                    Instance.RichPresence.Assets.SmallImageText = "";
                    Instance.RichPresence.Assets.LargeImageKey = ""; // Reset large image
                    Instance.RichPresence.Assets.LargeImageText = ""; // Reset large image text
                    break;
                case "MainMenu":
                    Instance.RichPresence.Details = "Omiko City: Selecting mode"; // Translated
                    Instance.RichPresence.State = "";
                    Instance.RichPresence.Assets.SmallImageKey = "";
                    Instance.RichPresence.Assets.SmallImageText = "";
                    Instance.RichPresence.Assets.LargeImageKey = ""; // Reset large image
                    Instance.RichPresence.Assets.LargeImageText = ""; // Reset large image text
                    break;
                case "ThunderShrine":
                    Instance.RichPresence.Details = "Thunder Shrine: Selecting mode"; // Translated
                    Instance.RichPresence.State = "";
                    Instance.RichPresence.Assets.SmallImageKey = "";
                    Instance.RichPresence.Assets.SmallImageText = "";
                    Instance.RichPresence.Assets.LargeImageKey = ""; // Reset large image
                    Instance.RichPresence.Assets.LargeImageText = ""; // Reset large image text
                    break;
                case "SongSelect":
                    Instance.RichPresence.Details = "Selecting song"; // Translated
                    Instance.RichPresence.State = "Taiko Mode"; // Translated
                    Instance.RichPresence.Assets.SmallImageKey = "";
                    Instance.RichPresence.Assets.SmallImageText = "";
                    Instance.RichPresence.Assets.LargeImageKey = ""; // Reset large image
                    Instance.RichPresence.Assets.LargeImageText = ""; // Reset large image text
                    break;
                case "SongSelectTraining":
                    Instance.RichPresence.Details = "Selecting song"; // Translated
                    Instance.RichPresence.State = "Training"; // Translated
                    Instance.RichPresence.Assets.SmallImageKey = "";
                    Instance.RichPresence.Assets.SmallImageText = "";
                    Instance.RichPresence.Assets.LargeImageKey = ""; // Reset large image
                    Instance.RichPresence.Assets.LargeImageText = ""; // Reset large image text
                    break;
                case "Enso":
                    EnsoHelpers.CurrentEnsoType = EnsoHelpers.EnsoType.Normal;
                    break;
                case "EnsoScenario":
                    EnsoHelpers.CurrentEnsoType = EnsoHelpers.EnsoType.Scenario;
                    break;
                case "EnsoTrainingFull":
                    EnsoHelpers.CurrentEnsoType = EnsoHelpers.EnsoType.Training;
                    break;
                case "EnsoDonChanBand":
                    EnsoHelpers.CurrentEnsoType = EnsoHelpers.EnsoType.DonChanBand;
                    break;
                default:
                    // Reset large image and text when transitioning out of a song
                    Instance.RichPresence.Assets.LargeImageKey = ""; // Reset large image
                    Instance.RichPresence.Assets.LargeImageText = ""; // Reset large image text
                    break;
            }

            Instance.UpdatePresence();
        }
    }
}
