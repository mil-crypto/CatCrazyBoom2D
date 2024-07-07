using UnityEngine;
using YG;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _finger;
    [SerializeField] private GameObject _endGamePanel;

    private void Start()
    {

        SnowFlakesData.MaxRecord = PlayerPrefs.GetInt("MaxRecord");
        _endGamePanel.SetActive(false);
        PauseOn();

    }

    private void OnEnable()
    {
        EventsController.EndlevelEvent += EndGamePanelActivate;
        YandexGame.OpenFullAdEvent += PauseOn;
        YandexGame.OpenVideoEvent += PauseOn;
        
    }
    private void OnDisable()
    {
        EventsController.EndlevelEvent -= EndGamePanelActivate;
        YandexGame.OpenFullAdEvent -= PauseOn;
        YandexGame.OpenVideoEvent -= PauseOn;
    }
    private void OnMouseDown()
    {
        PauseOf();
    }
    public void RestartButton()
    {
        YandexGame.FullscreenShow();
        PauseOn();
        EventsController.InvokeRestartEvent();
    }
    private void EndGamePanelActivate()
    {
        _endGamePanel.SetActive(true);
    }
    public void PauseOn()
    {
        Time.timeScale = 0;
        _finger.SetActive(true);
    }
    public void PauseOf()
    {
        Time.timeScale = 1;
        _finger.SetActive(false);
    }
}
