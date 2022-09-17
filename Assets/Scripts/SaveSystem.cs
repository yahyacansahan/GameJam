using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();
    }

    public void NewGame()
    {
        playerData.CurrentDay = 1;
        playerData.Health = 100;
        playerData.Stamina = 100;
        playerData.Level = 1;
        playerData.Suphe = 0;
        Save();
    }

    public void Save()
    {

        PlayerPrefs.SetInt("CurrentDay" + playerData.SaveBox, playerData.CurrentDay);
        PlayerPrefs.SetFloat("Health" + playerData.SaveBox, playerData.Health);
        PlayerPrefs.SetFloat("Stamina" + playerData.SaveBox, playerData.Stamina);
        PlayerPrefs.SetInt("Level" + playerData.SaveBox, playerData.Level);
        PlayerPrefs.SetFloat("Suphe" + playerData.SaveBox, playerData.Suphe);
    }

    public void Load()
    {
        playerData.CurrentDay = PlayerPrefs.GetInt("CurrentDay" + playerData.SaveBox);
        playerData.Health = PlayerPrefs.GetFloat("Health" + playerData.SaveBox);
        playerData.Stamina = PlayerPrefs.GetFloat("Stamina" + playerData.SaveBox);
        playerData.Level = PlayerPrefs.GetInt("Level" + playerData.SaveBox);
        playerData.Suphe = PlayerPrefs.GetInt("Suphe" + playerData.SaveBox);
    }
}
