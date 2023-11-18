using UnityEngine;
using TMPro;

public class MostrarCamaraEnBoton : MonoBehaviour
{
    public Camera mapaCamera;
    public TextMeshProUGUI textoMapa;

    private bool mapaVisible = false;

    void Start()
    {
        
        mapaCamera.gameObject.SetActive(false);
        
        textoMapa.text = "Mostrar Mapa";
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            AlternarVisibilidadMapa();
        }
    }

    public void AlternarVisibilidadMapa()
    {
        mapaVisible = !mapaVisible;

    
        mapaCamera.gameObject.SetActive(mapaVisible);
        textoMapa.text = mapaVisible ? "Ocultar Mapa" : "Mostrar Mapa";
    }
}


