using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AzulUI : MonoBehaviour
{
    public TextMeshProUGUI azulText; 
    public Azul azul;

    
    void Update()
    {
        // Actualiza el texto en la interfaz de usuario con el contador de botellas amarillas.
        azulText.text = "Papel acumulado: " + azul.ContadorAzul;
    }
}
