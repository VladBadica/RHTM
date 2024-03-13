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
    }

    public void ShowTrackResults()
    {
        var labelHeader = root.Q<Label>("LabelHeader");
        labelHeader.text = Globals.Instance.TrackCompleted ? "Track Completed - " : "Track Failed - " + Globals.Instance.CurrentMap.SongFile;

        var labelScore = root.Q<Label>("LabelScore");
        labelScore.text = $"Score: {Globals.Instance.PerformanceTracker.Score}";

        var labelAccuracy = root.Q<Label>("LabelAccuracy");
        labelAccuracy.text = $"Accuracy: {Globals.Instance.PerformanceTracker.Accuracy}%";

        var labelSongDuration = root.Q<Label>("LabelSongDuration");
        labelSongDuration.text = $"Duration: {AudioManager.Instance.SongDuration(Globals.Instance.CurrentMap.SongFile)}";
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