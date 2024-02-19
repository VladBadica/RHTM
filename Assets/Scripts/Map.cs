using System.Collections.Generic;
using UnityEngine;

namespace RHTMGame
{
    public class Map
    {
        public string MapName;
        public string SongFile;
        public string Author;
        public List<Vector3> Steps;
        public int StepsCount => Steps.Count;
        public int CurrentIndex;

        public Map()
        {
            CurrentIndex = 0;
            Steps = new List<Vector3>();
        }

        public void Reset()
        {
            CurrentIndex = 0;
        }

        public void NextStep()
        {
            CurrentIndex++;
        }
    }
}
