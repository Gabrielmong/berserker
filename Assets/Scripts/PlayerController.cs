using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    Animator animator;

    [Header("Move System")]
    [SerializeField]
    float speed = 3.0F;
    [SerializeField]
    bool isFacingRight = true;

    [Header("Jump System")]
    [SerializeField]
    float jumpPower = 6.0F;
    [SerializeField]
    LayerMask whatIsGround;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    float jumpTime = 0.5F;
    [SerializeField]
    float jumpMultiplier = 0.5F;
    [SerializeField]
    float fallMultiplier = 2.5F;
    bool wasFacingRight;
    Vector2 move;
    bool isJumpPressed;
    float jumpCounter;
    Vector2 reverseGravity;

    bool isRunning;
    bool grounded;
    void Start()
    {
        wasFacingRight = isFacingRight;
        reverseGravity = new Vector2(0.0F, -Physics2D.gravity.y);
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        grounded = IsGrounded();
    }
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0.0F);


        if (Input.GetButtonDown("Jump"))
        {
            // Permite el salto solamente cuando el personaje esta tocando el piso
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpCounter = 0.0F;
                isJumpPressed = true;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumpPressed = false;
            jumpCounter = 0.0F;
            if (rb.velocity.y > 0.0F)
            {
                // Reduce el salto en un 60%
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6F);
                animator.ResetTrigger("Grounded");
            }
        }
        if (rb.velocity.y > 0.0F)
        {
            if (isJumpPressed)
            {
                // Incrementa el salto por un factor multiplicativo
                // de manera uniforme entre frames
                rb.velocity += reverseGravity * jumpMultiplier * Time.deltaTime;
                jumpCounter += Time.deltaTime;
                if (jumpCounter > jumpTime)
                {
                    isJumpPressed = false;
                    jumpCounter = 0;
                    // Reduce el salto en un 60%
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6F);
                }
            }
        }
        if (rb.velocity.y < 0.0F)
        {
            // Cae con mayor velocidad que la utilizada en el ascenso
            rb.velocity -= reverseGravity * fallMultiplier * Time.deltaTime;
        }

        if (!grounded)
        {
            bool isGrounded = IsGrounded();
            if (grounded = isGrounded)
            {
                grounded = isGrounded;
                animator.SetTrigger("Grounded");
            }
        }

        


    }
    void FixedUpdate()
    {
        Debug.Log(rb.velocity.y);
        if (rb.velocity.y > 1.2F)
        {
            if (animator.GetFloat("Power") != 1.0F)
            {
                animator.SetFloat("Power", 1.0F);
            }
            grounded = false;
        }
        else if (rb.velocity.y < -1.2F)
        {
            if (animator.GetFloat("Power") != -1.0F)
            {
                animator.SetFloat("Power", -1.0F);
            }
            grounded = false;
        }

        if (animator.GetFloat("Speed") != Mathf.Abs(move.x))
        {
            animator.SetFloat("Speed", Mathf.Abs(move.x));
        }

         if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", 2.0F);
            speed = 6.0F;
            isRunning = true;
        }

        if (isRunning) {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetFloat("Speed", 1.0F);
                speed = 3.0F;
                isRunning = false;
            }
        }     
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        Debug.Log("Speed: " + animator.GetFloat("Speed"));
        animator.ResetTrigger("Grounded");
        Flip();
        
    }
    void Flip()
    {
        if (move.x != 0.0F)
        {
            // Calcula si el personaje esta mirando hacia la derecha o la izquierda
            bool facingRight =
                move.x > 0.0F;
            // Si ha cambiado la vista de derecha a izquierda o viceversa
            if (wasFacingRight != facingRight)
            {
                wasFacingRight = facingRight;
                // Gira el personaje en su eje X
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
            }
        }
    }
    bool IsGrounded()
    {
        return
            Physics2D.OverlapCapsule
                (
                    groundCheck.position,
                    new Vector2(0.41F, 0.21F),
                    CapsuleDirection2D.Horizontal,
                    0.0F,
                    whatIsGround
                );
    }
}
