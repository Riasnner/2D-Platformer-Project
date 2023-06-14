using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private ParticleSystem dust;
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jump = 14f;

    private enum MovementState { idle, jumping, running, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState State;

        if (dirX > 0)
        {
            State = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            State = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            State = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            State = MovementState.jumping;
            CreateDust();
        }
        else if (rb.velocity.y < -.1f)
        {
            State = MovementState.falling;
        }

        anim.SetInteger("State", (int)State);
    }

    private bool IsGrounded()
    {
       return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void StopPlayer()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void CreateDust()
    {
        dust.Play();
    }
}
