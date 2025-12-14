using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float SmoothSpeed = 0.125f;
    private float StartFollow = 0;
    public Vector3 offset;

    private bool isFollowing = false;
   

    private void Update()
    {
        if(!isFollowing && player != null)
        {
            if (player.position.x >= StartFollow) 
            {
                isFollowing = true;
            }
        }

        if (isFollowing && player != null)
        {
            var desiredPosition = player.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);

            var freezeY = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
            transform.position = freezeY;
        }
    }
}
