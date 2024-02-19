using UnityEngine;
using UnityEngine.SceneManagement;
using RHTMGame;
using RHTMGame.Utils;
using System.Collections.Generic;
using System.IO;

public class MainMenuTrackball : MonoBehaviour
{
    private List<Map> maps;
    public Collider2D editorCollider;
    public Collider2D playCollider;
    public Collider2D exitCollider;
    private Collider2D trackballCollider;

    public float speed;

    private Direction direction;


    // Start is called before the first frame update
    void Start()
    {
        maps = GetAllMaps();
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
                Globals.Instance.CurrentMap = maps[0];
            }

            if (editorCollider.bounds.Intersects(trackballCollider.bounds))
            {
                Debug.Log("Click Editor");
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

    public List<Map> GetAllMaps()
    {
        List<Map> maps = new List<Map>();
        string[] mapFiles = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\maps");
        for (int i = 0; i < mapFiles.Length; i++)
        {
            Map map = JsonUtility.FromJson<Map>(File.ReadAllText(mapFiles[i]));
            maps.Add(map);

            mapFiles[i] = mapFiles[i].Split("\\")[^1].Split('.')[0];
        }

        return maps;
    }
}
