using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0F;

    [SerializeField]
    float currentHealth;

    [SerializeField]
    public UnityEvent<GameObject, float, float> onPlayerDamage;

    [SerializeField]
    public UnityEvent<GameObject> onPlayerDie;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (onPlayerDamage != null)
        {
            
            onPlayerDamage.Invoke(gameObject, damage, currentHealth);
        }

        

        if (currentHealth <= 0.0F)
        {
            if (onPlayerDie != null)
            {
                onPlayerDie.Invoke(gameObject);
            }
        }
    }
}
