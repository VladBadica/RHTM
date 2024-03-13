using UnityEngine;
using UnityEngine.UIElements;
using System.Timers;

public class GameUI : MonoBehaviour
{
    VisualElement root;
    Label labelScore;
    Label labelAccuracy;
    public VisualTreeAsset labelComboTemplate;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        labelScore = root.Q<Label>("LabelScore");
        labelAccuracy = root.Q<Label>("LabelAccuracy");
    }

    public void CreateComboLabel(string text)
    {
        var container = labelComboTemplate.Instantiate();
        container.Q<Label>().text = text;

        var timer = new Timer(3000);
        timer.Elapsed += (s, e) => { 
            root.Q("ContainerCombo").Remove(container); 
        };
        timer.AutoReset = false;

        /*foreach(var child in root.Q("ContainerCombo").Children())
        {
           Handle opacity update for existing labels so they fade away in the screen 
        }*/
        root.Q("ContainerCombo").Add(container);
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
