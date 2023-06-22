using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Coded by Jason Davie
    public float speed = 20f; //bullet speed
    public int damage = 15;
    public Rigidbody2D rb; // bullet RigidBody

    // Start is called before the first frame update
    void Start()
    {
        //Allows the bullet to travel from left to right dependant on speed
        rb.velocity = transform.right * speed;   
    }

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
        //Finds enemy component
        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
        if (enemy != null)
		{
            //Calls TakeDamage function from EnemyScript
            enemy.TakeDamage(damage);
            //Destroys Projectile upon collision
            Destroy(gameObject);
        }
        


	}

}
