using UnityEngine;
using RHTMGame.Utils;

public class Trackball : MonoBehaviour
{
    public float horizontalForce;


    // Start is called before the first frame update
    void Start()
    {
        Globals.Instance.TrackballDirection = Direction.Left;
    }
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("ENTER");
    }

    // Update is called once per frame
    // Add logic here
    void Update()
    {
        if (this.transform.position.x < -10)
        {
            Globals.Instance.ChangeTrackballDirection();
        }
        if (this.transform.position.x > 10)
        {
            Globals.Instance.TrackballDirection = Direction.Left;
        }
    }

    // FixedUpdate is called fixed number of times per second
    // Update movement here
    void FixedUpdate()
    {
        if (Globals.Instance.TrackballDirection == Direction.Left)
        {
            this.transform.position -= new Vector3(horizontalForce * Time.fixedDeltaTime, 0, 0);
        }

        if (Globals.Instance.TrackballDirection == Direction.Right)
        {
            this.transform.position += new Vector3(horizontalForce * Time.fixedDeltaTime, 0, 0);
        }
    }

}
