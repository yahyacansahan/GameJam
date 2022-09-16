using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGeçici : MonoBehaviour
{

    public string Hangisahne = "";
    // Start is called before the first frame update
    void Start()
    {

        Invoke("loadScene",2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadScene()
    {


        SceneManager.LoadScene(Hangisahne);
    }
}
