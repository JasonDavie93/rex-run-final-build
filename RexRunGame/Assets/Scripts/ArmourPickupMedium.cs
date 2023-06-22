using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickupMedium : MonoBehaviour
{
    public int armourUp = 50; //Gives the player 50 Armour points
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
            //If the player walks into the pickup, it will award the player 50 armour up to a maximum of 125
            player.TakeArmour(armourUp);
            FindObjectOfType<AudioManager>().Play("armourPickUp");
            //Destroys Pick up upon collision
            Destroy(gameObject);
        }
       
    }
}
