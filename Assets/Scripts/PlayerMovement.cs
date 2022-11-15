using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 6;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    // Jump cooldown
    float jumpCooldown = 1.0f;
    float timeSinceJump = 0.0f;

    // Sound Effects
    [SerializeField] private AudioSource jumpSoundEffect;

    private void Awake()
    {
        // Grab references for rigidbody2d and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        timeSinceJump += Time.deltaTime;

        float horizontalInput = SimpleInput.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        } 
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
            if (timeSinceJump > jumpCooldown)
                Jump();

        // Set animator parameter
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    public void Jump()
    {
        if (timeSinceJump > jumpCooldown && grounded)
        { 
            jumpSoundEffect.Play();
            timeSinceJump = 0;
            body.velocity = new Vector2(body.velocity.x, 14);
            anim.SetTrigger("jump");
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
