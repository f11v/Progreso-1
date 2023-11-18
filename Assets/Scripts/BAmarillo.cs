using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAmarillo : MonoBehaviour
{
    public int score = 0;
    public int cantidad = 20;
    public int decrementoContador = 1;
    public AudioSource recoleccionSound;

    public Amarillo amarillo; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyPlayer"))
        {
            if (amarillo.ContadorAmarillas > 0)
            {
                amarillo.ContadorAmarillas--;
                AumentarScore(cantidad);
                recoleccionSound.Play();
            }
        }
    }

    void AumentarScore(int cantidad)
    {
        // Aumenta el score.
        score += cantidad;
    }
}


