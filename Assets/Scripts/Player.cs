using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private const float Speed = 8;
    private const float JumpForce = 13;
    [SerializeField] private Rigidbody2D rb;

    

    void Update()
    {
        if (Global.PlayMode)
        {
            rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);

            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, y: JumpForce);
        }
    }
}
