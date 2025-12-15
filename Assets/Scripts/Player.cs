using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private const float Speed = 8;
    private const float JumpForce = 10;
    [SerializeField] private Rigidbody2D rb;

    private bool isGrounded;

    [SerializeField] private Transform groundCheckObject;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ParticleSystem ps;


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, 0.1f, layerMask);

        if (Global.PlayMode)
        {
            rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);

            Jump();
            Particle();
        }

    }
    private void Particle()
    {
        var velocity = ps.velocityOverLifetime;
        velocity.x = rb.linearVelocity.x;

        if (isGrounded)
        {
            ps.Play();
        }
        else
        {
            ps.Stop();
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, y: JumpForce);
        }
    }
}
