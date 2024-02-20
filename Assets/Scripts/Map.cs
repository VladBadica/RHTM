using RHTMGame.Utils;
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

            var stepLines = GameObject.FindGameObjectsWithTag("StepLine");

            foreach (var stepLine in stepLines)
            {
                if (stepLine.TryGetComponent<Transform>(out var stepTransform))
                {
                    stepTransform.position = new Vector3(stepTransform.position.x, stepTransform.position.y - 1, stepTransform.position.z);
                }

                if (stepLine.TryGetComponent<StepCollision>(out var stepCollision))
                {
                    if (stepCollision.StepNumber == Globals.Instance.CurrentMap.CurrentIndex)
                    {
                        stepCollision.enabled = true;
                    }
                }

            }
        }
    }
}
