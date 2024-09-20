using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneService : MonoBehaviour
{
    [SerializeField] private int _maxLvl;
    private void OnEnable()
    {
        EventsController.RestartEvent += Restart;
        EventsController.NextLvlEvent += NextLvl;
    }

    private void OnDisable()
    {
        EventsController.RestartEvent -= Restart;
        EventsController.NextLvlEvent -= NextLvl;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void NextLvl()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < _maxLvl)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
