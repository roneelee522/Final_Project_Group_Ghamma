using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject player;
    public AudioSource audioSource;
    public AudioSource pauseMusic;
    public AudioSource playerSource;


    void Start()
    {
    }   
     void Update () 
    {
        if (Input.GetKeyDown (KeyCode.P)) 
        {
            if (gamePaused) 
            {
                ResumeGame ();
            } else 
            {
                PauseGame ();
            }
        }
    }
    public void ResumeGame () {
        pauseMenu.SetActive (false);
        Time.timeScale = 1f;
        gamePaused = false;
        audioSource.Play();
        playerSource.Play();
        player.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMusic.Stop();
    }
    public void PauseGame () {
        pauseMenu.SetActive (true);
        Time.timeScale = 0f;
        player.gameObject.SetActive(false);
        gamePaused = true;
        audioSource.Pause();
        playerSource.Pause();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMusic.Play();
    }
    public void quitgame () {
        Application.Quit ();
        Debug.Log ("Quit");
    }

    public void LoadMainMenu (string LoadMainMenu) {
        SceneManager.LoadScene ("MainMenu");
        Time.timeScale = 1f;
    }
    public void RestartScene (int sceneIndex) {
        SceneManager.LoadScene (sceneIndex);
        Time.timeScale = 1f;
    }
}