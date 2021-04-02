using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject player;

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
        player.gameObject.SetActive(true);
        Cursor.visible = false;
    }
    public void PauseGame () {
        pauseMenu.SetActive (true);
        Time.timeScale = 0f;
        player.gameObject.SetActive(false);
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void quitgame () {
        Application.Quit ();
        Debug.Log ("Quit");
    }

    public void LoadMainMenu (string LoadMainMenu) {
        SceneManager.LoadScene ("MainMenu");
        Time.timeScale = 1f;
    }
    public void RestartScene (string SampleScene) {
        SceneManager.LoadScene ("SampleScene");
        Time.timeScale = 1f;
    }
}