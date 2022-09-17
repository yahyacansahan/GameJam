using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelSc : MonoBehaviour
{
    Animator Anime;
    void Start()
    {
        Anime = GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }

   public void Deadthh()
    {

        Anime.Play("Death");
        StartCoroutine(Bekle());

    }

    void EndOfLevel()
    {
        string kutuismi = PlayerPrefs.GetString("girisYapildi");
        PlayerPrefs.SetString(kutuismi, "Leve-2");

        SceneManager.LoadScene("GecisSahnesi");

    }

    IEnumerator Bekle()
    {
        yield return new WaitForSeconds(3f);
        EndOfLevel();
    }

}
