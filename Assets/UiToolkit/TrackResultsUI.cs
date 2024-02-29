using RHTMGame.Utils;
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


        var labelHeader = root.Q<Label>("LabelHeader");
        labelHeader.text = $"Track Finished";

        var labelScore = root.Q<Label>("LabelScore");
        labelScore.text = $"Score: {Globals.Instance.PerformanceTracker.Score}";

        var labelAccuracy = root.Q<Label>("LabelAccuracy");
        labelAccuracy.text = $"Accuracy: {Globals.Instance.PerformanceTracker.Accuracy}%";

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
