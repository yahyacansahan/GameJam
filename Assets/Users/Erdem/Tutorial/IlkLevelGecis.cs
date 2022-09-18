using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IlkLevelGecis : MonoBehaviour
{
    public string ilk_Level = "";
    void Start()
    {
        SceneManager.LoadScene(ilk_Level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
