using UnityEngine;
public class Finger : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private Thorn _thorn;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        _thorn.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
