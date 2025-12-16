using UnityEngine;
using UnityEngine.UI;

public class SlideUp : MonoBehaviour
{
    public Transform player;
    public float triggerX;

    public float slideDistance = 3f;
    public float slideSpeed = 5f;

    private Vector3 targetPos;
    private bool sliding = false;
    Collider2D col;
    private Vector3 hiddenPos;

    void Start()
    {
        targetPos = transform.position;
        hiddenPos = targetPos - new Vector3(0, slideDistance, 0);

        col = GetComponent<Collider2D>();
        if (col) col.enabled = false;
    }

    void Update()
    {
        if (!sliding && player.position.x >= triggerX)
        {
            sliding = true;
        }

        if (sliding)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                slideSpeed * Time.deltaTime
            );
        }
        if (transform.position == targetPos && col)
        {
            col.enabled = true;
        }
    }

    public void ResetPosition()
    {
        transform.position = hiddenPos;
        sliding = false;
    }
}
