using UnityEngine;
using System;

public class CollisionSnowFlake : MonoBehaviour
{
    public static event Action<GameObject , Collision2D> Collission2ArgumentAction;
    private bool _endGame;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_endGame)
        {
            Collission2ArgumentAction?.Invoke(gameObject, collision);
        }
    }
    private void EndGame()
    {
        _endGame = true;
    }
}
