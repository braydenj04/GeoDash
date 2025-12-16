using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;

    //sets the speed
    private float SmoothSpeed = 0.125f;

    //set the x position which the camera should start following the player
    private float StartFollow = 0;
    public Vector3 offset;

    private bool isFollowing = false;
   

    private void Update()
    {
        //checks the camera is not following
        if(!isFollowing && player != null)
        {
            //checks the player has reached the x position and then the camera will follow the player if true
            if (player.position.x >= StartFollow) 
            {
                isFollowing = true;
            }
        }

        //checks if is following is active
        if (isFollowing && player != null)
        {
            //calculates where the camera should be
            var desiredPosition = player.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);

            //freezes the Y axis so the camera only follows along the X axis
            var freezeY = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
            transform.position = freezeY;
        }
    }
}
