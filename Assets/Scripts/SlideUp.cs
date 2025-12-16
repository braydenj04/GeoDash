using UnityEngine;
using UnityEngine.UI;

public class SlideUp : MonoBehaviour
{
    public Transform player;

    //when the player hits the trigger the sprites will slide onto the screen
    public float triggerX;
    //slide distance and speed are how far off screen the sprites should start and how fast they go back to their correct position
    public float slideDistance = 3f;
    public float slideSpeed = 5f;

    private Vector3 targetPos;
    private bool sliding = false;
    private bool hasTriggered = false;

    Collider2D col;
    private Vector3 hiddenPos;

    public static readonly System.Collections.Generic.List<SlideUp> AllSlides
        = new System.Collections.Generic.List<SlideUp>();

    void OnEnable()
    {
        AllSlides.Add(this);
    }

    void OnDisable()
    {
        AllSlides.Remove(this);
    }

    void Start()
    {
        //targetpos is where the sprite will move to
        targetPos = transform.position;

        //works out where the sprite should sit while hidden
        hiddenPos = targetPos - new Vector3(0, slideDistance, 0);

        //moves the sprites to the hidden position at the start of the game
        transform.position = hiddenPos; 
        sliding = false;

        //this stops the player from colliding with the platforms and spikes while hidden
        col = GetComponent<Collider2D>();
        if (col) col.enabled = false;
    }

    void Update()
    {
        //checks if the player has reached the trigger position
        //has triggered makes it only run once 
        if (!hasTriggered && player.position.x >= triggerX)
        {
            hasTriggered = true;
            sliding = true;
        }

        //move the sprite to the correct position
        if (sliding)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                slideSpeed * Time.deltaTime
            );
        }
        //turns collision back on once it has reached the right position
        if (transform.position == targetPos && col)
        {
            col.enabled = true;
        }
    }

    //called when restart button is clicked
    public void ResetPosition()
    {
        //moves the sprites back to the hidden position
        transform.position = hiddenPos;
        //resets triggers
        sliding = false;
        hasTriggered = false;
        //disables collision
        if (col) col.enabled = false;
    }
}
