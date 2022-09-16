using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingAreaEvent : MonoBehaviour
{
    GameObject KeyEvent;
    private void Start()
    {
        KeyEvent = GameObject.Find("EventKey").GetComponent<GameObject>();
        KeyEvent.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fisherman")
        {
            KeyEvent.SetActive(true);
        }
    }
}
