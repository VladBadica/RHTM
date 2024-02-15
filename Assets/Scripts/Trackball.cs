using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RHTMGame.Utils;

public class Trackball : MonoBehaviour
{
    public Transform playerTransform;
    public float horizontalForce;

    private DirectionEnum direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = DirectionEnum.LEFT;
    }

    // Update is called once per frame
    // Add logic here
    void Update()
    {
        if (playerTransform.position.x < -10)
        {
            direction = DirectionEnum.RIGHT;
        }
        if (playerTransform.position.x > 10)
        {
            direction = DirectionEnum.LEFT;
        }
    }

    // FixedUpdate is called fixed number of times per second
    // Update movement here
    void FixedUpdate()
    {
        if (direction == DirectionEnum.LEFT)
        {
            playerTransform.position -= new Vector3(horizontalForce * Time.fixedDeltaTime, 0, 0);
        }

        if (direction == DirectionEnum.RIGHT)
        {
            playerTransform.position += new Vector3(horizontalForce * Time.fixedDeltaTime, 0, 0);
        }
    }

}
