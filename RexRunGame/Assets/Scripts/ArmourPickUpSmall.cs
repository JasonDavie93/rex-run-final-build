using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickUpSmall : MonoBehaviour
{
    public int armourUp = 25; //Gives the player 25 armour
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //If the player walks into the pickup, it will award the player 25 armour up to a maximum of 125
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            //Calls TakeArmour function from PlayerHealth Script
            player.TakeArmour(armourUp);
            FindObjectOfType<AudioManager>().Play("armourPickUp");
            //Destroys Pick up upon collision
            Destroy(gameObject);
        }
        
    }
}
