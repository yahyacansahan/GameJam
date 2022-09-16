using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] int thisButtonİndex;
    [SerializeField] MenuController controlingMenu;
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (controlingMenu.buttonIndex == thisButtonİndex)
        {
            animator.SetBool("Selected", true);
        }
        else
        {
            animator.SetBool("Selected", false);
        }
    }
}
