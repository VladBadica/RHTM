using RHTMGame.Utils;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public UIDocument pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.enabled = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioManager.Instance.Resume(Globals.Instance.CurrentMap.SongFile);
    }

    void Pause()
    {
        pauseMenuUI.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioManager.Instance.Pause(Globals.Instance.CurrentMap.SongFile);
    }
}
