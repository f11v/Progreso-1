using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float healthIncreasePercentage = 2.0f; // 2% de aumento de salud

    public AudioSource recoleccionSound; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyPlayer")) 
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                int healthIncrease = Mathf.RoundToInt(playerHealth.maxHealth * (healthIncreasePercentage / 100.0f));
                int originalHealth = playerHealth.currentHealth;
                playerHealth.currentHealth += healthIncrease;

                
                if (playerHealth.currentHealth > playerHealth.maxHealth)
                {
                    playerHealth.currentHealth = playerHealth.maxHealth;
                }

                
                if (playerHealth.currentHealth > originalHealth)
                {
                    recoleccionSound.Play();
                    Destroy(gameObject);
                }

            }
        }
    }
}





