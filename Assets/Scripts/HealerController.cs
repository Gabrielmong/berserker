using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerController : MonoBehaviour
{

    [SerializeField]
    SoundsController soundsController;

    // a floating up and down effect for the healer item
    public float frequency = 1f;
    public float amplitude = 0.5f;

    // a reference to the player's health controller
    public PlayerHealthController playerHealthController;

    bool isCollidingWithHealer = false;

    // can only be used once    
    public bool isUsed = false;


    
    // Start is called before the first frame update
    void Start()
    {
        // get the player's health controller
        playerHealthController = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // a floating up and down effect for the healer item 
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * frequency) * amplitude * Time.deltaTime, transform.position.z);

        // if the player is colliding with the healer, heal the player
        if (isCollidingWithHealer)
        {
            // heal the player
            playerHealthController.HealPlayer();
            // set the isUsed to true
            isUsed = true;
            // play the heal sound
            soundsController.PlayHealUpSound();
            // destroy the healer
            Destroy(gameObject);
            
        }
    }

    // when the player enter the trigger collider of the healer
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        // if the player is colliding with the healer, heal the player
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is colliding with healer");
            isCollidingWithHealer = true;
        }
    }
}
