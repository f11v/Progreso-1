using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConteoAranas : MonoBehaviour
{
    public TextMeshProUGUI conteoText; 

    private int aranasEliminadas = 0;

    
    public void AranaEliminada()
    {
        aranasEliminadas++;
        ActualizarConteo();
    }

    // Actualiza el texto del conteo
    private void ActualizarConteo()
    {
        conteoText.text = "Arañas Eliminadas: " + aranasEliminadas;
    }
}

