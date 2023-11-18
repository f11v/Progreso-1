using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;


public class ScoreLoader : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; 
    private string jsonFilePath = "Assets/Resources/Score.json"; // Ruta del archivo JSON

    [System.Serializable]
    public class Score
    {
        public string playerName;
        public string score;
    }

    [System.Serializable]
    public class ScoreList
    {
        public Score[] scorelist;
    }

    public ScoreList scorelist = new ScoreList();

    void Start()
    {
        LoadScoreFromJson(); // Carga el puntaje desde el archivo JSON
        UpdateText(); // Llama a la función para actualizar el TextMeshPro
    }

    void Update()
    {
        
    }

    void LoadScoreFromJson()
    {
        // Carga la lista actual de puntajes desde el archivo JSON
        scorelist = new ScoreList();

        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            scorelist = JsonUtility.FromJson<ScoreList>(json);
        }

    }

    void UpdateText()
    {
        // Crea una cadena para almacenar la información
        string displayText = "";

        // Itera a través de la lista de puntuaciones y construye la cadena
        foreach (var playerScore in scorelist.scorelist)
        {
            displayText += $"{playerScore.playerName}: {playerScore.score}\n";
        }

        // Asigna la cadena al componente TextMeshPro
        textMeshPro.text = displayText;
    }
}
