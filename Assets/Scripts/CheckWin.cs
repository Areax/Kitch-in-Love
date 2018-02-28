using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWin : MonoBehaviour {

    public static bool cutGamePlayed;
    public static bool cookGamePlayed;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(Score.cutScore + Score.cookScore >= 1600 && cutGamePlayed && cookGamePlayed && SceneManager.GetActiveScene().name != "gameOver")
        {
            SceneManager.LoadScene("Good Ending");
        }
        else if(cutGamePlayed && cookGamePlayed)
        {
            SceneManager.LoadScene("Bad Ending");
        }
	}
}
