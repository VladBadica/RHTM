using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RHTMGame.Utils;

public class MainMenuTrackball : MonoBehaviour
{
    public Collider2D editorCollider;
    public Collider2D playCollider;
    public Collider2D exitCollider;
    private Collider2D trackBallCollider;

    public float speed;

    private DirectionEnum direction;


    // Start is called before the first frame update
    void Start()
    {
        direction = DirectionEnum.LEFT;
        trackBallCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == DirectionEnum.LEFT && this.trackBallCollider.bounds.center.x < editorCollider.bounds.center.x)
        {
            direction = DirectionEnum.RIGHT;
        }
        if (direction == DirectionEnum.RIGHT && this.trackBallCollider.bounds.center.x > exitCollider.bounds.center.x)
        {
            direction = DirectionEnum.LEFT;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playCollider.bounds.Intersects(trackBallCollider.bounds))
            {
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            }

            if (editorCollider.bounds.Intersects(trackBallCollider.bounds))
            {
                Debug.Log("Click Editor");
            }

            if (exitCollider.bounds.Intersects(trackBallCollider.bounds))
            {
                Debug.Log("Exit");
            }
        }
    }

    // FixedUpdate is called fixed number of times per second
    // Update movement here
    void FixedUpdate()
    {
        if (direction == DirectionEnum.LEFT)
        {
            this.transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }

        if (direction == DirectionEnum.RIGHT)
        {
            this.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
    }
}
