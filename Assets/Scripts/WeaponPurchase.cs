using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI components

public class WeaponPurchaseTrigger : MonoBehaviour
{
    public Text dialogText; // Text component for the message
    public int weaponCost = 100; // Cost of the weapon
    private bool playerInRange = false;

    private void Start()
    {
        if (dialogText != null)
        {
            dialogText.text = ""; // Clear the dialog text
        }
    }
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered trigger zone");
            if (dialogText != null)
            {
                dialogText.text = $"Press F to purchase weapon for {weaponCost} coins";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Hide dialog when the player leaves the gun's hitbox
        if (other.CompareTag("Player"))
        {    
            dialogText.text = "";
            
        }
    }
    
  

    private void Update()
    {
        // Check if the player is in range and presses F
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            AttemptPurchase();
        }
    }

    private void AttemptPurchase()
    {
        // Check if the player has enough coins
        if (Inventory.coins >= weaponCost) // Replace with your player's coin management logic
        {
            Inventory.coins -= weaponCost; // Deduct coins
            Debug.Log("Weapon purchased!");
            // Add logic to give the weapon to the player
        }
        else
        {
            Debug.Log("Not enough coins!");
        }

        // Clear the dialog text and reset range state
        if (dialogText != null)
        {
            dialogText.text = "";
        }

        playerInRange = false;
    }
}
