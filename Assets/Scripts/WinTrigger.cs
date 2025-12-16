using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.WinGame();
        }
    }
}
