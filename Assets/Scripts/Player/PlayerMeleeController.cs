using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeController : MonoBehaviour
{
    [SerializeField]
    LayerMask whatIsEnemy;

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float heavyAttackRate = 3;

    [SerializeField]
    float attackCooldown = 1.0F;
    

    [SerializeField]
    int attackRate = 1;
    
    [SerializeField]
    float attackDamage = 15.0F;

    [SerializeField]
    float heavyAttackDamage = 25.0F;

    [SerializeField]
    Animator animator;

    float nextAttackTime;
    float nextHeavyAttackTime;

    void Start()
    {
        FindObjectOfType<PlayerCombatController>()?.onAttack.AddListener(Attack);
        FindObjectOfType<PlayerCombatController>()?.onHeavyAttack.AddListener(HeavyAttack);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) {
            if (Time.time >= nextAttackTime) {
                nextAttackTime = Time.time + 1.0F / attackRate;
                animator.SetTrigger("LightAttack");
            }
        }

        if (Input.GetKeyUp(KeyCode.Q)) {
            if (Time.time >= nextHeavyAttackTime) {
                nextHeavyAttackTime = Time.time + 3.0F;
                animator.SetTrigger("HeavyAttack");
            }
        }
    }

    void Attack()
    {
        Collider2D[] colliders
            = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, whatIsEnemy);

        foreach (Collider2D collider in colliders)
        {
            EnemyHealthController controller = collider.GetComponent<EnemyHealthController>();
            Debug.Log("LightAttacking " + collider.name);
            if (controller != null)
            {
                controller.TakeDamage(attackDamage);
            }

            
            
        }

        animator.ResetTrigger("LightAttack");
    }

    void HeavyAttack()
    {
        Collider2D[] colliders
            = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, whatIsEnemy);

        foreach (Collider2D collider in colliders)
        {
            EnemyHealthController controller = collider.GetComponent<EnemyHealthController>();
            Debug.Log("HeavyAttacking " + collider.name);
            if (controller != null)
            {
                controller.TakeDamage(heavyAttackDamage);
            }
            
        }

        animator.ResetTrigger("HeavyAttack");
    }



    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
