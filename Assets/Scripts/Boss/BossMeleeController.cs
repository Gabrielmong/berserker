using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeController : MonoBehaviour
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
        // find all the combat controllers in the scene
        var combatControllers = FindObjectsOfType<BossCombatController>();

        // add event listeners to each combat controller
        foreach (var combatController in combatControllers)
        {
            combatController.onEnemyAttack.AddListener(Attack);
        }

    }

    void Update()
    {
        
    }

    void Attack()
    {
        Debug.Log("Enemy Attack");
        Collider2D[] colliders
            = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, whatIsEnemy);

        foreach (Collider2D collider in colliders)
        {
            PlayerHealthController controller = collider.GetComponent<PlayerHealthController>();
            Debug.Log("Collding with " + collider.name);
            if (controller != null)
            {
                controller.TakeDamage(attackDamage);
            }
            
        }

        animator.ResetTrigger("Attack");
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
