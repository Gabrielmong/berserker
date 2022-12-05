using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossCombatController : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onEnemyAttack;

    void Attack()
    {
        if (onEnemyAttack != null)
        {
            onEnemyAttack.Invoke();
        }

    }

}


