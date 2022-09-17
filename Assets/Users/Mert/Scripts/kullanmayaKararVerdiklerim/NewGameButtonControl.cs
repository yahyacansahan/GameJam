using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButtonControl : MonoBehaviour
{
    [SerializeField] MenuController menuCont;
    [SerializeField] int Button›ndex;
    [SerializeField] LoadingThings load;
    [SerializeField] Animator anim;
    [SerializeField] MenuButtonController buttonCont;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        if (menuCont.buttonIndex == Button›ndex && Input.GetAxis("Submit") == 1 || menuCont.buttonIndex == Button›ndex && Input.GetMouseButtonDown(0) && buttonCont.isCliced)
        {
            yield return new WaitForSeconds(0.6f);
            load.LoadNewObje();
            anim.SetBool("Selected", false);
        }
    }
}
