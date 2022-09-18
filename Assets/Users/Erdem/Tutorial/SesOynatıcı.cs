using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesOynatıcı : MonoBehaviour
{
    AudioSource Source;
    [SerializeField] AudioClip Audio;
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
        if (collision.gameObject.tag == "player")
        {
            Source.PlayOneShot(Audio);
            Destroy(this.gameObject, 8f);

        }
    }

}
