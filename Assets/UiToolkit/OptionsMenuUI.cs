using RHTMGame.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class OptionsMenuUI : MonoBehaviour
{
    private bool isChangingAction1;
    private bool isChangingAction2;
    private Label labelAction1;
    private Label labelAction2;
    private List<string> allowedKeys = new() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "alpha1", "alpha2", "alpha3", "alpha4", "alpha5", "alpha6", "alpha7", "alpha8", "alpha9", "alpha0"};

    private void OnEnable()
    {
        isChangingAction1 = false;
        isChangingAction2 = false;
        var root = GetComponent<UIDocument>().rootVisualElement;

        var buttonBack = root.Q<Button>("ButtonBack");
        buttonBack.clicked += () => GoBack();

        var buttonAction1 = root.Q<Button>("ButtonAction1");
        buttonAction1.clicked += () => ChangeAction1();

        var buttonAction2 = root.Q<Button>("ButtonAction2");
        buttonAction2.clicked += () => ChangeAction2();

        var sliderGeneralVolume = root.Q<Slider>("GeneralVolume");
        var sliderMusicVolume = root.Q<Slider>("MusicVolume");
        var sliderEffectsVolume = root.Q<Slider>("EffectsVolume");

        sliderGeneralVolume.value = Globals.Instance.GameVolume;
        sliderMusicVolume.value = Globals.Instance.RawMusicVolume;
        sliderEffectsVolume.value = Globals.Instance.RawEffectsVolume;

        sliderGeneralVolume.RegisterValueChangedCallback(v =>
        {
            Globals.Instance.GameVolume = v.newValue;
        });
        sliderMusicVolume.RegisterValueChangedCallback(v =>
        {
            Globals.Instance.RawMusicVolume = v.newValue;
        });
        sliderEffectsVolume.RegisterValueChangedCallback(v =>
        {
            Globals.Instance.RawEffectsVolume = v.newValue;
        });

        labelAction1 = root.Q<Label>("LabelAction1Key");
        labelAction1.text = Globals.Instance.Action1Key.ToString();
        labelAction2 = root.Q<Label>("LabelAction2Key");
        labelAction2.text = Globals.Instance.Action2Key.ToString();
    }

    private void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ChangeAction1()
    {
        if (isChangingAction2)
        {
            return;
        }

        isChangingAction1 = true;
        labelAction1.text = "...Press a key";
    }
    private void ChangeAction2()
    {
        if (isChangingAction1)
        {
            return;
        }

        isChangingAction2 = true;
        labelAction2.text = "...Press a key";
    }

    void OnGUI()
    {
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            if(allowedKeys.Contains(Event.current.keyCode.ToString().ToLower()))
            {
                if (isChangingAction1)
                {
                    Globals.Instance.Action1Key = Event.current.keyCode;
                    labelAction1.text = Globals.Instance.Action1Key.ToString();
                    isChangingAction1 = false;
                }

                if (isChangingAction2)
                {
                    Globals.Instance.Action2Key = Event.current.keyCode;
                    labelAction2.text = Globals.Instance.Action2Key.ToString();
                    isChangingAction2 = false;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
    }
}
