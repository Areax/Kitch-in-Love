using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public GameObject rr;
    public GameObject gameOver;

    bool escMenu = false;
    List<GameObject> objArray;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        objArray = new List<GameObject>();
        rr.SetActive(false);
        Debug.Log(rr);

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapePressed();
        }
    }


    void EscapePressed()
    {
        //Pause or unpause the game
        if (Time.timeScale == 0)
        {
            Resume();
        }
        else
        {
            Time.timeScale = 0;
            escMenu = true;
            rr.SetActive(escMenu);

        }
    }

    public void Resume()
    {
        escMenu = false;
        rr.SetActive(escMenu);
        Time.timeScale = 1;
    }

    public void playAgain()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

}