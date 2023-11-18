using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BVerde : MonoBehaviour
{
    public int score = 0;
    public int cantidad = 40;
    public int decrementoContador = 1;
    public AudioSource recoleccionSound;
    public Verde verde;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyPlayer"))
        {
            if(verde.ContadorVerde > 0)
            {
                verde.ContadorVerde--;
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
