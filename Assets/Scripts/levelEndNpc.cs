using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEndNpc : MonoBehaviour
{
    [SerializeField] int level;
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void LevelEnd()
    {
        if (level == 6)
        {
            SceneManager.LoadScene("Finish");


        }
        else
        {
            PlayerPrefs.SetInt("HangiLevel", level);
            SceneManager.LoadScene("Köyleveli");
        }
      

    }
}
