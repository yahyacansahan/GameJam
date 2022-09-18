using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesTakibi : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip clipSelect;
    public AudioClip clipEntered;
    public AudioSource source;

    // Update is called once per frame
    void Update()
    {
        float vertical;
        vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            AudioSource.PlayClipAtPoint(clipSelect, transform.position);
        }
        if (Input.GetAxis("Submit") == 1)
        {
            AudioSource.PlayClipAtPoint(clipEntered, transform.position);
        }
    }
}
