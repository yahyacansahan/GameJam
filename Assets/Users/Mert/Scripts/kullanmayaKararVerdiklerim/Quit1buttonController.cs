using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit1buttonController : MonoBehaviour
{
    [SerializeField] MenuController menuCont;
    [SerializeField] int Buttonİndex;
    [SerializeField] Animator anim;
    [SerializeField] MenuButtonController buttonCont;
    void Update()
    {
        StartCoroutine(Quiting());
    }

    IEnumerator Quiting()
    {
        if (menuCont.buttonIndex == Buttonİndex && Input.GetAxis("Submit") == 1 || menuCont.buttonIndex == Buttonİndex && Input.GetMouseButtonDown(0) && buttonCont.isCliced)
        {
            yield return new WaitForSeconds(0.6f);
            anim.SetBool("Selected", false);

            Application.Quit();
        }


    }
}
