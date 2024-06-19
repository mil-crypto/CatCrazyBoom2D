using System;
using UnityEngine;
using YG;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip _huhMeow, _garyMeow, _chpokAudio ,_kittenMeow1,_doorbelMeow,_aAAA,_bAAA,_lol,_happyHappy,_blblblbl,_exploseAudio;
    [SerializeField] private AudioSource _soundAudioSource,_garryMeowAudioSource, _huhMeowAudioSource, _exploseAudioSource;
    [HideInInspector] public bool Pause;

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += PauseOn;
        YandexGame.OpenVideoEvent += PauseOn;

        YandexGame.CloseFullAdEvent += PauseOf;
        YandexGame.CloseVideoEvent += PauseOf;

        CollisionSnowFlake.Collission2ArgumentAction += PlayMeow;

        EventsController.CreatePrefEvent += ChpokSound;
        EventsController.ExploseEvent += ExploseSound;

    }

    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= PauseOn;
        YandexGame.OpenVideoEvent -= PauseOn;

        YandexGame.CloseFullAdEvent += PauseOf;
        YandexGame.CloseVideoEvent += PauseOf;

        CollisionSnowFlake.Collission2ArgumentAction-= PlayMeow;

        EventsController.CreatePrefEvent -= ChpokSound;
        EventsController.ExploseEvent -= ExploseSound;

        
    }
    private void PauseOn()
    {
        Pause = true;
        _garryMeowAudioSource.Stop();
        _huhMeowAudioSource.Stop();
        _soundAudioSource.Stop();
    }

    private void PauseOf()
    {
        Pause = false;
    }

    private void PlayMeow(GameObject self, Collision2D another)
    {
        if (another.gameObject.CompareTag(self.tag) && !Pause)
        {
            int selfId = self.GetHashCode();
            int colId = another.gameObject.GetHashCode();
            int minId;
            if (selfId < colId)
            {
                minId = selfId;
            }
            else
            {
                minId = colId;
            }

            if (minId == selfId )
            {
                switch (self.tag)
                {
                    case "snow1":
                        _garryMeowAudioSource.PlayOneShot(_kittenMeow1);
                        break;
                    case "snow2":
                        _garryMeowAudioSource.PlayOneShot(_garyMeow);
                        break;
                    case "snow3":
                        _huhMeowAudioSource.PlayOneShot(_huhMeow);
                        break;
                    case "snow4":
                        _garryMeowAudioSource.PlayOneShot(_blblblbl);
                        break;
                    case "snow5":
                        _garryMeowAudioSource.PlayOneShot(_doorbelMeow);
                        break;
                    case "snow6":
                        _huhMeowAudioSource.PlayOneShot(_lol);
                        break;
                    case "snow7":
                        _huhMeowAudioSource.PlayOneShot(_aAAA);
                        break;
                    case "snow8":
                        _huhMeowAudioSource.PlayOneShot(_bAAA);
                        break;
                    case "snow9":
                        _huhMeowAudioSource.PlayOneShot(_happyHappy);
                        break;
                }
            }
        } 
    }
    private void ChpokSound()
    {
        if (!Pause)
        {
            _soundAudioSource.PlayOneShot(_chpokAudio);
        }
    }

    private void ExploseSound()
    {
        if (!Pause)
        {
            _exploseAudioSource.PlayOneShot(_exploseAudio);
        }
    }
}
