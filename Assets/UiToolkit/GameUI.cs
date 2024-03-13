using UnityEngine;
using UnityEngine.UIElements;
using System.Timers;

public class GameUI : MonoBehaviour
{
    VisualElement root;
    Label labelScore;
    Label labelAccuracy;
    Label labelCombo;
    public VisualTreeAsset labelComboTemplate;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        labelScore = root.Q<Label>("LabelScore");
        labelAccuracy = root.Q<Label>("LabelAccuracy");
        labelCombo = root.Q<Label>("LabelCombo");
    }

    public void UpdateLabelCombo(string text)
    {
        labelCombo.text = text;

        var timer = new Timer(1000);
        timer.Elapsed += (s, e) => {
            Debug.Log("HIODE");
            labelCombo.style.display = DisplayStyle.None;
        };
        timer.AutoReset = false;

        labelCombo.style.display = DisplayStyle.Flex;
        timer.Start();
    }

    public void UpdateScore(string text)
    {
        labelScore.text = text;
    }

    public void UpdateAccuracy(string text)
    {
        labelAccuracy.text = text;
    }
}
