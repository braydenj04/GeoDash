using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //sets the speed
    private const float Speed = 8;

    //sets the jump force
    private const float JumpForce = 10;
    [SerializeField] private Rigidbody2D rb;

    //isgrounded checks if the player is touching the ground
    private bool isGrounded;

    [SerializeField] private Transform groundCheckObject;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ParticleSystem ps;


    void Update()
    {
        //checks if the player is touching the ground
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, 0.1f, layerMask);

        //only runs if game is in playmode
        if (Global.PlayMode)
        {
            //sets the player to constantly be moving forward on the x axis
            rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);

            //calls jump and particle
            Jump();
            Particle();
        }

    }

    //controls the particles coming off the player while moving along the ground
    private void Particle()
    {
        //match the player movement and the particle movement
        var velocity = ps.velocityOverLifetime;
        velocity.x = rb.linearVelocity.x;

        //play the particle effect while player is on the grouns and stop it while in the air
        if (isGrounded)
        {
            ps.Play();
        }
        else
        {
            ps.Stop();
        }
    }

    //controls the jump
    private void Jump()
    {
        // player can only jump when the space bar is clicked and player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, y: JumpForce);
        }
    }

    //called when player dies
    public void Die()
    {
        //calls playerdied in gamemanager
        GameManager.Instance.PlayerDied();
    }
}
