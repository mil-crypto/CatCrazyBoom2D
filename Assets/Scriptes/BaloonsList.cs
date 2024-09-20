using System.Collections.Generic;
using UnityEngine;
public class BaloonsList : MonoBehaviour
{
    [SerializeField] private List<GameObject> _baloonsList;

    public List<GameObject> GetBaloonList()
    {
        return _baloonsList;
    }
}
