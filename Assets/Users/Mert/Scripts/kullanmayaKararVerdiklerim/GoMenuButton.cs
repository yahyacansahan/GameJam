using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMenuButton : MonoBehaviour
{
    [SerializeField] MenuController menuCont;
    [SerializeField] int Buttonİndex;
    [SerializeField] Animator anim;
    [SerializeField] MenuButtonController buttonCont;
    void Update()
    {
        StartCoroutine(GoMenu());
    }

    IEnumerator GoMenu()
    {
        if (menuCont.buttonIndex == Buttonİndex && Input.GetAxis("Submit") == 1 || menuCont.buttonIndex == Buttonİndex && Input.GetMouseButtonDown(0) && buttonCont.isCliced)
        {
            yield return new WaitForSeconds(0.6f);
            anim.SetBool("Selected", false);
            SceneManager.LoadScene("MenuME01");
        }


    }
}
