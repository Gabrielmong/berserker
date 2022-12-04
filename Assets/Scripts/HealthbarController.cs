using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbarController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 localScale;
    [SerializeField]
    EnemyHealthController enemyHealthController;
    void Start()
    {
        localScale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = enemyHealthController.currentHealth / enemyHealthController.maxHealth;
        transform.localScale = localScale;
    }
}
