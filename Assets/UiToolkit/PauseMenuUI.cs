using RHTMGame.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuUI : MonoBehaviour
{
    VisualElement root;
    public static bool GameIsPaused = false;
    public UIDocument pauseMenuUI;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        
        var buttonBack = root.Q<Button>("ButtonResume");
        buttonBack.clicked += () => Resume();

        var buttonRetry = root.Q<Button>("ButtonRetry");
        buttonRetry.clicked += () => Retry();

        var buttonMenu = root.Q<Button>("ButtonMainMenu");
        buttonMenu.clicked += () => GoToMainMenu();

    }

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
    void Pause()
    {
        pauseMenuUI.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioManager.Instance.Pause(Globals.Instance.CurrentMap.SongFile);

        foreach (var script in FindObjectsByType<StepCollision>(FindObjectsSortMode.None))
        {
            script.enabled = false;
        }
    }

    void Resume()
    {
        pauseMenuUI.enabled = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioManager.Instance.Resume(Globals.Instance.CurrentMap.SongFile);

        foreach (var script in FindObjectsByType<StepCollision>(FindObjectsSortMode.None))
        {
            script.enabled = true;
        }
    }

    void Retry()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.enabled = false;

        AudioManager.Instance.Stop(Globals.Instance.CurrentMap.SongFile);
        foreach (var script in FindObjectsByType<StepCollision>(FindObjectsSortMode.None))
        {
            script.enabled = true;
        }

        SceneManager.LoadScene("Game");
        // BUGGED
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.enabled = false;
        AudioManager.Instance.Stop(Globals.Instance.CurrentMap.SongFile);

        SceneManager.LoadScene("MainMenu");
    }
}
