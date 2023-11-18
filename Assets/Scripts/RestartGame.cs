using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReiniciarJuego : MonoBehaviour
{
    public string nombreDeEscena = "Juego";
    public TextMeshProUGUI textoBoton;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarJuegoFunc();
        }
    }

    public void ReiniciarJuegoFunc()
    {
        
        SceneManager.LoadScene(nombreDeEscena);

        
        Time.timeScale = 1f;

    }
}


