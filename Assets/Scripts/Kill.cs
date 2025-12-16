using UnityEngine;
using UnityEngine.UI;

public class Kill : MonoBehaviour
{
    //checks if the spike and player has collided
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            //if the player script is active it calls Die in player script
            if (player != null)
            {
                player.Die();
            }
        }
    }


}
