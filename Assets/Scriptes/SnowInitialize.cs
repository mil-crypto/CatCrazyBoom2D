using System;
using System.Collections;
using UnityEngine;
using YG;

public class SnowInitialize : MonoBehaviour
{
    [SerializeField] private GameObject _prefabSnow1, _prefabSnow2, _prefabSnow3 ,_particlePrefab;
    [SerializeField] private GameObject _exploseCat;
    [SerializeField] private Transform _startPos;
    [SerializeField] private SnowFlakesData _snowFlakesData;
    [SerializeField] private float _xPosLeft,_xPosRight;
    [SerializeField] private UIController _uIController;
    [SerializeField] private SoundsController _soundsController;

    public event Action PrefInitAction;
    private ArrayPoolBase _catsPool;
    [HideInInspector] public int NextRandNumber;
    private GameObject _prefab;
    private Rigidbody2D _prefRigid;
    private float _timer = 0.8f;
    private bool _coolDown = true;
    private bool _endGame;


    private void Awake()
    {
        _catsPool = new ArrayPoolBase();
        _catsPool.ActivatePoolBase(_snowFlakesData.ReturnAllPrefs());
    }

    private void FixedUpdate()
    {
        if (_coolDown)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _coolDown = false;
            }
        }
    }
    private void OnEnable()
    {
        FloorEndGame.EndGameAction += EndGame;
        CollisionSnowFlake.Collission2ArgumentAction += MergeSnows;
        YandexGame.CloseVideoEvent += RewardeForVideo;
    }
    private void OnDisable()
    {
        FloorEndGame.EndGameAction -= EndGame;
        CollisionSnowFlake.Collission2ArgumentAction -= MergeSnows;
        YandexGame.CloseVideoEvent -= RewardeForVideo;
    }

    private void RewardeForVideo()
    {
        var exploseCat=Instantiate(_exploseCat);
        exploseCat.transform.position= new Vector2(_startPos.position.x, _startPos.position.y);
    }

    private void Start()
    {
        YandexGame.FullscreenShow();
        InstantiatePref();
        _prefab.transform.position = new Vector2(_startPos.position.x, _startPos.position.y);
        _prefab.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    private void OnMouseDown()
    {
        _uIController.PauseOf();
        _soundsController.Pause = false;
        Vector2 cursorPoint = new(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
        float mosPosx = cursorPosition.x;

        if (!_coolDown&&!_endGame&&mosPosx>_xPosLeft&&mosPosx<_xPosRight)
        {
            InstantiatePref();
            _prefab.transform.position = new Vector2(cursorPosition.x, _startPos.position.y);
        }
    }
    private void OnMouseDrag()
    {
        Vector2 cursorPoint = new(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
        if (!_coolDown&&!_endGame&&_prefab!=null&& cursorPosition.x>_xPosLeft&& cursorPosition.x<_xPosRight)
        {
            _prefab.transform.position = new Vector2(cursorPosition.x, _startPos.position.y);      
        }
        
    }
    private void OnMouseUp()
    {
        if (_prefab != null) {
            _prefab.GetComponent<Rigidbody2D>().isKinematic = false;
            _prefab = null;
            _coolDown = true;
            _timer = 0.8f;
        }
    }
    private void InstantiatePref()
    {
        StartCoroutine(nameof(Wait));
        if (!_endGame)
        {
            var tempPref = NextRandNumber switch
            {
                1 => _prefabSnow1,
                2 => _prefabSnow2,
                3 => _prefabSnow3,
                _ => _prefabSnow1,
            };
            _prefab = _catsPool.GetPooledObject(tempPref);
            _prefRigid = _prefab.GetComponent<Rigidbody2D>();
            _prefRigid.isKinematic = true;
            NextRandNumber = UnityEngine.Random.Range(1, 4);
            PrefInitAction?.Invoke();

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(4f);
    }
    private void MergeSnows(GameObject self,Collision2D collision)
    {
        StartCoroutine(nameof(Wait));
        string selfTag = self.tag;
        string collisionTag = collision.gameObject.tag;

        int selfId = self.GetHashCode();
        int colId = collision.gameObject.GetHashCode();
        int minId;
        if (selfId < colId)
        {
            minId = selfId;
        }
        else
        {
            minId = colId;
        }
        GameObject nextPref = _snowFlakesData.ReturnNextPref(selfTag);
        if (selfTag == collisionTag)
        {
            if (nextPref != null && minId == selfId && selfTag != "snow10")
            {
                Vector2 middlePos = collision.transform.position;

                _catsPool.RemovePooledObject(self);
                _catsPool.RemovePooledObject(collision.gameObject);
                
                GameObject pref = _catsPool.GetPooledObject(nextPref);
                pref.transform.position = middlePos;
                pref.SetActive(true);
                pref.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2);

                EventsController.InvokeAddScoreEvent(_snowFlakesData.GetScoreCost(selfTag));

                GameObject particle = Instantiate(_particlePrefab);
                particle.GetComponent<Renderer>().sortingOrder = 2;
                particle.transform.position = middlePos;
            }
            else if (selfTag == "snow10")
            {
                _catsPool.RemovePooledObject(self);
                _catsPool.RemovePooledObject(collision.gameObject);
            }
        }
    }

    private void EndGame()
    {
        _endGame = true;
    }

    
}
