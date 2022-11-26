using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0F;

    [SerializeField]
    float currentHealth;

    [SerializeField]
    public UnityEvent<GameObject, float, float> onDamage;

    [SerializeField]
    public UnityEvent<GameObject> onDie;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (onDamage != null)
        {
            onDamage.Invoke(gameObject, damage, currentHealth);
        }

        

        if (currentHealth <= 0.0F)
        {
            if (onDie != null)
            {
                onDie.Invoke(gameObject);
            }
        }
    }
}
