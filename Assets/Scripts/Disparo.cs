using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Disparo : MonoBehaviour
{
    public Transform laserOrigin;
    public float gunRange = 150f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;

    public Transform myEnemy;
    public PlayerHealth playerHealth; // Referencia al script de la salud del jugador
    public AudioSource disparoSound; 

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(myEnemy.position, playerHealth.transform.position);

        if (distanceToPlayer <= 150f)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > fireRate)
            {
                fireTimer = 0;
                laserLine.SetPosition(0, laserOrigin.position);

                RaycastHit hit;
                if (Physics.Raycast(laserOrigin.position, (playerHealth.transform.position - myEnemy.position).normalized, out hit, gunRange))
                {
                    laserLine.SetPosition(1, hit.point);

                    if (hit.transform == playerHealth.transform) // Verifica si el rayo alcanza al jugador
                    {
                        // Simula el disparo del enemigo al jugador
                        playerHealth.TakeDamage(2); // Reducir la salud del jugador
                    }
                    disparoSound.Play();
                }
                else
                {
                    // Si el rayo no alcanza al jugador, dibuja una línea larga
                    laserLine.SetPosition(1, laserOrigin.position + (myEnemy.forward * gunRange));
                    disparoSound.Play();
                }
                StartCoroutine(ShootLaser());
                disparoSound.Play();
            }
        }
    }

    void FireAtPlayer()
    {
        
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
