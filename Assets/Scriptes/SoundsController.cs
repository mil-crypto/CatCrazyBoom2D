using System;
using UnityEngine;
using YG;
public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip _wallSound, _baloonTriggerSound, _fireworkSound ,_gameOverSound;
    [SerializeField] private AudioSource _soundAudioSource;
    [HideInInspector] public bool Pause;
    private bool _soundBool;

    private void Start()
    {
        if (PlayerPrefs.GetInt("SoundOn") == 1)
        {
            _soundBool = true;
        }
        else
        {
            _soundBool = false;
        }
    }

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += PauseOn;
        YandexGame.OpenVideoEvent += PauseOn;

        YandexGame.CloseFullAdEvent += PauseOf;
        YandexGame.CloseVideoEvent += PauseOf;

        EventsController.OnTriggerCatEvent += CatMeowSound;
        EventsController.OnTriggerWallEvent += WallChpokSound;

        EventsController.SoundsButtonPressedEvent += SoundBool;

        EventsController.WinlevelEvent += FireWorkSound;
        EventsController.LooseGameAction += GameOverSound;

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
        
        EventsController.WinlevelEvent -= FireWorkSound;
        EventsController.LooseGameAction -= GameOverSound;
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
            _soundAudioSource.PlayOneShot(_baloonTriggerSound);
        }
    }
    
    private void WallChpokSound(GameObject obj)
    {
        if (!Pause&&!_soundBool)
        {
            _soundAudioSource.PlayOneShot(_wallSound);
        }
    }
    private void FireWorkSound()
    {
        if (!Pause&&!_soundBool)
        {
            _soundAudioSource.PlayOneShot(_fireworkSound);
        }
    }

    private void GameOverSound()
    {
        if (!Pause&&!_soundBool)
        {
            _soundAudioSource.PlayOneShot(_gameOverSound);
        }
    }

    private void SoundBool(Boolean soundBool)
    {
        if (soundBool)
        {
            PlayerPrefs.SetInt("SoundOn",1);
            _soundBool = true;
        }
        else
        {
            PlayerPrefs.SetInt("SoundOn",0);
            _soundBool = false;
        }
    }
   
}
