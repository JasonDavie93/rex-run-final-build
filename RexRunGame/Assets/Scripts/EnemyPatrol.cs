using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    

    public bool mustPatrol; //controls patrolling
    public Rigidbody2D rb; //Rigid Body for Enemy

    public Transform firepoint; //Where the projectile will spawn from
    public GameObject bulletPrefab; //projectile pre fab in project

    public Transform groundCheckPos; //Ground check reference
    public Transform playerCheckPos; //Player Check Reference
    public float walkSpeed; //enemy walk speed
    private bool mustTurn; //Decides if sprite should be flipped
    private bool mustShoot; //Decides if sprite should shoot
    public LayerMask groundLayer; //Ground layer reference
    public LayerMask playerLayer; //Player Layer Reference
    public Animator animator;
    public Collider2D bodyCollider;
    public float bulletSpeed = 15f;

    public float fireRate = 0.2f;
    private float lastFireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true; //Sets Patrol to true
        mustShoot = false; //Sets shoot to false
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
		{
            Patrol(); //Calls patrol function
            
        }

        if (mustShoot)
		{
            Shoot(); //Calls shoot function
		}
    }
	private void FixedUpdate()
	{
        //If circle contains ground, returns true
        if (mustPatrol)

        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
            mustShoot = Physics2D.OverlapCircle(playerCheckPos.position, 0.1f, playerLayer);
        }
	}
	void Patrol()
	{
        //will call the flip function the overlap circle 
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
		{
            Flip();
		}
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("enemySpeed", Mathf.Abs(walkSpeed));
      
    }

    void Flip()
	{
        //Flips the enemy sprite when reached the end of a platform
        mustPatrol = false; //Stops the enemy from patrolling
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); //Flips the enemy sprite
        walkSpeed *= -1; //Allows enemy to maintain walking speed in opposite direction
        mustPatrol = true; //Allows enemy to continue patrolling after flipping
	}

    void Shoot()
	{
        if (Time.time >= lastFireTime + fireRate)
        {
            lastFireTime = Time.time;
            mustPatrol = false;
            //Shooting Logic
            animator.SetBool("isShooting", true);
            //Spawns bullet pre fab from fire point location at tip of players gun barrel
            GameObject newBullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            FindObjectOfType<AudioManager>().Play("gunFire");
            
            //Sets enemy default direction to right
            Vector2 direction = Vector2.right;
           
            //Allows the enemy to fire in the correct direction they are facing
            if (transform.localScale.x < 0)
            {
                direction = Vector2.left;
            }
            newBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            
            //If the overlap circle doesn't detect the player layer, the enemy will return to their patrol animation and behaviour
            if (!Physics2D.OverlapCircle(playerCheckPos.position, 0.1f, playerLayer))
            {
                mustPatrol = true;
                animator.SetBool("isShooting", false);
                animator.SetFloat("enemySpeed", Mathf.Abs(walkSpeed));
            }
        }
    }

   
}

