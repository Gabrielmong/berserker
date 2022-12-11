using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    public float maxHealth = 100.0F;

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    public UnityEvent<GameObject, float, float> onPlayerDamage;

    [SerializeField]
    public UnityEvent<GameObject> onPlayerDie;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth < 0.0F)
        {
            currentHealth = 0.0F;
        }
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

    public void HealPlayer()
    {
        currentHealth += 25.0F;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    


}
