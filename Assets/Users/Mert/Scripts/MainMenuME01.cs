using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuME01 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1ME");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT !!!");
        Application.Quit();
    }
}
