using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelSc : MonoBehaviour
{
    Animator Anime;
    SaveSystem saveSystem;
    PlayerData playerData;
    public string hangiLevel;
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
        Anime.Play("Death");
        StartCoroutine(Bekle());
    }

    void EndOfLevel()
    {
        playerData.CurrentDay++;
        playerData.Level++;
        playerData.Suphe += (playerData.CurrentDay / 5) * 30;
        playerData.CuttingEvent = 0;
        playerData.FishingEvent = 0;
        saveSystem.Save();
        SceneManager.LoadScene("Köyleveli");
    }

    IEnumerator Bekle()
    {
        yield return new WaitForSeconds(3f);
        EndOfLevel();
    }

}
