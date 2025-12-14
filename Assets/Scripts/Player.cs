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
            transform.Translate((Vector3)new Vector2(x: Speed * Time.deltaTime, y: 0));

            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, y: JumpForce);
        }
    }
}
