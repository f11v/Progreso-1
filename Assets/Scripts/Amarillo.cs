using UnityEngine;

public class Amarillo : MonoBehaviour
{
    public int ContadorAmarillas = 0; // Contador de botellas amarillas.
    public AudioSource recoleccionSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyPlayer"))
        {
            ContadorAmarillas++;
            recoleccionSound.Play();

            Destroy(gameObject);
        }
    }
}


