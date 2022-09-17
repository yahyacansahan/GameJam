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
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        saveSystem = GameObject.Find("Player").GetComponent<SaveSystem>();
        saveSystem.Load();
    }

    void LoadScene()
    {
        saveSystem.Load();
        SceneManager.LoadScene("Level-" + playerData.Level);
    }
}
