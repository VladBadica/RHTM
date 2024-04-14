using Dan.Main;
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
        labelHeader.text = Globals.Instance.TrackCompleted ? "Track Completed" : "Track Failed";

        var labelMapName = root.Q<Label>("LabelMapName");
        labelMapName.text = Globals.Instance.CurrentMap.MapName;

        var labelScore = root.Q<Label>("LabelScore");
        labelScore.text = $"Score: {Globals.Instance.PerformanceTracker.Score}";

        var labelAccuracy = root.Q<Label>("LabelAccuracy");
        labelAccuracy.text = $"Accuracy: {Globals.Instance.PerformanceTracker.Accuracy}%";

        var buttonSubmit = root.Q<Button>("ButtonSubmit");
        buttonSubmit.clicked += () => SubmitScore();
    }

    void SubmitScore()
    {
        var inputName = root.Q<TextField>("TextPlayerName");

        LeaderboardCreator.UploadNewEntry(Globals.Instance.PublicLeaderboardKey, inputName.value, Globals.Instance.PerformanceTracker.Score);
    }

    void GoBack()
    {
        SceneManager.LoadScene("MapSelection");
    }

    void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}