using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{

    public string sceneName;
    [SerializeField] int buttonIndex;
    [SerializeField] MenuController controller;
    [SerializeField] string hangikutu;
    string hangiSahne;

    string sahne;

    private void Start()
    {
        hangiSahne = PlayerPrefs.GetString(hangikutu);
    }


    void Update()
    {
        if(controller.buttonIndex == buttonIndex && Input.GetAxis("Submit") == 1 )
        {
            if (hangiSahne == "")
            {
                Debug.Log(PlayerPrefs.GetString(hangikutu) + "dene");
                PlayerPrefs.SetString(hangikutu, "Level-1");
            }
            StartCoroutine(GeciseHazirlan());
            PlayerPrefs.SetString("girisYapildi", hangikutu);
            SceneManager.LoadScene("GecisSahnesi");
        }
    }

    IEnumerator GeciseHazirlan()
    {
        yield return new WaitForSeconds(0.6f);
    }

    

}
