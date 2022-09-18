using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesOynatıcı : MonoBehaviour
{
    AudioSource Source;
    [SerializeField] AudioClip Audio;
    bool soundListened = false;
    void Start()
    {
        Source = GetComponent<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!soundListened)
            {
                Source.PlayOneShot(Audio);
                soundListened = true;
                Destroy(this.gameObject, 20f);
            }
          

        }
    }

}
