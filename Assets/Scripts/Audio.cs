using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour {

    public AudioClip[] sceneMusic;
    public GameObject musicPlayer;
	// Use this for initialization
	void Start () {
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            CheckWin.cookGamePlayed = false;
            CheckWin.cutGamePlayed = false;
            Score.cutScore = 0;
            Score.cookScore = 0;
        }


        if (SceneManager.GetActiveScene().name == "CarrotCutting")
            this.gameObject.GetComponent<AudioSource>().clip = sceneMusic[1];
        else if (SceneManager.GetActiveScene().name == "PotStove")
            this.gameObject.GetComponent<AudioSource>().clip = sceneMusic[2];
        else if ((SceneManager.GetActiveScene().name == "StartMenu" || SceneManager.GetActiveScene().name == "GameChoose")
            && this.gameObject.GetComponent<AudioSource>().clip.name != sceneMusic[0].name)
            this.gameObject.GetComponent<AudioSource>().clip = sceneMusic[0];
        else if (SceneManager.GetActiveScene().name == "gameOver")
        {
            this.gameObject.GetComponent<AudioSource>().clip = sceneMusic[3];
            CheckWin.cookGamePlayed = false;
            CheckWin.cutGamePlayed = false;
            Score.cutScore = 0;
            Score.cookScore = 0;
        }
        else return;

        this.gameObject.GetComponent<AudioSource>().Play();
    }

    void Awake() {

        musicPlayer = GameObject.Find("MUSIC");

        if (musicPlayer == null)
        {
            musicPlayer = this.gameObject;
            musicPlayer.name = "MUSIC";
            DontDestroyOnLoad(musicPlayer);
        }
        else
        {
            if(this.gameObject.name != "MUSIC")
            {
                Destroy(this.gameObject);
            }
        }

        

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
