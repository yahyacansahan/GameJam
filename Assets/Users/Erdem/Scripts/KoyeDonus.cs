using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KoyeDonus : MonoBehaviour
{

    [SerializeField] List<GameObject> Koylular;
    string Level,NextLevel;
    void Start()
    {
        Koylular.Add(GameObject.Find("Koylu1"));
        Koylular.Add(GameObject.Find("Koylu2"));
        Koylular.Add(GameObject.Find("Koylu3"));
        Koylular.Add(GameObject.Find("Koylu4"));
        Koylular.Add(GameObject.Find("Koylu5"));
        Koylular.Add(GameObject.Find("Koylu6"));
        
        
      Level=PlayerPrefs.GetString("girisYapildi");//kutu bulundu

        NextLevel = PlayerPrefs.GetString(Level);//level

        if (Level == "Level-2")
        {

            Koylular[0].SetActive(false);

        }else if(Level == "Level-3")
        {
            Koylular[0].SetActive(false);
            Koylular[1].SetActive(false);

        }
        else if (Level == "Level-4")
        {
            Koylular[0].SetActive(false);
            Koylular[1].SetActive(false);
            Koylular[2].SetActive(false);


        }
        else if (Level == "Level-5")
        {
            Koylular[0].SetActive(false);
            Koylular[1].SetActive(false);
            Koylular[2].SetActive(false);
            Koylular[3].SetActive(false);


        }
        if (Level == "level-6")
        {
          //  SceneManager.LoadScene("FinalScene");

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextlevel()
    {

        SceneManager.LoadScene(NextLevel);

    }
}
