using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConteoEnemigos : MonoBehaviour
{    
    public TextMeshProUGUI enemigosText; 

    private int enemigosEliminados = 0; 

    public void EnemigoEliminado()
    {
        enemigosEliminados++;
        ActualizarConteo();
    }

    // Actualiza el texto del conteo
    private void ActualizarConteo()
    {
        enemigosText.text = "Enemigos Eliminados: " + enemigosEliminados; 
    }
}

