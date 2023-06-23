using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderMovement : MonoBehaviour
{

    private float vertical; //Players input direction
    private float speed = 8f;//Players climb speed
    private bool isLadder; //Checks if player is next to ladder
    private bool isClimbing; //Checks if player is already climbinf ladder


	[SerializeField] private Rigidbody2D rb;

	//Update is called once per frame
	void Update()
	{
		// This method is empty in the provided code
		// Update is not being used for any specific functionality here
	}

	private void FixedUpdate()
	{
		
	
		if (isLadder && Mathf.Abs(vertical) > 0f)
		{
			isClimbing = true;// Player is next to a ladder and input is detected, set climbing flag to true
		}

		if (isClimbing)
		{
			rb.gravityScale = 0f;// Disable gravity for the player while climbing
			rb.velocity = new Vector2(rb.velocity.x, vertical * speed);// Set the vertical velocity of the player for climbing
		}
		else
		{
			rb.gravityScale = 1f;// Enable gravity for the player when not climbing
		}
		vertical = Input.GetAxis("Vertical"); // Get the vertical input axis value 
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("ladder"))
		{
			isLadder = true; // Player is in contact with a ladder
		}
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
	
		if (collision.CompareTag("ladder"))
		{
			isLadder= false;  // Player is no longer in contact with a ladder
			isClimbing = false; // Reset the climbing flag
		}

	}
	public void MoveUp()

	{
		Debug.Log("Move Up");
		// physicsBody.AddForce(Vector2.up * moveSpeed);
		vertical = 1;
	}
	public void MoveDown()

	{
		Debug.Log("Move Down");
		// physicsBody.AddForce(Vector2.down * moveSpeed);
		vertical = -1; //Set the vertical input to move down
	}
}
