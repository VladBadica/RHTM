using UnityEngine;
using RHTMGame.Utils;

public class MapLoader : MonoBehaviour
{
    public GameObject StepLine;

    // Start is called before the first frame update
    void Start()
    {
        Globals.Instance.PerformanceTracker.Reset();

        var stepLines = GameObject.FindGameObjectsWithTag("StepLine");
        foreach (var stepLine in stepLines)
        {
            Destroy(stepLine);
        }

        var song = Resources.Load<AudioClip>($"Songs/{Globals.Instance.CurrentMap.SongFile}");
        AudioSource.PlayClipAtPoint(song, Vector3.zero, 1f);

        for (var i = 0; i < Globals.Instance.CurrentMap.Steps.Count; i++)
        {
            var step = Globals.Instance.CurrentMap.Steps[i];
            if (StepLine.TryGetComponent<Transform>(out var stepTransform))
            {
                var stepObj = Instantiate(StepLine, new Vector3(step.x, step.y, 0), stepTransform.rotation);

                if(stepObj.TryGetComponent<StepCollision>(out var stepCollision))
                {
                    stepCollision.StepNumber = i;
                }
            }
        }           
    }
}
