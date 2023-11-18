using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PausarJuego : MonoBehaviour, IPointerClickHandler
{
    private bool juegoPausado = false;
    public TextMeshProUGUI textoBoton;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            CambiarEstadoPausa();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        CambiarEstadoPausa();
    }

    public void CambiarEstadoPausa()
    {
        juegoPausado = !juegoPausado;

        
        Time.timeScale = (juegoPausado) ? 0 : 1;

        
        if (textoBoton != null)
        {
            textoBoton.text = (juegoPausado) ? "Reanudar" : "Pausar";
        }
    }
}
