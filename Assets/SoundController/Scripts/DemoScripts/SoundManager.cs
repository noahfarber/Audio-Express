using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class SoundManager : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioClip[] BackgroundTracks;

    [Space(20)] public AudioClip[] SoundEffects;
    [SerializeField] private Slider PlayAndFadeDurationSlider;
    [SerializeField] private Slider PlayAndFadeStartVolumeSlider;
    [SerializeField] private Slider PlayAndFadeVolumeSlider;

    [Space(20), SerializeField] private TextMeshProUGUI NowPlayingText;

    private int BackgroundTrackIndex = 0;

    public void PlayBackgroundMusic()
    {
        SoundController.Instance.Play(BackgroundMusic);
        UpdateNowPlayingText();
    }

    public void PlayRandomSoundEffect()
    {
        SoundController.Instance.PlayOneShot(SoundEffects[Random.Range(0, SoundEffects.Length)]);
    }

    public void PlayAndFade()
    {
        SoundController.Instance.PlayAndFade(BackgroundMusic, PlayAndFadeVolumeSlider.value, PlayAndFadeDurationSlider.value, PlayAndFadeStartVolumeSlider.value);
        UpdateNowPlayingText();
    }

    public void Stop()
    {
        SoundController.Instance.Stop(BackgroundMusic);
    }

    public void StopFade()
    {
        SoundController.Instance.StopFade(BackgroundMusic, false);
    }

    public void SkipBackgroundTrack()
    {
        BackgroundTrackIndex++;
        if(BackgroundTrackIndex >= BackgroundTracks.Length)
        {
            BackgroundTrackIndex = 0;
        }

        BackgroundMusic.clip = BackgroundTracks[BackgroundTrackIndex];

        SoundController.Instance.Play(BackgroundMusic);
        UpdateNowPlayingText();
    }

    private void UpdateNowPlayingText()
    {
        NowPlayingText.text = "Now Playing:\n" + BackgroundMusic.clip.name;
    }
}
