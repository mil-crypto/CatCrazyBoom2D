using UnityEngine;

public class Thorn : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [SerializeField] private BaloonsList _baloonsList;
    
    Camera cam;
    [SerializeField] private Trajectory _trajectory;
    [SerializeField] private float _pushForce = 4f;
    [SerializeField] private float _maxDistance;
    [SerializeField] private bool _activeFinger;

    private bool _isDragging = false;

    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _direction;
    private Vector2 _force;
    private float _distance;
    private bool _activeRB;

    //---------------------------------------
    void Start ()
    {
        cam = Camera.main;
        DesactivateRb();
        if (_activeFinger)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        }

        _activeRB = true;
    }
    
    [HideInInspector] public Vector3 pos { get { return transform.position; } }

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        col = GetComponent<CircleCollider2D> ();
    }

    public void Push (Vector2 force)
    {
        rb.AddForce (force, ForceMode2D.Impulse);
    }

    public void ActivateRb ()
    {
        rb.isKinematic = false;
    }

    public void DesactivateRb ()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("wall"))
        {
            EventsController.InvokeOnTriggerWallEvent(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
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
    }

    private void OnMouseDown()
    {
        if (_activeRB)
        {
        PauseOF();
        DesactivateRb(); 
        Debug.Log(_activeRB);
        _startPoint = cam.ScreenToWorldPoint (Input.mousePosition);
        _trajectory.Show ();
        }
    }
    private void OnMouseDrag()
    {
        if (_activeRB)
        {
            _endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            _distance = Vector2.Distance(_startPoint, _endPoint);
            if (_distance > _maxDistance)
            {
                _distance = _maxDistance;
            }

            _direction = (_startPoint - _endPoint).normalized;
            _force = _direction * (_distance * _pushForce);
            _trajectory.UpdateDots(pos, _force);
        }

    }
    private void OnMouseUp() 
    {
        if (_activeRB)
        {
            ActivateRb();
            Push(_force);
            _activeRB = false;
        }

        _trajectory.Hide ();
    }
    private void PauseOF()
    {
        Time.timeScale = 1f;
    }
}
