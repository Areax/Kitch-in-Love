using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public static GameObject rr;
    public static GameObject timesup;
    public GameObject pauseMenu;

    bool escMenu = false;

    // Use this for initialization
    void Start()
    {
        rr = GameObject.FindGameObjectWithTag("pause");
        timesup = GameObject.FindGameObjectWithTag("times");

        Time.timeScale = 1;
        rr.SetActive(false);
        timesup.SetActive(false);

    }

    void Awake()
    {

        pauseMenu = GameObject.Find("PAUSEMENU");

        if (pauseMenu == null)
        {
            pauseMenu = this.gameObject;
            pauseMenu.name = "PAUSEMENU";
            DontDestroyOnLoad(pauseMenu);
        }
        else
        {
            if (this.gameObject.name != "PAUSEMENU")
            {
                Destroy(this.gameObject);
            }
        }

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
        Time.timeScale = 1;
        escMenu = false;
        rr.SetActive(escMenu);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToChooseScreen()
    {
        timesup.SetActive(false);
        SceneManager.LoadScene("GameChoose");
    }

    public void GoToMain()
    {
        Time.timeScale = 1;
        escMenu = false;
        rr.SetActive(escMenu);
        timesup.SetActive(escMenu);
        SceneManager.LoadScene("StartMenu");
    }

}