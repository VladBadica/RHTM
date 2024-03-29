using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CountdownUI : MonoBehaviour
{
    VisualElement root;
    UIDocument countDownUI;
    Label countDownLabel;
    private double countdownTimer = 0;

    private void OnEnable()
    {
        countDownUI = GetComponent<UIDocument>();
        root = countDownUI.rootVisualElement;

        countDownLabel = root.Q<Label>("LabelCountdown");
    }

    public void StartCountdown()
    {
        if (countdownTimer == 0)
        {
            root.Q<VisualElement>("RootContainer").style.display = DisplayStyle.Flex;
            countdownTimer = 1;
            countDownLabel.text = countdownTimer.ToString();
        }
    }

    private void Update()
    {
        if (countdownTimer > 0)
        {
            countdownTimer -= Time.deltaTime;

            if (countdownTimer <= 0)
            {
                root.Q<VisualElement>("RootContainer").style.display = DisplayStyle.None;
                if (GameObject.Find("Map").TryGetComponent<MapLoader>(out var mapLoader))
                {
                    mapLoader.StartTrack();
                }
            }
            countDownLabel.text = Math.Ceiling(countdownTimer).ToString();
        }
    }
}
