using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{
    PlayerData playerData;
    public SaveSystem system;
    public string sceneName;
    [SerializeField] int buttonIndex;
    [SerializeField] MenuController controller;
    [SerializeField] string hangikutu;
    string hangiSahne;

    string sahne;

    private void Start()
    {
        //hangiSahne = PlayerPrefs.GetString(hangikutu);

        
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();
    }


    void Update()
    {
        if(controller.buttonIndex == buttonIndex && Input.GetAxis("Submit") == 1 )
        {

            if (PlayerPrefs.GetInt("CurrentDay" + buttonIndex) == null)
            {
                system.NewGame(buttonIndex);
            }
            else
            {
                playerData.SaveBox = buttonIndex;
                system.Save();
                system.Load();
            }

            StartCoroutine(GeciseHazirlan());
        }
    }

    IEnumerator GeciseHazirlan()
    {
        yield return new WaitForSeconds(0.6f);

        SceneManager.LoadScene("GecisSahnesi");
    }

    

}
