using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    float elapsedVisible = 0;
    VisualElement root;
    Label labelScore;
    Label labelAccuracy;
    Label labelCombo;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        labelScore = root.Q<Label>("LabelScore");
        labelAccuracy = root.Q<Label>("LabelAccuracy");
        labelCombo = root.Q<Label>("LabelCombo");
    }

    void Update()
    {
        if (elapsedVisible > 0)
        {
            elapsedVisible -= Time.deltaTime;
        }

        if(elapsedVisible <= 0)
        {
            labelCombo.style.display = DisplayStyle.None;
        }
    }

    public void UpdateLabelCombo(string text)
    {
        labelCombo.text = text;
        labelCombo.style.display = DisplayStyle.Flex;

        elapsedVisible = 1.5f;
    }

    public void UpdateScore(string text)
    {
        labelScore.text = text;
    }

    public void UpdateAccuracy(string text)
    {
        labelAccuracy.text = text + "%";
    }
}
