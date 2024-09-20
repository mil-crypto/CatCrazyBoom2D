using System.Collections;
using Scriptes;
using UnityEngine;
[RequireComponent(typeof(Pool))]
public class Effects : MonoBehaviour
{
    //[SerializeField] private GameObject _catTriggerEffect;
    [SerializeField] private GameObject _wallTriggerEffect;
    
    [SerializeField] private GameObject[] _blots;
    //[SerializeField] private Color[] _blotsColors;
    [SerializeField] private Color _redColor, _greenColor ,_azureColor,_violetColor,_yellowColor;

    [SerializeField] private GameObject _firework,_firework2,_firework3;
    [SerializeField] private Transform _fireworkTransform;

    [SerializeField] private GameObject _bublesAnimation;
    private Pool _poolBubles;
    private Pool _poolWallEffects;

    private void Start()
    {
        _poolBubles = GetComponent<Pool>();
        _poolWallEffects = GetComponent<Pool>();
        _poolBubles = new Pool(_bublesAnimation, 10);
        _poolWallEffects = new Pool(_wallTriggerEffect, 10);
    }
    private void OnEnable()
    {
        EventsController.OnTriggerCatEvent += ActivateTriggerBaloonEffect;
        EventsController.OnTriggerCatEvent += ActivateBlot;
        EventsController.OnTriggerWallEvent += ActivateTriggerWallEffect;
        EventsController.WinlevelEvent += ActivateFireworks;
    }
    private void OnDisable()
    {
        EventsController.OnTriggerCatEvent -= ActivateTriggerBaloonEffect;
        EventsController.OnTriggerCatEvent -= ActivateBlot;
        EventsController.OnTriggerWallEvent -= ActivateTriggerWallEffect;
        EventsController.WinlevelEvent -= ActivateFireworks;
    }
    private void ActivateTriggerBaloonEffect(GameObject obj)
    {
        var temp = _poolBubles.GetObject();
        if (obj.TryGetComponent<RedBaloon>(out RedBaloon red))
        {
            temp.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = _redColor;
            temp.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().color = _redColor;
            temp.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().color = _redColor;
            temp.transform.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().color = _redColor;
            temp.transform.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().color = _redColor;
            temp.transform.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().color = _redColor;
            temp.transform.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().color = _redColor;
            temp.transform.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>().color = _redColor;
            temp.transform.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>().color = _redColor;
        }

        if (obj.TryGetComponent<GreenBaloon>(out GreenBaloon green))
        {
            temp.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = _greenColor;
            temp.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().color = _greenColor;
            temp.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().color = _greenColor;
            temp.transform.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().color = _greenColor;
            temp.transform.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().color = _greenColor;
            temp.transform.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().color = _greenColor;
            temp.transform.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().color = _greenColor;
            temp.transform.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>().color = _greenColor;
            temp.transform.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>().color = _greenColor;
        }
        if (obj.TryGetComponent<VioletBaloon>(out VioletBaloon violet))
        {
            temp.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = _violetColor;
            temp.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().color = _violetColor;
            temp.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().color = _violetColor;
            temp.transform.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().color = _violetColor;
            temp.transform.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().color = _violetColor;
            temp.transform.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().color = _violetColor;
            temp.transform.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().color = _violetColor;
            temp.transform.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>().color = _violetColor;
            temp.transform.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>().color = _violetColor;
        }
        if (obj.TryGetComponent<YellowBaloon>(out YellowBaloon yellow))
        {
            temp.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = _yellowColor;
            temp.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().color = _yellowColor;
            temp.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().color = _yellowColor;
            temp.transform.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().color = _yellowColor;
            temp.transform.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().color = _yellowColor;
            temp.transform.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().color = _yellowColor;
            temp.transform.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().color = _yellowColor;
            temp.transform.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>().color = _yellowColor;
            temp.transform.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>().color = _yellowColor;
        }
        if (obj.TryGetComponent<AzureBaloon>(out AzureBaloon azure))
        {
            temp.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = _azureColor;
            temp.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().color = _azureColor;
            temp.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().color = _azureColor;
            temp.transform.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().color = _azureColor;
            temp.transform.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().color = _azureColor;
            temp.transform.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().color = _azureColor;
            temp.transform.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().color = _azureColor;
            temp.transform.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>().color = _azureColor;
            temp.transform.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>().color = _azureColor;
        }
        temp.transform.position=obj.transform.position;
        StartCoroutine(WaitRemove(_poolBubles,temp));
    }
    private void ActivateTriggerWallEffect(GameObject obj)
    {
        var temp = _poolWallEffects.GetObject();
        temp.transform.position = obj.transform.position;
        StartCoroutine(WaitRemove(_poolWallEffects,temp));
    }
    private IEnumerator WaitRemove(Pool pool ,GameObject obj)
    {
        yield return new WaitForSeconds(1);
        pool.RemoveObject(obj);
    }
    private void ActivateBlot(GameObject obj)
    {
        int rand = Random.Range(0, _blots.Length-1);
        var temp = Instantiate(_blots[rand]);
        if (obj.TryGetComponent<GreenBaloon>(out GreenBaloon green))
        {
            temp.GetComponent<SpriteRenderer>().color = _greenColor;
        }
        if (obj.TryGetComponent<RedBaloon>(out RedBaloon red))
        {
            temp.GetComponent<SpriteRenderer>().color = _redColor;
        }
        if (obj.TryGetComponent<VioletBaloon>(out VioletBaloon violet))
        {
            temp.GetComponent<SpriteRenderer>().color = _violetColor;
        }
        if (obj.TryGetComponent<YellowBaloon>(out YellowBaloon yellow))
        {
            temp.GetComponent<SpriteRenderer>().color = _yellowColor;
        }
        if (obj.TryGetComponent<AzureBaloon>(out AzureBaloon azure))
        {
            temp.GetComponent<SpriteRenderer>().color = _azureColor;
        }
        
        temp.transform.position = obj.transform.position;
    }
    private void ActivateFireworks()
    {
        var temp = Instantiate(_firework);
        var frwrk2 = Instantiate(_firework2);
        var frwrk3 = Instantiate(_firework3);
        temp.GetComponent<Renderer>().sortingOrder = 4;
        frwrk2.GetComponent<Renderer>().sortingOrder = 4;
        frwrk3.GetComponent<Renderer>().sortingOrder = 4;
        temp.transform.position = _fireworkTransform.position;
        frwrk2.transform.position = _fireworkTransform.position;
        frwrk3.transform.position = _fireworkTransform.position;
    }
    
    
}
