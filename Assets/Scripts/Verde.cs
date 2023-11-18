using UnityEngine;

public class Verde : MonoBehaviour
{
    public int ContadorVerde = 0; // Contador de botellas verdes.
    public AudioSource recoleccionSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyPlayer"))
        {
            
            
            // Incrementa el contador de botellas verdes.
            ContadorVerde++;
            recoleccionSound.Play();

            Destroy(gameObject);
        }
    }
}

