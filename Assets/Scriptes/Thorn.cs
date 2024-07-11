using System.Collections;
using UnityEngine;
public class Thorn : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _thornRigid; // Rigidbody для птицы
    [SerializeField] private Rigidbody2D _shootRigid; // Rigidbody для рогатки

    [SerializeField] private BaloonsList _baloonsList;

    [SerializeField] private float _maxDistance = 3f; // максимальный радиус окружности, куда можно увести снаряд

    [SerializeField] private bool _isPressed = false; 

    private void Start()
    {
        _thornRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isPressed == true) 
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, _shootRigid.position) > _maxDistance) 
            {
                _thornRigid.position = _shootRigid.position + (mousePos - _shootRigid.position).normalized * _maxDistance; 
            }
            else
            {
                _thornRigid.position = mousePos; 
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("baloon"))
        {
            col.gameObject.SetActive(false);
            EventsController.InvokeOnTriggerCatEvent(col.gameObject);
            foreach (var VARIABLE in _baloonsList.GetBaloonList())
            {
                if (VARIABLE.activeSelf)
                {
                    return;
                }
            }
            EventsController.InvokeEndLevelEvent();
            gameObject.SetActive(false);
        }
        else if (col.gameObject.CompareTag("wall"))
        {
            EventsController.InvokeOnTriggerWallEvent(gameObject);
        }
    }
    private void OnMouseDown()
    {
        _isPressed = true; 
        _thornRigid.isKinematic = true; 
    }

    private void OnMouseUp() 
    {
        _isPressed = false; 
        _thornRigid.isKinematic = false; 

        StartCoroutine(LetGo()); 
    }

    IEnumerator LetGo()
    {
        yield return new WaitForSeconds(0.1f); 

        gameObject.GetComponent<SpringJoint2D>().enabled = false; 
        this.enabled = false;
    }
}
