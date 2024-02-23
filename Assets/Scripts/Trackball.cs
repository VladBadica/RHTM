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

    // Update is called once per frame
    // Add logic here
    void Update()
    {

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
