using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DisparoD : MonoBehaviour
{
    public Transform laserOrigin;
    public float gunRange = 150f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
    public AudioSource disparoSound;

    LineRenderer laserLine;
    float fireTimer;

    public Transform myEnemy;
    public PlayerHealth playerHealth;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(myEnemy.position, playerHealth.transform.position);

        if (distanceToPlayer <= 200f)
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

                    if (hit.transform == playerHealth.transform)
                    {
                        playerHealth.TakeDamage(2);
                    }
                    disparoSound.Play();
                }
                else
                {
                    laserLine.SetPosition(1, laserOrigin.position + (myEnemy.forward * gunRange));
                    disparoSound.Play();
                }
                StartCoroutine(ShootLaser());
                // Reproducir el sonido de disparo
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





