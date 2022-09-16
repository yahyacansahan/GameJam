using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;

    public static bool GameIsPaused = false;
    [SerializeField] MainTimeControl timeControl;
    [SerializeField] int whichTime;
    [SerializeField] Rigidbody2D playerRB;
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
        timeControl.times[whichTime] = 1;
        playerRB.simulated = true;
        anim.SetBool("Selected", false);
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        //Time.timeScale = 0f;
        timeControl.times[whichTime] = 0;
        StartCoroutine(waitASec());
        playerRB.simulated = false;
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
