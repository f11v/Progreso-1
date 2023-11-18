using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 2; // Cantidad de daño que el enemigo causa al jugador
    public Transform playerTransform; // Transform del jugador

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform == playerTransform)
        {
            // Obtén una referencia al componente PlayerHealth del jugador
            PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();

            // Asegúrate de que el componente PlayerHealth esté presente en el jugador
            if (playerHealth != null)
            {
                // Aplica el daño al jugador
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}



