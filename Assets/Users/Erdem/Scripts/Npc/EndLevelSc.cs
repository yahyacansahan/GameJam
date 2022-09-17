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

    }

    void EndOfLevel()
    {
       

    }

}
