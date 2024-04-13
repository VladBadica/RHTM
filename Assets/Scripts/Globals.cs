using System;
using System.Collections.Generic;
using UnityEngine;

namespace RHTMGame.Utils
{
    public enum Direction
    {
        None = 0,
        Left = 1,
        Right = 2
    };

    public class Globals
    {
        //https://danqzq.itch.io/leaderboard-creator
        public string PublicLeaderboardKey = "31c089b4f911a06eb6b5a91e3d72af80758d47861172fc3fe8d0a9a1046659fe";

        private static Globals _globals = null;
        public static Globals Instance => _globals ??= new Globals();

        public Direction TrackballDirection { get; set; }

        public void ChangeTrackballDirection()
        {
            if (TrackballDirection == Direction.Left) 
            {
                TrackballDirection = Direction.Right;
            }
            else if (TrackballDirection == Direction.Right)
            {
                TrackballDirection = Direction.Left;
            }
        }
    
        public void QuitGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }

        public List<Map> AllMaps { get; set; }

        public Map CurrentMap { get; set; }

        public bool TrackCompleted = false;

        private PerformanceTracker _performanceTracker = null;
        public PerformanceTracker PerformanceTracker => _performanceTracker ??= new PerformanceTracker();

        public float RawMusicVolume
        {
            get
            {
                return PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 1f;
            }
            set
            {
                PlayerPrefs.SetFloat("MusicVolume", value);
            }
        }

        public float RawEffectsVolume
        {
            get
            {
                return PlayerPrefs.HasKey("SoundEffectsVolume") ? PlayerPrefs.GetFloat("SoundEffectsVolume") : 1f;
            }
            set
            {
                PlayerPrefs.SetFloat("SoundEffectsVolume", value);
            }
        }

        public float MusicVolume
        {
            get
            {
                var game = PlayerPrefs.HasKey("GameVolume") ? PlayerPrefs.GetFloat("GameVolume") : 1f;

                return RawMusicVolume * game;
            }
        }

        public float EffectsVolume
        {
            get
            {
                var game = PlayerPrefs.HasKey("GameVolume") ? PlayerPrefs.GetFloat("GameVolume") : 1f;

                return RawEffectsVolume * game;
            }
        }

        public float GameVolume
        {
            get
            {
                return PlayerPrefs.HasKey("GameVolume") ? PlayerPrefs.GetFloat("GameVolume") : 1f;
            }
            set
            {
                PlayerPrefs.SetFloat("GameVolume", value);
            }
        }

        public KeyCode Action1Key
        {
            get
            {
                return PlayerPrefs.HasKey("Action1Key") ? (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action1Key"), true) : KeyCode.Z;
            }
            set
            {
                PlayerPrefs.SetString("Action1Key", value.ToString());
            }
        }
        public KeyCode Action2Key
        {
            get
            {
                return PlayerPrefs.HasKey("Action2Key") ? (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action2Key"), true) : KeyCode.X;
            }
            set
            {
                PlayerPrefs.SetString("Action2Key", value.ToString());
            }
        }
    }
}

