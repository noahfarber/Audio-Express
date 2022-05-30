using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;// Required when using Event data.

public class VolumeDisplay : MonoBehaviour, IDragHandler
{
    [SerializeField] private AudioSource BackgroundMusic;
    public Gradient SliderColor;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Image FillImage;
    [SerializeField] private Image KnobImage;
    [SerializeField] private TextMeshProUGUI Text;
    private bool _Overriding = false;

    // Start is called before the first frame update
    void Start()
    {
        VolumeSlider.onValueChanged.AddListener(VolumeChanged);
    }

    private void Update()
    {
        if(!Mathf.Approximately(BackgroundMusic.volume, VolumeSlider.value))
        {
            VolumeSlider.value = BackgroundMusic.volume;
        }
    }
    private void VolumeChanged(float volume)
    {
        Text.text = ($"{volume:F2}");
        FillImage.color = SliderColor.Evaluate(volume);
        KnobImage.color = SliderColor.Evaluate(volume);
        Text.color = SliderColor.Evaluate(volume);
    }


    public void OnDrag(PointerEventData eventData)
    {
        SoundController.Instance.StopFade(BackgroundMusic, false);
        BackgroundMusic.volume = VolumeSlider.value;
    }

}
