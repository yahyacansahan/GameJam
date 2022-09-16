using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
    }

    public void NewGame()
    {
        playerData.CurrentDay = 1;
        playerData.Health = 100;
        playerData.Stamina = 100;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CurrentDay", playerData.CurrentDay);
        PlayerPrefs.SetFloat("Health", playerData.Health);
        PlayerPrefs.SetFloat("Stamina", playerData.Stamina);
    }

    public void Load()
    {
        playerData.CurrentDay = PlayerPrefs.GetInt("CurrentDay");
        playerData.Health = PlayerPrefs.GetFloat("Health");
        playerData.Stamina = PlayerPrefs.GetFloat("Stamina");
    }
}
