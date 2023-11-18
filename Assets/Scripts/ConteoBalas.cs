using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConteoBalas : MonoBehaviour
{
    public TextMeshProUGUI textoConteo;
    public DisparoFirst jugador;

    private void Start()
    {
        
        ActualizarConteoBalas();
    }

    private void Update()
    {
        ActualizarConteoBalas();
    }

    private void ActualizarConteoBalas()
    {
        textoConteo.text = "Balas: " + jugador.disparosRestantes;
    }
}

