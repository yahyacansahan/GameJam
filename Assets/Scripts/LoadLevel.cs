using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    PlayerData playerData;
    SaveSystem saveSystem;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();
        saveSystem = GameObject.Find("SaveSystem").GetComponent<SaveSystem>();
        saveSystem.Load();
    }


    void LoadScene()
    {
        saveSystem.Load();
        SceneManager.LoadScene("Level-" + playerData.Level);
    }
}
