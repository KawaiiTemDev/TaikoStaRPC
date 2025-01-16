using Scripts.Common.LoadingScreen;
using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace TaikoStar.Modules.RPC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EnsoHelpers
    {
        private static readonly DiscordRichPresence Instance = DiscordRichPresence.Instance;

        public static EnsoType CurrentEnsoType;

        public enum EnsoType
        {
            Normal,
            Scenario,
            Training,
            DonChanBand
        }

        // Method to set the subtitle instead of genre
        private static void SubtitleRPCState(string subtitle)
        {
            if (!string.IsNullOrEmpty(subtitle))
            {
                Instance.RichPresence.State = subtitle;
            }
            else
            {
                Instance.RichPresence.State = "Unknown";  // Default if no subtitle is available
            }
        }

        // Method to set the genre image and genre name for large image text
        private static void GenreRPCImageAndText(string genre)
        {
            string imageUrl = "https://raw.githubusercontent.com/KawaiiTemDev/kawaiitemdev/refs/heads/main/GenresTaiko/Ico.png";  // Default image
            string genreName = "Unknown";  // Default genre name

            switch (genre)
            {
                case "Pops":
                    imageUrl = "https://raw.githubusercontent.com/KawaiiTemDev/kawaiitemdev/refs/heads/main/GenresTaiko/Pop.png";
                    genreName = "Pop";
                    break;
                case "Anime":
                    imageUrl = "https://raw.githubusercontent.com/KawaiiTemDev/kawaiitemdev/refs/heads/main/GenresTaiko/Anime.png";
                    genreName = "Anime";
                    break;
                case "Vocalo":
                    imageUrl = "https://raw.githubusercontent.com/KawaiiTemDev/kawaiitemdev/refs/heads/main/GenresTaiko/Vocaloid.png";
                    genreName = "Vocaloid";
                    break;
                case "Variety":
                    imageUrl = "https://raw.githubusercontent.com/KawaiiTemDev/kawaiitemdev/refs/heads/main/GenresTaiko/Variety.png";
                    genreName = "Variety";
                    break;
                case "Classic":
                    imageUrl = "https://raw.githubusercontent.com/KawaiiTemDev/kawaiitemdev/refs/heads/main/GenresTaiko/Classic.png";
                    genreName = "Classic";
                    break;
                case "Game":
                    imageUrl = "https://raw.githubusercontent.com/KawaiiTemDev/kawaiitemdev/refs/heads/main/GenresTaiko/Game.png";
                    genreName = "Game";
                    break;
                case "Namco":
                    imageUrl = "https://raw.githubusercontent.com/KawaiiTemDev/kawaiitemdev/refs/heads/main/GenresTaiko/Namco.png";
                    genreName = "Namco";
                    break;
            }

            Instance.RichPresence.Assets.LargeImageKey = imageUrl;  // Set the large image based on the genre
            Instance.RichPresence.Assets.LargeImageText = genreName;  // Set the genre name as the large image text
        }

        // Method to set the level image based on the song's difficulty
        private static void LevelRPCImage(EnsoData.EnsoLevelType ensoLevel)
        {
            Plugin.Log.LogInfo($"ensoLevel: {ensoLevel}");
            switch (ensoLevel)
            {
                case EnsoData.EnsoLevelType.Easy:
                    Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_easy.png";
                    Instance.RichPresence.Assets.SmallImageText = "Easy";
                    break;
                case EnsoData.EnsoLevelType.Normal:
                    Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_normal.png";
                    Instance.RichPresence.Assets.SmallImageText = "Normal";
                    break;
                case EnsoData.EnsoLevelType.Hard:
                    Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_hard.png";
                    Instance.RichPresence.Assets.SmallImageText = "Hard";
                    break;
                case EnsoData.EnsoLevelType.Mania:
                    Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_mania.png";
                    Instance.RichPresence.Assets.SmallImageText = "Oni";
                    break;
                case EnsoData.EnsoLevelType.Ura:
                    Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_ura.png";
                    Instance.RichPresence.Assets.SmallImageText = "Ura";
                    break;
            }
        }

        // Main method to set up the screen information, now using subtitle instead of genre
        private static void EnsoScreenRPC(EnsoType ensoType, string songName, string subtitle, string genre, EnsoData.EnsoLevelType ensoLevel)
        {
            switch (ensoType)
            {
                case EnsoType.Normal:
                    Instance.RichPresence.Details = songName;
                    Instance.RichPresence.Assets.LargeImageText = "Taiko Mode";
                    SubtitleRPCState(subtitle);  // Using subtitle instead of genre
                    GenreRPCImageAndText(genre);  // Set large image and text based on genre
                    LevelRPCImage(ensoLevel);
                    break;
                case EnsoType.Scenario:
                    Instance.RichPresence.Details = songName;
                    Instance.RichPresence.Assets.LargeImageText = "Scenario";
                    SubtitleRPCState(subtitle);
                    GenreRPCImageAndText(genre);
                    LevelRPCImage(ensoLevel);
                    break;
                case EnsoType.Training:
                    Instance.RichPresence.Details = songName;
                    Instance.RichPresence.Assets.LargeImageText = "Training";
                    SubtitleRPCState(subtitle);
                    GenreRPCImageAndText(genre);
                    LevelRPCImage(ensoLevel);
                    break;
                case EnsoType.DonChanBand:
                    Instance.RichPresence.Details = songName;
                    Instance.RichPresence.Assets.LargeImageText = "DonChan Band";
                    SubtitleRPCState(subtitle);
                    GenreRPCImageAndText(genre);
                    LevelRPCImage(ensoLevel);
                    break;
            }

            Instance.UpdatePresence();
        }

        // Method to set Enso, now passing subtitle and genre instead of genre only
        public static void SetEnso(object sender, EventArgs args)
        {
            if (sender is not SongInfoPlayer songInfoPlayer) return;

            var ensoDataManager = GameObject.Find("CommonObjects/Datas/EnsoDataManager").GetComponent<EnsoDataManager>();
            var ensoLevelDifficulty = ensoDataManager.GetDiffCourse(0);

            // Access the UiLoadingSong component to get the subtitle and genre
            var loadingScreen = GameObject.FindObjectOfType<UiLoadingSong>();  // Find the UiLoadingSong component in the scene
            string subtitle = loadingScreen?.songSub.rawText ?? "Unknown";  // Default to "Unknown" if no subtitle is found
            string genre = songInfoPlayer.m_Genre.ToString() ?? "Unknown";  // Default to "Unknown" if no genre is found

            // Pass the song name, subtitle, and genre from the loading screen
            EnsoScreenRPC(CurrentEnsoType, songInfoPlayer.m_SongName, subtitle, genre, ensoLevelDifficulty);
        }
    }
}
