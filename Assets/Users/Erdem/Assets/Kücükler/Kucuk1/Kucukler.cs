using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kucukler : MonoBehaviour
{
    [SerializeField] Animator Anime;
    [SerializeField] GameObject Soul;
    void Start()
    {
        Anime = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void Death()
    {

        Anime.Play("Death");
    }

    public void dstroy()
    {
        Instantiate(Soul, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Anime.SetBool("Hide",true);

        }
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Anime.SetBool("Hide", false);

        }

    }


}
