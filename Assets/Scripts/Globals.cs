using System.Collections;
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

        public float RawSoundEffectsVolume
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

        public float SoundEffectsVolume
        {
            get
            {
                var game = PlayerPrefs.HasKey("GameVolume") ? PlayerPrefs.GetFloat("GameVolume") : 1f;

                return RawSoundEffectsVolume * game;
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
    }
}

