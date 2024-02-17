using UnityEngine;
using UnityEngine.SceneManagement;
using RHTMGame.Utils;

public class MainMenuTrackball : MonoBehaviour
{
    public Collider2D editorCollider;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == Direction.Left && this.trackballCollider.bounds.center.x < editorCollider.bounds.center.x)
        {
            direction = Direction.Right;
        }
        if (direction == Direction.Right && this.trackballCollider.bounds.center.x > exitCollider.bounds.center.x)
        {
            direction = Direction.Left;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playCollider.bounds.Intersects(trackballCollider.bounds))
            {
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            }

            if (editorCollider.bounds.Intersects(trackballCollider.bounds))
            {
                Debug.Log("Click Editor");
            }

            if (exitCollider.bounds.Intersects(trackballCollider.bounds))
            {
                Quit();
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

    void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
