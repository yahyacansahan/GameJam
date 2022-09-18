using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour
{
    [SerializeField] MenuController menuCont;
    [SerializeField] int ButtonÝndex;
    [SerializeField] Animator anim;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        if (menuCont.buttonIndex == ButtonÝndex && Input.GetAxis("Submit") == 1)
        {
            yield return new WaitForSeconds(0.6f);
            SceneManager.LoadScene("Köyleveli");
        }
    }
}
