using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onAttack;

    [SerializeField]
    public UnityEvent onHeavyAttack;

    void Attack()
    {
        if (onAttack != null)
        {
            onAttack.Invoke();
        }

    }

    void HeavyAttack()
    {
        if (onHeavyAttack != null)
        {
            onHeavyAttack.Invoke();
        }

    }

}


