using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score = 0;
    public static int cutScore = 0;
    public static int cookScore = 0;
    public string scoreType = "";
    public Text scoreText;

    // Use this for initialization
    void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(scoreType == "")
            scoreText.text = "Score: " + score;
        else if(scoreType == "cut")
        {
            scoreText.text = "Score: " + cutScore;
        }
        else if(scoreType == "cook")
        {
            scoreText.text = "Score: " + cookScore;
        }
        else if (scoreType == "total")
        {
            int total = cookScore + cutScore;
            scoreText.text = total.ToString();
        }

    }
}
