using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class playerMovementTouch : MonoBehaviour
{
	private CharacterController2D controller;
	private Rigidbody2D physicsBody = null;
    public Animator animator;


    public float moveSpeed = 40f;
    float horizontalMove = 0f;

    bool jump = false;

	public CharacterController2D Controller { get => controller; set => controller = value; }


	// Start is called before the first frame update
	void Start()
    {
        physicsBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }
    public void MoveUp()

	{
       // physicsBody.AddForce(Vector2.up * moveSpeed);
        physicsBody.velocity = new Vector2(physicsBody.velocity.x, moveSpeed);
    }
    public void MoveDown()

    {
        // physicsBody.AddForce(Vector2.down * moveSpeed);
        physicsBody.velocity = new Vector2(physicsBody.velocity.x, -moveSpeed);
    }
    public void MoveLeft()

    {
        //physicsBody.AddForce(Vector2.left * moveSpeed);
        physicsBody.velocity = new Vector2(-moveSpeed, physicsBody.velocity.y);
    }
    public void MoveRight()

    {
        //physicsBody.AddForce(Vector2.right * moveSpeed);
        physicsBody.velocity = new Vector2(moveSpeed, physicsBody.velocity.y);
    }

}
