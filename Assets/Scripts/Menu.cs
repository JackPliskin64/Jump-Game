using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
    public void playGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
