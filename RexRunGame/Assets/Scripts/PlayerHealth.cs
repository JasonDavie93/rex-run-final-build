using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Coded by Jason Davie

    //Standard player health points
    public int currentHealth;
    public int maxHealth = 100;
   
    public int currentArmour;
    public int maxArmour = 125;

    public HealthBar healthBar1;
    public ArmourBar armourBar;




    public float delay = 3f;
    public int respawnScene;
    public GameObject Player;
    public GameObject playerDeathEffect;

   
    void Awake()
	{
		
        currentHealth = maxHealth;
        currentArmour = 0;

        healthBar1.SetMaxHealth(maxHealth);
        armourBar.SetArmour(currentArmour);
    }
	//Function for damage
	public void TakeDamage(int damage)
    {
        if (currentArmour <= 0)
        {//subtracts damage from total health 
            currentHealth -= damage;
            healthBar1.SetHealth(currentHealth);
        }
        
        if (currentArmour >0)
		{
            currentArmour -= damage;
            armourBar.SetArmour(currentArmour);
        }
        
        //If health reaches 0 
        if (currentHealth < 0)
        {
            healthBar1.SetHealth(currentHealth);
            //Carries out Die function
            Die();
        }

        //healthBar1.SetHealth(health);
    }

    public void TakeHealth(int healthUp)
    {
        //adds health to total health 
        currentHealth += healthUp;
        healthBar1.SetHealth(currentHealth);
        //If health is 100 
        if (currentHealth >= 100)
        {
            //Caps max health at 100
            currentHealth = 100;
            healthBar1.SetHealth(currentHealth);
        }
    }

    public void TakeArmour(int armourUp)
    {
        //adds armour to total armour 
        currentArmour += armourUp;
        armourBar.SetArmour(currentArmour);
        //If armour is 125 
        if (currentArmour >= 125)
        {
            //Caps max armour at 125
            currentArmour = 125;
            armourBar.SetArmour(currentArmour);
        }
    }

    void Die()
    {
        
        //Plays death animation for enemy
        Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("playerDeath");
        //Destroys the enemy sprite
        Destroy(gameObject);
        StartCoroutine(RespawnSceneRoutine());
        

        
    }

    IEnumerator RespawnSceneRoutine()
	{
        yield return new WaitForSeconds(delay);
        RespawnScene();
	}
    public void RespawnScene()
	{
        respawnScene = SceneManager.GetActiveScene().buildIndex;
    }
}

