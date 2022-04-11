using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   private Rigidbody2D rb;
    private SpriteRenderer Sprite;
   private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            Sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            Sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
