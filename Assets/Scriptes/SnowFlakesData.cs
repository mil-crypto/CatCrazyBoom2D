using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SnowFlakesData : MonoBehaviour
{
    [SerializeField] private GameObject _prefabSnow1, _prefabSnow2, _prefabSnow3, _prefabSnow4, _prefabSnow5, _prefabSnow6, _prefabSnow7, _prefabSnow8, _prefabSnow9, _prefabSnow10;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _cost1snow, _cost2snow, _cost3snow, _cost4snow, _cost5snow, _cost6snow, _cost7snow, _cost8snow, _cost9snow, _cost10snow; 
    [HideInInspector] public List <CollisionSnowFlake> _snowsList = new ();
    [HideInInspector] public static int Score;
    [HideInInspector] public static int CurrentRecord;
    [HideInInspector] public static int MaxRecord;
    [SerializeField] private LeaderboardYG _leaderboardYG;

    private void Start()
    {
        Score = 0;
        CurrentRecord = 0;
        MaxRecord = PlayerPrefs.GetInt("MaxRecord");
    }
    public GameObject ReturnNextPref(string currentTag)
    {
        GameObject _nextPref=null;
        switch (currentTag)
        {
            case "snow1":
                _nextPref = _prefabSnow2;
                break;
            case "snow2":
                _nextPref = _prefabSnow3;
                break;
            case "snow3":
                _nextPref = _prefabSnow4;
                break;
            case "snow4":
                _nextPref = _prefabSnow5;
                break;
            case "snow5":
                _nextPref = _prefabSnow6;
                break;
            case "snow6":
                _nextPref = _prefabSnow7;
                break;
            case "snow7":
                _nextPref = _prefabSnow8;
                break;
            case "snow8":
                _nextPref = _prefabSnow9;
                break;
            case "snow9":
                _nextPref = _prefabSnow10;
                break;
            case "snow10":
                Debug.Log("YEEEEEE ITS 10 SNOWFLAKE");
                break;
        }
        return _nextPref;
    }
    
    public GameObject [] ReturnAllPrefs()
    {
        GameObject[] prefsArray = new []{_prefabSnow1,_prefabSnow2,_prefabSnow3,_prefabSnow4,_prefabSnow5,_prefabSnow6,_prefabSnow7,_prefabSnow8,_prefabSnow9,_prefabSnow10 };
        return prefsArray;
    }

    public int GetScoreCost(string selftag)
    {
        int costOfSnow = 0;
        switch (selftag)
        {
            case "snow1":
                costOfSnow = _cost1snow;
                break;
            case "snow2":
                costOfSnow = _cost2snow;
                break;
            case "snow3":
                costOfSnow = _cost3snow;
                break;
            case "snow4":
                costOfSnow = _cost4snow;
                break;
            case "snow5":
                costOfSnow = _cost5snow;
                break;
            case "snow6":
                costOfSnow = _cost6snow;
                break;
            case "snow7":
                costOfSnow = _cost7snow;
                break;
            case "snow8":
                costOfSnow = _cost8snow;
                break;
            case "snow9":
                costOfSnow = _cost9snow;
                break;
            case "snow10":
                costOfSnow = _cost10snow;
                break;
        }
        return costOfSnow;
    }

    private void OnEnable()
    {
        UIController.RestartAction += Restart;
        EventsController.AddScoreEvent += AddScore;
        FloorEndGame.EndGameAction += CheckRecord;
        FloorEndGame.EndGameAction += UpdateLeaderBoard;
    }
    private void OnDisable()
    {
        UIController.RestartAction -= Restart;
        EventsController.AddScoreEvent -= AddScore;
        FloorEndGame.EndGameAction -= CheckRecord;
        FloorEndGame.EndGameAction -= UpdateLeaderBoard;
    }
    private void AddScore(int score)
    {
        Score += score;
        _scoreText.text = Score.ToString();
        CheckRecord();

    }
    private void CheckRecord()
    {
        if (CurrentRecord < Score)
        {
            CurrentRecord = Score;
            PlayerPrefs.SetInt("CurrentRecord", CurrentRecord);
        }
        if (MaxRecord < CurrentRecord)
        {
            MaxRecord = CurrentRecord;
            PlayerPrefs.SetInt("MaxRecord", MaxRecord);
        }    
    }
    private void UpdateLeaderBoard()
    {
        _leaderboardYG.NewScore(MaxRecord);
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
