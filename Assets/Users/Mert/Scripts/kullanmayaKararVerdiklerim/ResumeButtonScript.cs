using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonScript : MonoBehaviour
{
    [SerializeField] MenuController menuCont;
    [SerializeField] int Button›ndex;
    [SerializeField] Animator anim;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] PauseMenu pauseResume;
    void Update()
    {
        StartCoroutine(Resuming());
    }

    IEnumerator Resuming()
    {
        if (menuCont.buttonIndex == Button›ndex && Input.GetAxis("Submit") == 1 )
        {
            yield return new WaitForSeconds(0.6f);
            anim.SetBool("Selected", false);
            //Time.timeScale = 1f;
            pauseResume.Resume();
            pauseMenu.SetActive(false);
        }


    }
}
