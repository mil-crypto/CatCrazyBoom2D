using System.Collections.Generic;
using UnityEngine;

public class ArrayPoolBase : MonoBehaviour
{
    private List<GameObject> _activeCats1 = new();
    private List<GameObject> _activeCats2 = new();
    private List<GameObject> _activeCats3 = new();
    private List<GameObject> _activeCats4 = new();
    private List<GameObject> _activeCats5 = new();
    private List<GameObject> _activeCats6 = new();
    private List<GameObject> _activeCats7 = new();
    private List<GameObject> _activeCats8 = new();
    private List<GameObject> _activeCats9 = new();
    private List<GameObject> _activeCats10 = new();
    private readonly int _amountToPool=10;
    public void ActivatePoolBase(GameObject [] items)
    {
        GameObject tmp;
        int length = items.Length;
        for (int i = 0; i < _amountToPool; i++)
        {
            for(int j = 0; j < length; j++)
            {
                switch (items[j].tag)
                {
                    case "snow1":
                        tmp = Instantiate(items[0]);
                        tmp.SetActive(false);
                        _activeCats1.Add(tmp);
                        break;
                    case "snow2":
                        tmp = Instantiate(items[1]);
                        tmp.SetActive(false);
                        _activeCats2.Add(tmp);
                        break;
                    case "snow3":
                        tmp = Instantiate(items[2]);
                        tmp.SetActive(false);
                        _activeCats3.Add(tmp);
                        break;
                    case "snow4":
                        tmp = Instantiate(items[3]);
                        tmp.SetActive(false);
                        _activeCats4.Add(tmp);
                        break;
                    case "snow5":
                        tmp = Instantiate(items[4]);
                        tmp.SetActive(false);
                        _activeCats5.Add(tmp);
                        break;
                    case "snow6":
                        tmp = Instantiate(items[5]);
                        tmp.SetActive(false);
                        _activeCats6.Add(tmp);
                        break;
                    case "snow7":
                        tmp = Instantiate(items[6]);
                        tmp.SetActive(false);
                        _activeCats7.Add(tmp);
                        break;
                    case "snow8":
                        tmp = Instantiate(items[7]);
                        tmp.SetActive(false);
                        _activeCats8.Add(tmp);
                        break;
                    case "snow9":
                        tmp = Instantiate(items[8]);
                        tmp.SetActive(false);
                        _activeCats9.Add(tmp);
                        break;
                    case "snow10":
                        tmp = Instantiate(items[9]);
                        tmp.SetActive(false);
                        _activeCats10.Add(tmp);
                        break;
                }
            }
        }
    }

    public GameObject GetPooledObject(GameObject item)
    {
        GameObject @object = null;
        for (int i = 0; i < _amountToPool; i++)
        {
            switch (item.tag)
            {
                case "snow1":
                    if (!_activeCats1[i].activeInHierarchy)
                    {
                        @object= _activeCats1[i];
                    }
                    break;
                case "snow2":
                    if (!_activeCats2[i].activeInHierarchy)
                    {
                        @object = _activeCats2[i];
                    }
                    break;
                case "snow3":
                    if (!_activeCats3[i].activeInHierarchy)
                    {
                        @object = _activeCats3[i];
                    }
                    break;
                case "snow4":
                    if (!_activeCats4[i].activeInHierarchy)
                    {
                        @object = _activeCats4[i];
                    }
                    break;
                case "snow5":
                    if (!_activeCats5[i].activeInHierarchy)
                    {
                        @object = _activeCats5[i];
                    }
                    break;
                case "snow6":
                    if (!_activeCats6[i].activeInHierarchy)
                    {
                        @object = _activeCats6[i];
                    }
                    break;
                case "snow7":
                    if (!_activeCats7[i].activeInHierarchy)
                    {
                        @object = _activeCats7[i];
                    }
                    break;
                case "snow8":
                    if (!_activeCats8[i].activeInHierarchy)
                    {
                        @object = _activeCats8[i];
                    }
                    break;
                case "snow9":
                    if (!_activeCats9[i].activeInHierarchy)
                    {
                        @object = _activeCats9[i];
                    }
                    break;
                case "snow10":
                    if (!_activeCats10[i].activeInHierarchy)
                    {
                        @object = _activeCats10[i];
                    }
                    break;
            }
            
        }
        if (@object != null)
        {
            @object.SetActive(true);
        }
        return @object;
    }
    public void RemovePooledObject(GameObject item)
    {
        item.SetActive(false);
    }
}
