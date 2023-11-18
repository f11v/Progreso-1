using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool canLoadScene = true; // Variable para controlar si se puede cargar la escena

    public void CargarEscena()
    {
        if (canLoadScene)
        {
            SceneManager.LoadScene("Juego"); // Carga la escena especificada
            canLoadScene = false; // Desactiva la carga de la escena temporalmente
        }
                Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResetLoadScene()
    {
        canLoadScene = true; // Permite volver a cargar la escena
    }
}