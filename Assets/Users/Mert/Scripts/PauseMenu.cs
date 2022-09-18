using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;

    public static bool GameIsPaused = false;
    [SerializeField] int whichTime;
    [SerializeField] Animator anim;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Time.timeScale = 1f;
        anim.SetBool("Selected", false);
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0.5f;
        StartCoroutine(waitASec());
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuME01");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator waitASec()
    {
        yield return new WaitForSeconds(0.6f);
    }
}
