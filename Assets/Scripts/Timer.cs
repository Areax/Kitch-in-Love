using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class HighScores
{
    public int carrotScore;
    public int potScore;
}


public class Timer : MonoBehaviour
{
    public static float timer = 0f;
    public Text timerText;
    public Text highScoreText;
    public int highScore;
    string dataAsJson;
    HighScores highScores;
    bool gameOver;
    bool playingPotGame;

    private string gameDataProjectFilePath = "/StreamingAssets/data.json";

    // Use this for initialization
    void Start()
    {
        timer = 60f;
        gameOver = false;


        string filePath = Application.dataPath + gameDataProjectFilePath;

        if (GameObject.FindGameObjectWithTag("therm") != null)
        {
            playingPotGame = true;
        }

        if (File.Exists(filePath))
        {
            dataAsJson = File.ReadAllText(filePath);
            highScores = JsonUtility.FromJson<HighScores>(dataAsJson);

            if (playingPotGame)
                highScore = highScores.potScore;
            else highScore = highScores.carrotScore;

        }
        else
        {
            highScore = 0;
        }

        highScoreText.text = "Highscore: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {

        if(Score.score > highScore)
        {
            highScore = Score.score;
            highScoreText.text = "Highscore: " + highScore; 
        }


        timerText.text = Mathf.Round(timer).ToString();
        timer -= Time.deltaTime;

        if(Mathf.Round(timer) <= 0 && !gameOver)
        {
            Time.timeScale = 0;
            gameOver = true;

            if (playingPotGame)
                highScores.potScore = highScore;
            else highScores.carrotScore = highScore;

            string dataAsJson = JsonUtility.ToJson(highScores);

            string filePath = Application.dataPath + gameDataProjectFilePath;
            File.WriteAllText(filePath, dataAsJson);
        }
    }
}
