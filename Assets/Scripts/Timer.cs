using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Timer : MonoBehaviour
{
    public static float timer = 0f;
    public Text timerText;
    public Text highScoreText;
    public int highScore;
    bool gameOver;

    private string gameDataProjectFilePath = "/StreamingAssets/data.json";

    // Use this for initialization
    void Start()
    {
        timer = 120f;
        gameOver = false;


        string filePath = Application.dataPath + gameDataProjectFilePath;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            highScore = JsonUtility.FromJson<int>(dataAsJson);
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

            string dataAsJson = JsonUtility.ToJson(Score.score);

            string filePath = Application.dataPath + gameDataProjectFilePath;
            File.WriteAllText(filePath, dataAsJson);
        }
    }
}
