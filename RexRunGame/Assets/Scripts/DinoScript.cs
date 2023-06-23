using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoScript : MonoBehaviour
{
    //Coded by Jason Davie

    //Standard enemy health points
    public int health = 150;
    //public Animator animator;
    public GameObject Enemy;
    public GameObject deathEffect;
    //public GameObject deathEffect;
    //Function for damage
    public void TakeDamage(int damage)
    {
        //subtracts damage from total health 
        health -= damage;
        //If health reaches 0 
        if (health < 0)
        {
            //Carries out Die function
            Die();
        }
    }

    void Die()
    {
        //Plays death animation for enemy
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("dinoDeath");

        //Destroys the enemy sprite
        Destroy(gameObject);
    }

}
