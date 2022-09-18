using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelSc : MonoBehaviour
{
    Animator Anime;
    SaveSystem saveSystem;
    PlayerData playerData;
    void Start()
    {
        Anime = GetComponent<Animator>();
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();
        saveSystem = GameObject.Find("SaveSystem").GetComponent<SaveSystem>();
        saveSystem.Load();
    }


    void Update()
    {

    }

    public void Deadthh()
    {
        //Anime.Play("Death");
        StartCoroutine(Bekle());
    }

    void EndOfLevel()
    {
        playerData.CurrentDay = playerData.CurrentDay + 1;
        playerData.Level++;
        playerData.Suphe += playerData.CurrentDay  * 15;
        playerData.CuttingEvent = 0;
        playerData.FishingEvent = 0;
        saveSystem.Save();
        SceneManager.LoadScene("K�yleveli");
    }

    IEnumerator Bekle()
    {
        yield return new WaitForSeconds(3f);
        EndOfLevel();
    }

}
