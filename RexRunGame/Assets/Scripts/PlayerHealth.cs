using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Coded by Jason Davie

    //Standard player health points
    public int currentHealth;
    public int maxHealth = 100;
    public int currentArmour;
    public int maxArmour = 125;
    public HealthBar healthBar1; // Reference to the health bar UI
    public ArmourBar armourBar;// Reference to the armour bar UI
    public float delay = 3f;
    public int respawnScene;
    public GameObject Player;
    public GameObject playerDeathEffect;
    

   

    public Image[] lives;// Array of UI images representing player lives
    public int livesRemaining;// Number of remaining lives
     
    // Explanation of livesRemaining:

    //4 lives - 4 images (0,1,2,3)
    //3 lives - 3 images (0,1,2,[3])
    //2 lives - 2 image (0,1,[2],[3])
    //1 life - 1 image (0,[1],[2],[3])
    // 0 lives - 0 images ([0,1,2,3] Lose

    private void Start()
    {
        livesRemaining = PlayerPrefs.GetInt("LivesRemaining", livesRemaining); // Load lives remaining from PlayerPrefs
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = (i < livesRemaining);// Enable or disable UI images based on remaining lives
        }
    }
    

    public void LoseLife()
    {
        livesRemaining--;
        UpdateLivesUI();

        if (livesRemaining == 0)
        {
            Debug.Log("You Lose");
            GameOver();
            
        }
        else
        {
            SaveLivesRemaining(); // Save updated lives remaining to PlayerPrefs
            RespawnScene();
        }
    }


    private void SaveLivesRemaining()
    {
        PlayerPrefs.SetInt("LivesRemaining", livesRemaining);
        PlayerPrefs.Save();
    }

    private void GameOver()
    {
        
        SceneManager.LoadScene(4);// Load game over scene
        Cursor.visible = true;
        PlayerPrefs.SetInt("LivesRemaining", 4);// Reset lives remaining to 4
        PlayerPrefs.Save();
    }

    public void RespawnScene()
    {
        respawnScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(respawnScene);// Reload the current scene

    }

    

    void Awake()
    {

        currentHealth = maxHealth;// Set initial health to maxHealth
        currentArmour = 0;// Set initial armour to 0
        healthBar1.SetMaxHealth(maxHealth);// Set the max value of the health ba
        armourBar.SetArmour(currentArmour);// Set the initial value of the armour bar
        livesRemaining = 4;// Set initial lives remaining to 4

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
            // Subtract damage from total armour
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
        
        RespawnScene();
        LoseLife();

        
    }

   

    
    

}

