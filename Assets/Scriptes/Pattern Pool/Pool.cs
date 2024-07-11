using System.Collections.Generic;
using UnityEngine;
public class Pool : MonoBehaviour
{
    private List <GameObject> _poolList = new();
    private int amount;
    public Pool(GameObject prefab,int amount)
    {
        GameObject tmp;
        this.amount = amount;
        for(int i = 0; i < amount; i++)
        {
            tmp = Instantiate(prefab);
            tmp.SetActive(false);
            _poolList.Add(tmp);
        }
    }

    public GameObject GetObject()
    {
        GameObject temp = null;
        for (int i = 0; i < _poolList.Count; i++)
        {
            if (!_poolList[i].activeInHierarchy)
            {
                temp = _poolList[i];
                temp.SetActive(true);
                break;
            }
        }
        return temp;
    }
     public void RemoveObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
