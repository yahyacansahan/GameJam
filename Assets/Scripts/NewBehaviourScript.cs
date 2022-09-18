using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{

    string gecisLevel = "";

    int Level = PlayerPrefs.GetInt("HangiLevel");

    void Start()
    {

        Level = PlayerPrefs.GetInt("HangiLevel");


    }

    // Update is called once per frame
    void Update()
    { 
        Debug.Log(Level);  
    }

    public void hangiLevel ()
    {
        if (Level == 1)
        {

            gecisLevel = "Level-1";

        }else if (Level == 2)
        {

            gecisLevel = "Level-2";
       
        }
        else if (Level == 3)
        {

            gecisLevel = "Level-3";

        }
        else if (Level == 4)
        {

            gecisLevel = "Level-4";

        }
        else if (Level == 5)
        {
            gecisLevel = "Level-5";


        }



        SceneManager.LoadScene(gecisLevel);



    }
}
