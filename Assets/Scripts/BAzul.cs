using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAzul : MonoBehaviour
{
    public int score = 0;
    public int cantidad = 60;
    public int decrementoContador = 1;
    public AudioSource recoleccionSound;
    public Azul azul;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyPlayer"))
        {
            if(azul.ContadorAzul > 0)
            {
                azul.ContadorAzul--;
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
