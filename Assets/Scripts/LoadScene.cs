using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadScene : MonoBehaviour
{

    private bool toggleAudioOn = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadSceneSelect()
    {
        SceneManager.LoadScene("Story");
    }

    public void LoadCutGame()
    {
        if (CheckWin.cutGamePlayed)
            return;
        SceneManager.LoadScene("CarrotCutting");
        Time.timeScale = 1;
    }

    public void LoadStoveGame()
    {
        if(CheckWin.cookGamePlayed)
            return;
        SceneManager.LoadScene("PotStove");
        Time.timeScale = 1;
    }

    public void LoadGameChoose()
    {
        SceneManager.LoadScene("GameChoose");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void returnFromOptions()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("gameOver");
    }

    public void toggleAudio()
    {
        if (toggleAudioOn)
        {
            Debug.Log("Audio off");
            toggleAudioOn = !toggleAudioOn;
        }
        else
        {
            Debug.Log("Audio on");
            toggleAudioOn = !toggleAudioOn;
        }

    }

    public void QuitGame()
    {
        Debug.Log("<i>Quitting!</i>");
        Application.Quit();
    }

}