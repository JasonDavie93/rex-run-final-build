using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupSmall : MonoBehaviour
{
    public int healthUp = 25; //Gives the player 25 health points
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            //If the player walks into the pickup, it will award the player 25 health up to a maximum of 100
            player.TakeHealth(healthUp);
            FindObjectOfType<AudioManager>().Play("healthPickUp");
            //Destroys Pick up upon collision
            Destroy(gameObject);
        }

      
    }
}
