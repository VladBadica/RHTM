using RHTMGame.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuUI : MonoBehaviour
{
    VisualElement root;
    public static bool GameIsPaused = false;
    UIDocument pauseMenuUI;

    private void OnEnable()
    {
        pauseMenuUI = GetComponent<UIDocument>();
        root = pauseMenuUI.rootVisualElement;

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
        root.Q<VisualElement>("RootContainer").style.display = DisplayStyle.Flex;
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
        root.Q<VisualElement>("RootContainer").style.display = DisplayStyle.None;
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
        root.Q<VisualElement>("RootContainer").style.display = DisplayStyle.None;
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioManager.Instance.Stop(Globals.Instance.CurrentMap.SongFile);
        
        foreach (var script in FindObjectsByType<StepCollision>(FindObjectsSortMode.None))
        {
            script.enabled = true;
        }

        SceneManager.LoadScene("Game");
    }

    void GoToMainMenu()
    {
        root.Q<VisualElement>("RootContainer").style.display = DisplayStyle.None;
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioManager.Instance.Stop(Globals.Instance.CurrentMap.SongFile);
        
        SceneManager.LoadScene("MainMenu");
    }
}
