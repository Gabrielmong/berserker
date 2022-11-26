using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatController : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onAttack;

    void Attack()
    {
        if (onAttack != null)
        {
            onAttack.Invoke();
        }

    }

}


