using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Coded by Jason Davie
    public Transform firepoint; //Where the projectile will spawn from
    public GameObject bulletPrefab; //projectile pre fab in project
    public Animator animator;
    public float bulletSpeed = 15f;

    public float fireRate = 0.2f;
    private float lastFireTime = 0f;

    public bool isShooting = false;

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetButtonDown("Fire"))
        {
            Shoot();
        }

    }

    
    void Shoot()
	{
        if (Time.time >= lastFireTime + fireRate)
        {
            lastFireTime = Time.time;
            animator.SetBool("isShooting", true);
            //Shooting Logic

            //Spawns bullet pre fab from fire point location at tip of players gun barrel
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            FindObjectOfType<AudioManager>().Play("gunShot");

        }
        else
		{
            animator.SetBool("isShooting", false);
		}

    }
}
