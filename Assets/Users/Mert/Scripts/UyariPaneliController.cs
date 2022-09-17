using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UyariPaneliController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] MenuController menuCont;
    [SerializeField] int thisObjectIndex;
    [SerializeField] bool uyariAcikMi = false;
    bool basildi = false;

    private void Start()
    {
        SonrakiAnimasyon();
    }

    private void Update()
    {
        Debug.Log("varým");
        if (menuCont.buttonIndex == thisObjectIndex && Input.GetAxis("Submit") == 1)
        {
            if (!basildi)
            {
                if (!uyariAcikMi)
                {
                    UyariyiAc();
                    uyariAcikMi = true;
                }
                else
                {

                    UyariyiKapa();
                    uyariAcikMi = false;
                }
            }
            basildi = true;
        }
        else
        {
            basildi = false;
        }
    }

    public void UyariyiAc()
    {
        anim.SetBool("Acildi", true);
    }

    public void UyariyiKapa()
    {
        anim.SetBool("Acildi", false);
    }

    public void SonrakiAnimasyon()
    {
        StartCoroutine(acilisdakiAnimBekle());
    }

    IEnumerator acilisdakiAnimBekle()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("Acildi", false);
    }

}
