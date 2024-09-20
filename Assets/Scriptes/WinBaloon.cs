using UnityEngine;
using DG.Tweening;

public class WinBaloon : MonoBehaviour
{
    private void Start()
    {
        transform.DOScale(new Vector2(1.2f,1.2f),0.5f).SetLoops(-1,LoopType.Yoyo);
    }
}
