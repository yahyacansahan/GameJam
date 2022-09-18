using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoNPCEvent : MonoBehaviour
{
    GameObject EventKeyGO;
    bool CanEvent;
    // Start is called before the first frame update
    void Start()
    {
        EventKeyGO = transform.Find("EventKeyGO").gameObject;
        EventKeyGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        KeyEvent();
    }

    void KeyEvent()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanEvent)
        {
            LoadEvent();
        }
    }

    void LoadEvent()
    {
        if (gameObject.name == "FishermanNPC")
        {
            SceneManager.LoadScene("Fisherman");
        }
        else if (gameObject.name == "WoodCutterNPC")
        {
            SceneManager.LoadScene("Woodcutter");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CanEvent = true;
            EventKeyGO.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CanEvent = false;
            EventKeyGO.SetActive(false);
        }
    }
}
