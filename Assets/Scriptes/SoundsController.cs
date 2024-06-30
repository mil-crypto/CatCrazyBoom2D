using UnityEngine;
using YG;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip _wallAudio , _catTriggerSound;
    [SerializeField] private AudioSource _soundAudioSource;
    [HideInInspector] public bool Pause;

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += PauseOn;
        YandexGame.OpenVideoEvent += PauseOn;

        YandexGame.CloseFullAdEvent += PauseOf;
        YandexGame.CloseVideoEvent += PauseOf;

        EventsController.OnTriggerCatEvent += CatMeowSound;
        EventsController.OnTriggerWallEvent += WallChpokSound;

    }

    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= PauseOn;
        YandexGame.OpenVideoEvent -= PauseOn;

        YandexGame.CloseFullAdEvent += PauseOf;
        YandexGame.CloseVideoEvent += PauseOf;

        EventsController.OnTriggerCatEvent -= CatMeowSound;
        EventsController.OnTriggerWallEvent -= WallChpokSound;
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
        if (!Pause)
        {
            _soundAudioSource.PlayOneShot(_catTriggerSound);
        }
    }
    
    private void WallChpokSound(GameObject obj)
    {
        if (!Pause)
        {
            _soundAudioSource.PlayOneShot(_wallAudio);
        }
    }

   
}
