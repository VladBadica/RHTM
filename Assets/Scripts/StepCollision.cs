using UnityEngine;
using RHTMGame.Utils;
using UnityEngine.SceneManagement;

public class StepCollision : MonoBehaviour
{
    public Collider2D StepCollider;
    public int StepNumber = 0;

    private BoxCollider2D TrackballCollider;
    private bool wasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        TrackballCollider = GameObject.Find("Trackball").GetComponent<BoxCollider2D>();
        wasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(StepNumber != Globals.Instance.CurrentMap.CurrentIndex)
        {
            return;
        }   

        if ((Globals.Instance.TrackballDirection == Direction.Left && StepCollider.bounds.min.x > TrackballCollider.bounds.max.x) ||
            (Globals.Instance.TrackballDirection == Direction.Right && StepCollider.bounds.max.x < TrackballCollider.bounds.min.x))
        {
            HandleExitCollision();
        }

        if (Input.GetKeyDown(Globals.Instance.Action1Key) || Input.GetKeyDown(Globals.Instance.Action2Key))
        {
            if (StepCollider.bounds.Intersects(TrackballCollider.bounds))
            {
                OnStepHit();
            }
            else
            {
                EndTrack(false);
            }           
        }
    }

    public void HandleExitCollision()
    {
        if (wasHit)
        {
            if(TryGetComponent<Renderer>(out var renderer))
            {
                renderer.enabled = false;
            }
            Globals.Instance.ChangeTrackballDirection();
            Globals.Instance.CurrentMap.NextStep();
        }
        else
        {
            EndTrack(false);
        }
    }

    public void OnStepHit()
    {
        wasHit = true;

        if(GameObject.Find("Main Camera").TryGetComponent<CameraShake>(out var cameraShake))
        {
            StartCoroutine(cameraShake.Shake(0.15f));
        }
        AudioManager.Instance.Play("stepHit");
        Globals.Instance.PerformanceTracker.AddHitAccuracy(TrackballCollider.bounds, StepCollider.bounds);

        if(GameObject.Find("UIDocument").TryGetComponent<GameUI>(out var gameUIScript)) 
        {
            gameUIScript.CreateComboLabel(Globals.Instance.PerformanceTracker.GetLastHitInfoLabel());
            gameUIScript.UpdateAccuracy(Globals.Instance.PerformanceTracker.Accuracy);
            gameUIScript.UpdateScore(Globals.Instance.PerformanceTracker.Score.ToString());
        }

        if (StepNumber == Globals.Instance.CurrentMap.Steps.Count - 1)
        {
            EndTrack(true);
        }
    }

    void EndTrack(bool trackCompleted = false)
    {
        if (!trackCompleted)
        {
            AudioManager.Instance.Play("gameOver");
        }

        Globals.Instance.TrackCompleted = trackCompleted;
        AudioManager.Instance.Stop(Globals.Instance.CurrentMap.SongFile);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
