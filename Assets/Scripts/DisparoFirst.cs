using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DisparoFirst : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 1000f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    public int disparosRestantes = 10;
    bool municionRecogida = false;

    ConteoEnemigos conteoEnemigos;
    ConteoAranas conteoAranas;

    public AudioSource disparoSound; 

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        conteoEnemigos = FindObjectOfType<ConteoEnemigos>();
        conteoAranas = FindObjectOfType<ConteoAranas>();
    }

    void Update()
    {
        
        if (disparosRestantes > 0 && Input.GetButtonDown("Fire1") )
        {
            disparosRestantes--;
            // Reproducir el sonido de disparo
            disparoSound.Play();

            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);

                if (hit.transform.CompareTag("A"))
                {
                    Destroy(hit.transform.gameObject);
                    conteoEnemigos.EnemigoEliminado();
                }
                else if (hit.transform.CompareTag("B"))
                {
                    Destroy(hit.transform.gameObject);
                    conteoAranas.AranaEliminada();
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }

    public void AgregarMunicion(int cantidad)
    {
        if (!municionRecogida)
        {
            municionRecogida = true;
        }
        disparosRestantes += cantidad;
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}

