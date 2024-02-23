using UnityEngine;
using RHTMGame.Utils;
using TMPro;

public class StepCollision : MonoBehaviour
{
    public AudioClip GameOverClip;
    public AudioClip StepHitClip;
    public GameObject ComboLabel;
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

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            if (StepCollider.bounds.Intersects(TrackballCollider.bounds))
            {
                OnStepHit();
            }
            else
            {
                Globals.Instance.QuitGame();
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
            AudioSource.PlayClipAtPoint(GameOverClip, Vector3.zero, 1f);
            Globals.Instance.QuitGame();
        }
    }

    public void OnStepHit()
    {
        wasHit = true;

        AudioSource.PlayClipAtPoint(StepHitClip, Vector3.zero, Globals.Instance.SoundEffectsVolume);

        Globals.Instance.PerformanceTracker.AddHitAccuracy(TrackballCollider.bounds, StepCollider.bounds);

        if (GameObject.Find("ScoreLabel").TryGetComponent<TextMeshProUGUI>(out var scoreLabel))
        {
            scoreLabel.text = $"Score: {Globals.Instance.PerformanceTracker.Score}";
        }
        if (GameObject.Find("AccuracyLabel").TryGetComponent<TextMeshProUGUI>(out var accuracyLabel))
        {
            accuracyLabel.text = $"Accuracy: {Globals.Instance.PerformanceTracker.Accuracy}%";
        }

        var canvas = GameObject.Find("UICanvas");
        var comboLabelObj = Instantiate(ComboLabel, canvas.transform.position, Quaternion.identity, canvas.transform);
        
        if(comboLabelObj.TryGetComponent<TextMeshProUGUI>(out var comboLabelText))
        {
            comboLabelText.text = Globals.Instance.PerformanceTracker.GetLastHitInfoLabel();
        }
    }
}
