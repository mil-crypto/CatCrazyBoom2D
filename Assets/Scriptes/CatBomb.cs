using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBomb : MonoBehaviour
{
    private bool _endGame;
    private List<GameObject> _cats = new List<GameObject>();
    [SerializeField] private GameObject _exploseEffect;
    private void Start()
    {
        _endGame = false;
    }
    private void OnEnable()
    {
        FloorEndGame.EndGameAction += EndGame;   
    }
    private void OnDisable()
    {
        FloorEndGame.EndGameAction -= EndGame;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("col.gameObject.tag = " +col.gameObject.tag);
        Debug.Log("_catsCount in Explose = "+_cats.Count);
        if (!_endGame)
        {
            switch (col.tag)
                {
                    case "snow1":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow2":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow3":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow4":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow5":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow6":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow7":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow8":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow9":
                        _cats.Add(col.gameObject);
                        break;
                    case "snow10":
                        _cats.Add(col.gameObject);
                        break;
                }
        }

        StartCoroutine(nameof(Explose));
    }
    private IEnumerator Explose()
    {
        yield return new WaitForSeconds(3f);
        GameObject particle = Instantiate(_exploseEffect);
        particle.GetComponent<Renderer>().sortingOrder = 4;
        particle.transform.position = transform.position;
        foreach(GameObject cat in _cats)
        {
            cat.gameObject.SetActive((false));
        }
        Destroy(gameObject);
    }
    
    private void EndGame()
    {
        _endGame = true;
    }
}
