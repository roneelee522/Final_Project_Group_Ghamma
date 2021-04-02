using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void quitgame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void LoadScene(string SampleScene)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
