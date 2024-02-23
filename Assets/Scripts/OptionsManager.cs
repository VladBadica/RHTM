using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using RHTMGame.Utils;

public class OptionsManager : MonoBehaviour
{
    public Slider sliderGeneral;
    public Slider sliderMusic;
    public Slider sliderSoundEffects;

    void Awake()
    {
        sliderGeneral.value = Globals.Instance.GameVolume;
        sliderMusic.value = Globals.Instance.RawMusicVolume;
        sliderSoundEffects.value = Globals.Instance.RawSoundEffectsVolume;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeGeneralVolume()
    {
        Globals.Instance.GameVolume = sliderGeneral.value;
    }

    public void ChangeMusicVolume()
    {
        Globals.Instance.RawMusicVolume = sliderMusic.value;
    }

    public void ChangeSoundEffectsVolume()
    {
        Globals.Instance.RawSoundEffectsVolume = sliderSoundEffects.value;
    }
}

