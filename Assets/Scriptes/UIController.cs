using UnityEngine;
using UnityEngine.UI;
using YG;
using DG.Tweening;
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _finger;
    [SerializeField] private GameObject _restartBurrom;
    [SerializeField] private Button _soundsButton;
    [SerializeField] private Sprite  _soundsON, _soundsOF;
    private bool _soundBool;
    private Vector3 _startRestartButtomPos;
    private void Start()
    {
        PauseOf();
        _startRestartButtomPos = _restartBurrom.transform.position;
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
        EventsController.LooseGameAction += Loose;
    }
    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= PauseOn;
        YandexGame.OpenVideoEvent -= PauseOn;
        EventsController.LooseGameAction -= Loose;
    }
 
    public void RestartButton()
    {
        YandexGame.FullscreenShow();
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
    private void Loose()
    {
        _restartBurrom.transform.DOMove(new Vector3(840,376,0), 2f);
    }
}
