using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbarController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 localScale;
    [SerializeField]
    PlayerHealthController playerHealthController;
    void Start()
    {
        localScale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = playerHealthController.currentHealth / playerHealthController.maxHealth;
        transform.localScale = localScale;
    }
}
