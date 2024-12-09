using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletLifetime = 5f; // Time before the bullet is destroyed automatically
    public static int zombieKillCount = 0; // Counter for zombie kills

    private void Start()
    {
        // Automatically destroy the bullet after its lifetime
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "background")
        {
            // Destroy the bullet when it collides with the background
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "background")
        {
            // Destroy the bullet when it enters the background trigger
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Zombie")
        {
            // Destroy the zombie
            Destroy(collision.gameObject);

            // Destroy the bullet
            Destroy(gameObject);

            // Increment the zombie kill counter
            zombieKillCount++;
            Debug.Log("Zombie killed! Total kills: " + zombieKillCount);
        }
    }
}
