using UnityEngine;
public class FloorEndGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string colTag = collision.gameObject.tag;
        if (colTag == "Player")
        {
            EventsController.InvokeLooseGameAction();
            collision.gameObject.SetActive(false);
        }
    }
}
