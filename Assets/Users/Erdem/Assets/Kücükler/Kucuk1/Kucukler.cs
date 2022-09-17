using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kucukler : MonoBehaviour
{
    [SerializeField] Animator Anime;
    [SerializeField] GameObject Soul;
    [SerializeField] GameObject İmage;
    public bool deadAlready = false;

    void Start()
    {
        Anime = GetComponent<Animator>();
        İmage.SetActive(false);
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
        if (deadAlready == false)
        {
            Instantiate(Soul, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            deadAlready = true;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Anime.SetBool("Hide",true);
            İmage.SetActive(true);
        }
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Anime.SetBool("Hide", false);
            İmage.SetActive(false);

        }

    }


}
