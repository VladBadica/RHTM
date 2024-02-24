using RHTMGame.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OptionsMenuUI : MonoBehaviour
{
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var buttonBack = root.Q<Button>("ButtonBack");
        buttonBack.clicked += () => GoBack();

        var sliderGeneralVolume = root.Q<Slider>("GeneralVolume");
        var sliderMusicVolume = root.Q<Slider>("MusicVolume");
        var sliderEffectsVolume = root.Q<Slider>("EffectsVolume");

        Debug.Log(Globals.Instance.GameVolume);
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
    }

    private void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
    }
}
