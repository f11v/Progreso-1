using UnityEngine;
using TMPro;  

public class Azul : MonoBehaviour
{
    public int ContadorAzul = 0; // Contador de botellas azules.
    public AudioSource recoleccionSound;
    public TextMeshProUGUI contadorText;  

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyPlayer"))
        {
            
            // Incrementa el contador de botellas azules.
            ContadorAzul++;
            
            // Reproduce el sonido de recolección.
            recoleccionSound.Play();

            // Actualiza el contador en el TextMeshProUGUI.
            if (contadorText != null)
            {
                contadorText.text = "Contador Azul: " + ContadorAzul.ToString();
            }

            Destroy(gameObject);
        }
    }
}

