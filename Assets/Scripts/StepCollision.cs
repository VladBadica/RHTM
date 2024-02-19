using UnityEngine;
using RHTMGame.Utils;

public class StepCollision : MonoBehaviour
{
    private BoxCollider2D TrackballCollider;
    public Collider2D StepCollider;
    public int StepNumber = 0;

    private bool hasCollided = false;
    private bool wasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        TrackballCollider = GameObject.Find("Trackball").GetComponent<BoxCollider2D>();
        hasCollided = false;
        wasHit = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Globals.Instance.TrackballDirection == Direction.Left && StepCollider.bounds.min.x > TrackballCollider.bounds.max.x)
        {
            HandleExitCollision();
        }
        else if (Globals.Instance.TrackballDirection == Direction.Right && StepCollider.bounds.max.x < TrackballCollider.bounds.min.x)
        {
            HandleExitCollision();
        }

        if (StepCollider.bounds.Intersects(TrackballCollider.bounds))
        {
            Debug.Log("hasCollided");
            hasCollided = true;            
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(hasCollided);
            if (hasCollided)
            {
                Debug.Log("HIT");
                wasHit = true;
            }
            else
            {
                Globals.Instance.QuitGame();
            }
           
        }
    }

    public void HandleExitCollision()
    {
        if (!hasCollided)
        {
            return;
        }

        if (wasHit)
        {
            this.enabled = false;
            Globals.Instance.ChangeTrackballDirection();
        }
        else
        { 
            Globals.Instance.QuitGame();
        }
    }
}
