using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickUpSmall : MonoBehaviour
{
    public int armourUp = 25; //Gives the player 25 Armour points when player collides with pick up
    public Rigidbody2D rb;// Declare a public variable named "rb" of type Rigidbody2D
    // Start is called before the first frame update
    void Start()
    {

        // Get the Rigidbody2D component attached to the same GameObject and assign it to the "rb" variable
        rb = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D hitInfo)
    {

        // Attempt to get the PlayerHealth component attached to the collider that was hit and assign it to the "player" variable
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        // Check if the "player" variable is not null, indicating that the collider that was hit has a PlayerHealth component
        if (player != null)
        {
            //If the player walks into the pickup, it will award the player 25 armour up to a maximum of 125
            player.TakeArmour(armourUp);
            // Find an instance of the AudioManager script and call the Play method with the argument "armourPickUp" to play the corresponding audio
            FindObjectOfType<AudioManager>().Play("armourPickUp");
            //Destroys Pick up upon collision
            Destroy(gameObject);
        }
        
    }
}
