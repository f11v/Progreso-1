using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float healthIncreasePercentage = 10.0f; // 2% de aumento de salud
    public AudioSource recoleccionSound; // Campo para el sonido de recolección de vida

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
                    // Reproducir el sonido de recolección de vida
                    recoleccionSound.Play();

                    // Destruye el cubo una vez que se recolecta
                    Destroy(gameObject);
                }
            }
        }
    }
}

