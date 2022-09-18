using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    PlayerData playerData;
    LevelName levelName;

    // Start is called before the first frame update
    void Start()
    {
        levelName = GetComponent<LevelName>();
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();
        if (GameObject.FindWithTag("Player"))
        {
            Load();
            playerData.Level = levelName.LevelPos;
            Save();
        }
    }

    public void NewGame(int saveBox)
    {
        playerData.SaveBox = saveBox;
        playerData.CurrentDay = 1;
        playerData.Health = 100;
        playerData.Stamina = 100;
        playerData.Level = 1;
        playerData.Suphe = 0;
        playerData.FishingEvent = 0;
        playerData.CuttingEvent = 0;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("SaveBox", playerData.SaveBox);
        PlayerPrefs.SetInt("CurrentDay" + playerData.SaveBox, playerData.CurrentDay);
        PlayerPrefs.SetFloat("Health" + playerData.SaveBox, playerData.Health);
        PlayerPrefs.SetFloat("Stamina" + playerData.SaveBox, playerData.Stamina);
        PlayerPrefs.SetInt("Level" + playerData.SaveBox, playerData.Level);
        PlayerPrefs.SetFloat("Suphe" + playerData.SaveBox, playerData.Suphe);
        PlayerPrefs.SetInt("FishingEvent" + playerData.SaveBox, playerData.FishingEvent);
        PlayerPrefs.SetInt("CuttingEvent" + playerData.SaveBox, playerData.CuttingEvent);
    }

    public void Load()
    {
        //playerData.SaveBox = PlayerPrefs.GetInt("SaveBox");
        playerData.CurrentDay = PlayerPrefs.GetInt("CurrentDay" + playerData.SaveBox);
        playerData.Health = PlayerPrefs.GetFloat("Health" + playerData.SaveBox);
        playerData.Stamina = PlayerPrefs.GetFloat("Stamina" + playerData.SaveBox);
        playerData.Level = PlayerPrefs.GetInt("Level" + playerData.SaveBox);
        playerData.Suphe = PlayerPrefs.GetFloat("Suphe" + playerData.SaveBox);
        playerData.FishingEvent = PlayerPrefs.GetInt("FishingEvent" + playerData.SaveBox);
        playerData.CuttingEvent = PlayerPrefs.GetInt("CuttingEvent" + playerData.SaveBox);
    }
}
