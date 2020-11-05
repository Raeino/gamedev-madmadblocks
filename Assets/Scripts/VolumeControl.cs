using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {
    public AudioMixer mixer;
    public Slider slider;

    void Start() {
        slider.value = PlayerPrefs.GetFloat("volume", 0.75f);
    }

    public void SetLevel() {
        float sliderValue = slider.value;
        mixer.SetFloat("volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("volume", sliderValue);
    }
}