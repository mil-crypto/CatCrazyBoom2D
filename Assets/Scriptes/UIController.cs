using UnityEngine;
using UnityEngine.UI;
using YG;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _restartBurrom ,_restartBurrom2, _nextLvlButton ,_looseBaloon , _winBaloon;
    [SerializeField] private TextMeshProUGUI _lvlText;
    [SerializeField] private Button _soundsButton;
    [SerializeField] private Sprite  _soundsON, _soundsOF;
    private bool _soundBool;
    private void Start()
    {
        _winBaloon.SetActive((false));
        _looseBaloon.SetActive(false);
        _nextLvlButton.SetActive(false);
        _restartBurrom.SetActive(true);
        _restartBurrom2.SetActive(false);
        _lvlText.text = (SceneManager.GetActiveScene().buildIndex+1).ToString();
        if (PlayerPrefs.GetInt("SoundOn") == 1)
        {
            _soundBool = true;
        }
        else
        {
            _soundBool = false;
        }
        PauseOf();
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
        EventsController.WinlevelEvent += Win;
    }
    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= PauseOn;
        YandexGame.OpenVideoEvent -= PauseOn;
        EventsController.LooseGameAction -= Loose;
        EventsController.WinlevelEvent -= Win;
    }

    private void ActiveNextLvlButton()
    {
        _nextLvlButton.SetActive(true);
        _nextLvlButton.transform.DOScale(new Vector2(1.2f,1.2f),0.5f).SetLoops(-1,LoopType.Yoyo);
    }
    public void RestartButton()
    {
        YandexGame.FullscreenShow();
        EventsController.InvokeRestartEvent();
    }

    public void NextLvlButton()
    {
        EventsController.InvokeNextLvlEvent();
    }
    public void PauseOn()
    {
        Time.timeScale = 0;
    }
    public void PauseOf()
    {
        Time.timeScale = 1;
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

    private void Win()
    {
        ActiveNextLvlButton();
        _winBaloon.SetActive(true);
    }
    private void Loose()
    {
        _restartBurrom.SetActive(false);
        _restartBurrom2.SetActive(true);
        _restartBurrom2.transform.DOScale(new Vector2(1.2f,1.2f),0.5f).SetLoops(-1,LoopType.Yoyo);
        _looseBaloon.SetActive(true);
    }
}
