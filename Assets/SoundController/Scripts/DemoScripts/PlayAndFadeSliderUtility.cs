using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayAndFadeSliderUtility : MonoBehaviour
{
    [SerializeField] private Slider StartVolumeSlider;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Slider DurationSlider;
    [SerializeField] private TextMeshProUGUI StartVolumeText;
    [SerializeField] private TextMeshProUGUI VolumeText;
    [SerializeField] private TextMeshProUGUI DurationText;

    void Start()
    {
        VolumeSlider.onValueChanged.AddListener(VolumeSliderChanged);
        VolumeSliderChanged(VolumeSlider.value);

        DurationSlider.onValueChanged.AddListener(DurationSliderChanged);
        DurationSliderChanged(DurationSlider.value);

        StartVolumeSlider.onValueChanged.AddListener(StartVolumeSliderChanged);
        StartVolumeSliderChanged(StartVolumeSlider.value);
    }

    void StartVolumeSliderChanged(float volume)
    {
        StartVolumeText.text = ($"{volume:F2}");
    }

    void VolumeSliderChanged(float volume)
    {
        VolumeText.text = ($"{volume:F2}");
    }

    void DurationSliderChanged(float duration)
    {
        DurationText.text = duration.ToString();
    }
}
