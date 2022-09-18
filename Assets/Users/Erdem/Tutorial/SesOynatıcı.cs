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
        Source.PlayOneShot(Audio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
