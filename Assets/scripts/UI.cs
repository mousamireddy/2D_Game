using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("egg level1");
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene("startpanel");
    }
   
}
