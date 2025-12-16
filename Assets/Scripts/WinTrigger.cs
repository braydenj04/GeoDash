using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameManager gameManager;

    //this checks if the player and the finish line have collided if so win screen appears
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.WinGame();
        }
    }
}
