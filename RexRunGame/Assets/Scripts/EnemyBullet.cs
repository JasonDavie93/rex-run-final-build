using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //Coded by Jason Davie
    
    public int damage = 15;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Finds enemy component
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            //Calls TakeDamage function from EnemyScript
            player.TakeDamage(damage);
        }
        //Destroys Projectile upon collision
        Destroy(gameObject);


    }
}
