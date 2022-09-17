using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    [SerializeField] MenuController menuCont;
    [SerializeField] MenuButtonController buttonCont;
    public int thisButtonIndex;


    public void ChangingButton()
    {
        menuCont.buttonIndex = thisButtonIndex;
        buttonCont.isCliced = true;
        StartCoroutine(Bekle());
        //buttonCont.Enterlandi();
    }
    IEnumerator Bekle()
    {
        yield return new WaitForSeconds(0.7f);
        buttonCont.isCliced = false;
    }
}
