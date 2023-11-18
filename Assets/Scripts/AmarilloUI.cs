using UnityEngine;
using TMPro;

public class AmarilloUI : MonoBehaviour
{
    public TextMeshProUGUI amarilloText; // Referencia al componente de texto en la interfaz de usuario.

    public Amarillo amarillo; // Referencia al script de recolección de botellas amarillas.

    void Update()
    {
        // Actualiza el texto en la interfaz de usuario con el contador de botellas amarillas.
        amarilloText.text = "Plastico acumulado: " + amarillo.ContadorAmarillas;
    }
}
