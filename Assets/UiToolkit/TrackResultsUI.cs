using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TrackResultsUI : MonoBehaviour
{
    VisualElement root;
    UIDocument trackResultsUI;
    private void OnEnable()
    {
        trackResultsUI = GetComponent<UIDocument>();
        root = trackResultsUI.rootVisualElement;

        var buttonback = root.Q<Button>("ButtonBack");
        buttonback.clicked += () => GoBack();

        var buttonRetry = root.Q<Button>("ButtonRetry");
        buttonRetry.clicked += () => Retry();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowTrackResults()
    {
        trackResultsUI.enabled = true;
        var labelHeader = root.Q<Label>("LabelHeader");
        labelHeader.text = $"Track Finished";
    }

    void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}
