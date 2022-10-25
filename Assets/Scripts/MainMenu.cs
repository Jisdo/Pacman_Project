using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Pacman closed");

    }
    
    public void StartGame()
    {
        Debug.Log("Pacman closed");
        SceneManager.LoadScene("Pacman");
    }

}
