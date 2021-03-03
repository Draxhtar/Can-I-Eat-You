using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("Name of the Level that will be loaded when pressed PLAY.")]
    private string level1;

    public void PlayGame()
    {
        SceneManager.LoadScene(level1);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("QUIT");
    }
    

}
