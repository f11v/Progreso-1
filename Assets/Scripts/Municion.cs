using UnityEngine;

public class Municion : MonoBehaviour
{
    public int cantidadMunicion = 10;
    private bool recogida = false;

    public AudioSource recoleccionSound; 

    private void OnTriggerEnter(Collider other)
    {
        if (!recogida && other.CompareTag("MyPlayer"))
        {
            DisparoFirst player = other.GetComponent<DisparoFirst>();
            if (player != null)
            {
                player.AgregarMunicion(cantidadMunicion);
                recogida = true;
                
                // Reproducir el sonido de recolección
                recoleccionSound.Play();
            }

            Destroy(gameObject);
        }
    }
}






