using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DinoPatrolScript : MonoBehaviour
{


    public bool mustPatrol; //controls patrolling
    public Rigidbody2D rb; //Rigid Body for Enemy
    public Transform attackPoint; //Where the projectile will spawn from
    public GameObject attackPrefab; //projectile pre fab in project
    public Transform groundCheckPos; //Ground check reference
    public Transform playerCheckPos; //Player Check Reference
    public float walkSpeed; //enemy walk speed
    private bool mustTurn; //Decides if sprite should be flipped
    private bool mustAttack; //Decides if sprite should shoot
    public LayerMask groundLayer; //Ground layer reference
    public LayerMask playerLayer; //Player Layer Reference
    public LayerMask enemyLayer;//Enemy Layer Reference
    public Animator animator;
    public Collider2D bodyCollider;
    public float attackSpeed = 50f;

    public float attackRate = 0.5f;
    private float lastAttackTime = 0f;



    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true; //Sets Patrol to true
        mustAttack = false; //Sets attack to false
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol(); //Calls patrol function

        }

        if (mustAttack)
        {
            Attack(); //Calls attack function
        }
    }
    private void FixedUpdate()
    {
        //If circle contains ground, returns true
        if (mustPatrol)

        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
            mustAttack = Physics2D.OverlapCircle(playerCheckPos.position, 0.1f, playerLayer);
        }
    }
    void Patrol()
    {
        //will call the flip function the overlap circle 
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer) || bodyCollider.IsTouchingLayers(enemyLayer))
        
        {
            Flip(); //Calls flip function
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(walkSpeed));

    }

    void Flip()
    {
        //Flips the enemy sprite when reached the end of a platform
        mustPatrol = false; //Stops the enemy from patrolling
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); //Flips the enemy sprite
        walkSpeed *= -1; //Allows enemy to maintain walking speed in opposite direction
        mustPatrol = true; //Allows enemy to continue patrolling after flipping
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackRate)
        {
            lastAttackTime = Time.time;
            mustPatrol = false;
            //Shooting Logic
            animator.SetBool("isAttacking", true);
            //Spawns bullet pre fab from fire point location at tip of players gun barrel
            GameObject newBullet = Instantiate(attackPrefab, attackPoint.position, attackPoint.rotation);
            FindObjectOfType<AudioManager>().Play("dinoBite");

            //Sets enemy default direction to right
            Vector2 direction = Vector2.right;

            //Allows the enemy to fire in the correct direction they are facing
            if (transform.localScale.x < 0)
            {
                direction = Vector2.left;
            }
            newBullet.GetComponent<Rigidbody2D>().velocity = direction * attackSpeed;


            //If the overlap circle doesn't detect the player layer, the enemy will return to their patrol animation and behaviour
            if (!Physics2D.OverlapCircle(playerCheckPos.position, 0.1f, playerLayer))
            {
                mustPatrol = true;
                animator.SetBool("isAttacking", false);
                animator.SetFloat("speed", Mathf.Abs(walkSpeed));
            }
        }
    }



}