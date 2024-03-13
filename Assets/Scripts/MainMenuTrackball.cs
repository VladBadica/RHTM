using UnityEngine;
using UnityEngine.SceneManagement;
using RHTMGame;
using RHTMGame.Utils;
using System.Collections.Generic;
using System.IO;

public class MainMenuTrackball : MonoBehaviour
{
    public Collider2D optionsCollider;
    public Collider2D playCollider;
    public Collider2D exitCollider;
    private Collider2D trackballCollider;

    public float speed;

    private Direction direction;


    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Left;
        trackballCollider = GetComponent<Collider2D>();

        AudioManager.Instance.Play("mainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == Direction.Left && trackballCollider.bounds.center.x < optionsCollider.bounds.center.x)
        {
            direction = Direction.Right;
        }
        if (direction == Direction.Right && trackballCollider.bounds.center.x > exitCollider.bounds.center.x)
        {
            direction = Direction.Left;
        }

        if (Input.GetKeyDown(Globals.Instance.Action1Key) || Input.GetKeyDown(Globals.Instance.Action2Key) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (playCollider.bounds.Intersects(trackballCollider.bounds))
            {
                SceneManager.LoadScene("Game");
                Globals.Instance.CurrentMap = Globals.Instance.AllMaps[0];
                AudioManager.Instance.Stop("mainMenu");
            }

            if (optionsCollider.bounds.Intersects(trackballCollider.bounds))
            {
                SceneManager.LoadScene("Options");
            }

            if (exitCollider.bounds.Intersects(trackballCollider.bounds))
            {
                Globals.Instance.QuitGame();
            }

        }
    }

    // FixedUpdate is called fixed number of times per second
    // Update movement here
    void FixedUpdate()
    {
        if (direction == Direction.Left)
        {
            this.transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }

        if (direction == Direction.Right)
        {
            this.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
    }
}
