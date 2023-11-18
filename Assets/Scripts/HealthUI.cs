using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TextMeshProUGUI healthText;

    void Update()
    {
        // Actualizar el texto de la vida 
        healthText.text = "Vida del personaje:    " + playerHealth.currentHealth + " / " + playerHealth.maxHealth;
    }
}

