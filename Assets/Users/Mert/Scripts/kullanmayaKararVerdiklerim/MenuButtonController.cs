using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] int thisButtonIndex;
    [SerializeField] MenuController controlingMenu;
    [SerializeField] Animator animator;
    [SerializeField] ChangeButton change;
    public bool isCliced = false;

    // Update is called once per frame
    void Update()
    {
        if (controlingMenu.buttonIndex == thisButtonIndex)
        {
            
            //seçildi animasyonunu baþlatýyor
            animator.SetBool("Selected", true);
            
            
            //üstüne týklandý animasyonunu baþlatýyor
            Enterlandi();
            
            
        }
        else
        {
            animator.SetBool("Selected", false);
            isCliced = false;
        }
    }

    public void Enterlandi()
    {
        //üstüne týklandý animasyonunu baþlatýyor
        if (Input.GetAxis("Submit") == 1 || Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Entered", true);
        }
        else { animator.SetBool("Entered", false); }
    }

    
}
