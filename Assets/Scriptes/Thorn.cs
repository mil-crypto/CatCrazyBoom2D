using System.Collections;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _thornRigid; // Rigidbody для птицы
    [SerializeField] private Rigidbody2D _shootRigid; // Rigidbody для рогатки

    [SerializeField] private GameObject _thornPrefab; // префаб для птицы
    [SerializeField] private Transform _thornSpawnerPos; // позиция птицы

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
        //Destroy(gameObject, 5); 

        //yield return new WaitForSeconds(2); 

        //if (_thornPrefab != null) 
       // {
        //    _thornPrefab.transform.position = _thornSpawnerPos.position; // то птички (которые находятся на земле) перемещаются на рогатку
      // }

       // else
        //{
         //   SceneManager.LoadScene(0); // если птички кончились, то сцена перезапускается
        //}
    }
}
