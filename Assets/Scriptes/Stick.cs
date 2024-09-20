using DG.Tweening;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Vector3[] _wayPoints;
    void Start()
    {
        transform.DOPath(_wayPoints, 3, PathType.CatmullRom).SetOptions(true).SetEase(Ease.Linear)
            .SetLoops(-1);
    }
}
