using System;
using UnityEngine;
using YG;
public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip _wallAudio , _catTriggerSound;
    [SerializeField] private AudioSource _soundAudioSource;
    [HideInInspector] public bool Pause;
    private bool _soundBool;

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += PauseOn;
        YandexGame.OpenVideoEvent += PauseOn;

        YandexGame.CloseFullAdEvent += PauseOf;
        YandexGame.CloseVideoEvent += PauseOf;

        EventsController.OnTriggerCatEvent += CatMeowSound;
        EventsController.OnTriggerWallEvent += WallChpokSound;

        EventsController.SoundsButtonPressedEvent += SoundBool;

    }

    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= PauseOn;
        YandexGame.OpenVideoEvent -= PauseOn;

        YandexGame.CloseFullAdEvent += PauseOf;
        YandexGame.CloseVideoEvent += PauseOf;

        EventsController.OnTriggerCatEvent -= CatMeowSound;
        EventsController.OnTriggerWallEvent -= WallChpokSound;
        EventsController.SoundsButtonPressedEvent -= SoundBool;
    }

    private void PauseOn()
    {
        Pause = true;
        _soundAudioSource.Stop();
    }

    private void PauseOf()
    {
        Pause = false;
    }
    private void CatMeowSound(GameObject obj)
    {
        if (!Pause&&!_soundBool)
        {
            _soundAudioSource.PlayOneShot(_catTriggerSound);
        }
    }
    
    private void WallChpokSound(GameObject obj)
    {
        if (!Pause&&!_soundBool)
        {
            _soundAudioSource.PlayOneShot(_wallAudio);
        }
    }

    private void SoundBool(Boolean soundBool)
    {
        _soundBool = soundBool;
    }
   
}
