using UnityEngine;
using RHTMGame.Utils;

public class Trackball : MonoBehaviour
{
    public float horizontalForce;

    void Start()
    {
        Globals.Instance.TrackballDirection = Direction.Left;
    }

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
