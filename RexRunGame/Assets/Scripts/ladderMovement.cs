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

	}

	private void FixedUpdate()
	{
		if (isLadder && Mathf.Abs(vertical) > 0f)
		{
			isClimbing = true;
		}

		if (isClimbing)
		{
			rb.gravityScale = 0f;
			rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
		}
		else
		{
			rb.gravityScale = 1f;
		}
		vertical = Input.GetAxis("Vertical");
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("ladder"))
		{
			isLadder = true;
		}
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
	
		if (collision.CompareTag("ladder"))
		{
			isLadder= false;
			isClimbing = false;
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
		vertical = -1;
	}
}
