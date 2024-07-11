using UnityEngine;
using UnityEngine.UI;
using YG;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _finger;
    [SerializeField] private Button _soundsButton;
    [SerializeField] private Sprite  _soundsON, _soundsOF;
    private bool _soundBool;
    private void Start()
    {
        PauseOn();
        if (_soundBool)
        {
            _soundsButton.GetComponent<Image>().sprite = _soundsOF;
            _soundBool =  true;
            EventsController.InvokeSoundsButtonPressedEvent(true);

        }
        else if (!_soundBool)
        {
            _soundsButton.GetComponent<Image>().sprite = _soundsON;
            _soundBool = false;
            EventsController.InvokeSoundsButtonPressedEvent(false);
        }
    }

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += PauseOn;
        YandexGame.OpenVideoEvent += PauseOn;
        
    }
    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= PauseOn;
        YandexGame.OpenVideoEvent -= PauseOn;
    }
 
    public void RestartButton()
    {
        YandexGame.FullscreenShow();
        PauseOn();
        EventsController.InvokeRestartEvent();
    }
    public void PauseOn()
    {
        Time.timeScale = 0;
    }
    public void PauseOf()
    {
        Time.timeScale = 1;
        _finger.SetActive(false);
    }
    public void SoundsButton()
    {
        if (_soundBool)
        {
            _soundsButton.GetComponent<Image>().sprite = _soundsON;
            _soundBool = false;
            EventsController.InvokeSoundsButtonPressedEvent(false);

        }
        else if (!_soundBool)
        {
            _soundsButton.GetComponent<Image>().sprite = _soundsOF;
            _soundBool = true;
            EventsController.InvokeSoundsButtonPressedEvent(true);
        }
    }
}
