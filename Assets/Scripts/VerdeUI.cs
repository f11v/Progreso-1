using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerdeUI : MonoBehaviour
{
    public TextMeshProUGUI verdeText; 
    public Verde verde;

    
    void Update()
    {
        // Actualiza el texto en la interfaz de usuario con el contador de botellas amarillas.
        verdeText.text = "Vidrio acumulado: " + verde.ContadorVerde;
    }
}
