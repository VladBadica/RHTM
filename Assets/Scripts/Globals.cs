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
    }
}

