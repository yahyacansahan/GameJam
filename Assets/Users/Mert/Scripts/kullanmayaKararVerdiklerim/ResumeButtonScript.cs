using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonScript : MonoBehaviour
{
    [SerializeField] MenuController menuCont;
    [SerializeField] int Buttonİndex;
    [SerializeField] Animator anim;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] PauseMenu pauseResume;
    [SerializeField] MenuButtonController buttonCont;
    void Update()
    {
        StartCoroutine(Resuming());
    }

    IEnumerator Resuming()
    {
        if (menuCont.buttonIndex == Buttonİndex && Input.GetAxis("Submit") == 1 || menuCont.buttonIndex == Buttonİndex && Input.GetMouseButtonDown(0) && buttonCont.isCliced)
        {
            yield return new WaitForSeconds(0.6f);
            anim.SetBool("Selected", false);
            //Time.timeScale = 1f;
            pauseResume.Resume();
            pauseMenu.SetActive(false);
        }


    }
}
