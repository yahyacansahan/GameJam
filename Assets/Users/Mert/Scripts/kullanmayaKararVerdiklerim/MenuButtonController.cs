using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] int thisButtonIndex;
    [SerializeField] MenuController controlingMenu;
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (controlingMenu.buttonIndex == thisButtonIndex)
        {
            //se�ildi animasyonunu ba�lat�yor
            animator.SetBool("Selected", true);

            //�st�ne t�kland� animasyonunu ba�lat�yor
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("Entered", true);
            }
            else { animator.SetBool("Entered", false); }
        }
        else
        {
            animator.SetBool("Selected", false);
        }
    }
}
