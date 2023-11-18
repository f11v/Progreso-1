using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScoreManagerUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI mensajeText; 
    public BAmarillo bamarillo;
    public BVerde bverde;
    public BAzul bazul;
    private int score = 0;
    private float tiempoTranscurrido = 0f;

    private string jsonFilePath = "Assets/Resources/Score.json";

    void Update()
    {
        // Actualiza el puntaje
        score = bamarillo.score + bverde.score + bazul.score;
        scoreText.text = "Score: " + score;

        // Muestra un mensaje y cambia de escena cuando el puntaje llega a 120 
        if (score >= 120)
        {
            mensajeText.text = "Ganaste!";
            tiempoTranscurrido += Time.deltaTime;

            // Si han pasado 10 segundos, cambia a la escena de inicio
            if (tiempoTranscurrido >= 10f)
            {
                CambiarAEscenaInicio();
            }
        }
        else
        {
            // Reinicia el tiempo transcurrido si el puntaje es menor a 120
            tiempoTranscurrido = 0f;
            mensajeText.text = ""; // Limpiar el mensaje si el puntaje es menor a 120
        }

        // Guarda el puntaje en un archivo JSON solo si es uno de los 5 mejores puntajes
        if (IsHighScore(score))
        {
            SaveScoreToJson();
        }
    }

    bool IsHighScore(int newScore)
    {
        // Carga la lista actual de puntajes desde el archivo JSON
        var scoreList = LoadScoreFromJson();

        // Verifica si el nuevo puntaje es mayor que alguno de los puntajes existentes
        return scoreList.scorelist.Any(s => int.Parse(s.score) < newScore);
    }

    void SaveScoreToJson()
    {
        // Carga la lista actual de puntajes desde el archivo JSON
        ScoreLoader.ScoreList scoreList = LoadScoreFromJson();

        // Agrega el nuevo puntaje a la lista
        List<ScoreLoader.Score> tempList = scoreList.scorelist.ToList();
        tempList.Add(new ScoreLoader.Score
        {
            playerName = "Player", 
            score = score.ToString()
        });

        // Ordena la lista de puntajes de mayor a menor
        tempList = tempList.OrderByDescending(s => int.Parse(s.score)).ToList();

        // Limita la lista a los primeros 5 puntajes
        tempList = tempList.Take(5).ToList();

        // Asigna la lista ordenada y limitada de nuevo al array
        scoreList.scorelist = tempList.ToArray();

        // Convierte la instancia a JSON y guarda en el archivo
        string json = JsonUtility.ToJson(scoreList);
        File.WriteAllText(jsonFilePath, json);
    }

    ScoreLoader.ScoreList LoadScoreFromJson()
    {
        // Carga la lista actual de puntajes desde el archivo JSON
        ScoreLoader.ScoreList scoreList = new ScoreLoader.ScoreList();

        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            scoreList = JsonUtility.FromJson<ScoreLoader.ScoreList>(json);
        }

        return scoreList;
    }

    void CambiarAEscenaInicio()
    {
        // Cambia a la escena de inicio
        SceneManager.LoadScene("Inicio");
    }
}
