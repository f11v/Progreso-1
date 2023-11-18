using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyF : MonoBehaviour
{
    
    public float moveSpeed = 90.0f; // Velocidad de movimiento
    public float chaseDistance = 400.0f; // Distancia de persecución
    public float idleTime = 4.0f; // Tiempo en segundos para la rutina de reposo
    public Animator ani;
    public Transform myPlayer;
    public Quaternion targetRotation;
    public float degree;

    private float idleTimer;

    void Start()
    {
        ani = GetComponent<Animator>();
        GameObject playerObject = GameObject.Find("MyPlayer");

        if (playerObject != null)
        {
            myPlayer = playerObject.transform;
        }
        
    }

    public void Comportamiento_Enemigo()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, myPlayer.position);

        if (distanceToPlayer > chaseDistance)
        {
            // En reposo ("idle")
            ani.SetBool("run", false);

            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                // Iniciar nueva rutina de movimiento
                targetRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                idleTimer = 0;
            }

            // Rotar hacia la dirección objetivo
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 0.5f);
        }
        else
        {
           
            ani.SetBool("run", true);

            var lookPos = myPlayer.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
} 




