using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{

    public string sceneName;
    [SerializeField] int buttonIndex;
    [SerializeField] MenuController controller;


    void Update()
    {
        if(controller.buttonIndex == buttonIndex && Input.GetAxis("Submit") == 1 )
        {
            StartCoroutine(GeciseHazirlan());
            SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator GeciseHazirlan()
    {
        yield return new WaitForSeconds(0.6f);
    }

}
