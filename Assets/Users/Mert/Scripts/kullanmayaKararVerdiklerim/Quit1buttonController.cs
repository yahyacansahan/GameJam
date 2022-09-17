using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit1buttonController : MonoBehaviour
{
    [SerializeField] MenuController menuCont;
    [SerializeField] int Button›ndex;
    [SerializeField] Animator anim;
    void Update()
    {
        StartCoroutine(Quiting());
    }

    IEnumerator Quiting()
    {
        if (menuCont.buttonIndex == Button›ndex && Input.GetAxis("Submit") == 1 )
        {
            yield return new WaitForSeconds(0.6f);
            anim.SetBool("Selected", false);

            Application.Quit();
        }


    }
}
