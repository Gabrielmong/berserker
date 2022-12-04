using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0F;

    [SerializeField]
    float currentHealth;

    [SerializeField]
    public UnityEvent<GameObject, float, float> onEnemyDamage;

    [SerializeField]
    public UnityEvent<GameObject> onEnemyDie;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (onEnemyDamage != null)
        {
            
            onEnemyDamage.Invoke(gameObject, damage, currentHealth);
        }

        

        if (currentHealth <= 0.0F)
        {
            if (onEnemyDie != null)
            {
                onEnemyDie.Invoke(gameObject);
            }
        }
    }
}
