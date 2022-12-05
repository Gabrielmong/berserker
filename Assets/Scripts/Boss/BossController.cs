using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    Animator animator;

    [Header("Move System")]
    [SerializeField]
    float speed = 2.2F;
    [SerializeField]
    bool isFacingRight = true;

    [Header("Jump System")]
    [SerializeField]
    float jumpPower = 6.0F;
    [SerializeField]
    float attackRange;
    [SerializeField]
    float walkingDistance;
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

    [SerializeField]
    private GameObject WinMenu;
    bool wasFacingRight;
    Vector2 move;
    bool isJumpPressed;
    float jumpCounter;
    Vector2 reverseGravity;

    bool isRunning;
    bool grounded;

    bool isAttacking;

    bool isPatroling;

    bool dead;

    float nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Patrol());
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            // get the player object
            GameObject player = GameObject.Find("Player");
            // get the distance between the player and the enemy
            float distance = Vector2.Distance(player.transform.position, transform.position);
            // if the attack point is colliding with the player, attack
            if (!isAttacking && distance < attackRange)
            {
                // stop the patrol
                StopCoroutine(Patrol());
                // face the player
                if (player.transform.position.x > transform.position.x)
                {
                    isFacingRight = true;
                }
                else
                {
                    isFacingRight = false;
                }
                // attack if the time is right
                if (Time.time > nextAttackTime)
                {
                    nextAttackTime = Time.time + 2.5F;
                    StartCoroutine(Attack());
                }
            }
            else
            {
                isAttacking = false;
                if (!isPatroling && distance > walkingDistance)
                {
                    StartCoroutine(Patrol());
                }
            }

            // if the distance is greater than 2, but less than 5, then chase
            if (distance < 9 && distance > walkingDistance)
            {
                // stop the patrol
                StopCoroutine(Patrol());
                // face the player
                if (player.transform.position.x > transform.position.x)
                {
                    isFacingRight = true;
                }
                else
                {
                    isFacingRight = false;
                }
                // move towards the player
                if (player.transform.position.x > transform.position.x)
                {
                    move = new Vector2(1.0F, 0.0F);
                }
                else
                {
                    move = new Vector2(-1.0F, 0.0F);
                }
            }



            // if the distance is greater than 4, then patrol
            if (distance > 9)
            {
                isAttacking = false;
                if (!isPatroling)
                {
                    StartCoroutine(Patrol());
                }
            }
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        // stop player from moving
        move = Vector2.zero;
        // play light attack animation
        animator.SetTrigger("Attack");
        Debug.Log("Attacking");
        // wait for animation to finish
        yield return new WaitForSeconds(0.43f);
        isAttacking = false;
        animator.ResetTrigger("Attack");
    }

    void FixedUpdate()
    {
        if (!dead)
        {
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

            rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
            animator.ResetTrigger("Grounded");
            Flip();
        }
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

    public void OnDie()
    {
        dead = true;
        animator.SetTrigger("Die");

        // disable rigidbody
        rb.simulated = false;

        // show win menu

        WinMenu.SetActive(true);

    }

    public void onDamage()
    {
        animator.SetTrigger("Damage");
    }

    // patrol enemy movement side to side for 2 seconds
    IEnumerator Patrol()
    {
        isPatroling = true;
        // move enemy right
        move = Vector2.right;
        // wait 2 seconds
        yield return new WaitForSeconds(1.5f);
        // move enemy left
        move = Vector2.left;
        // wait 2 seconds
        yield return new WaitForSeconds(1.5f);
        // stop enemy movement
        move = Vector2.zero;
        // wait 2 seconds
        yield return new WaitForSeconds(1.5f);
        isPatroling = false;
    }


}
