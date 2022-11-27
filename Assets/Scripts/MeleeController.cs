using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [SerializeField]
    LayerMask whatIsEnemy;

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float attackCooldown = 1.0F;

    [SerializeField]
    int attackRate = 1;
    
    [SerializeField]
    float attackDamage = 10.0F;

    [SerializeField]
    Animator animator;

    float nextAttackTime;

    void Start()
    {
        FindObjectOfType<CombatController>()?.onAttack.AddListener(Attack);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) {
            if (Time.time >= nextAttackTime) {
                nextAttackTime = Time.time + 1.0F / attackRate;
                animator.SetTrigger("LightAttack");
            }
        }
    }

    void Attack()
    {
        Collider2D[] colliders
            = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, whatIsEnemy);

        foreach (Collider2D collider in colliders)
        {
            HealthController controller = collider.GetComponent<HealthController>();

            if (controller != null)
            {
                controller.TakeDamage(attackDamage);
            }
            
        }

        animator.ResetTrigger("LightAttack");
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
