using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoNPCEvent : MonoBehaviour
{
    GameObject EventKeyGO;
    SaveSystem saveSystem;
    bool CanEvent;
    NewBehaviourScript Nb;
    // Start is called before the first frame update
    void Start()
    {
        EventKeyGO = transform.Find("EventKeyGO").gameObject;
        EventKeyGO.SetActive(false);
        saveSystem = GameObject.Find("SaveSystem").GetComponent<SaveSystem>();
        Nb = GetComponent<NewBehaviourScript>();
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
        saveSystem.Save();
        if (gameObject.name == "FishermanNPC")
        {
            SceneManager.LoadScene("Fisherman");
        }
        else if (gameObject.name == "WoodCutterNPC")
        {
            SceneManager.LoadScene("Woodcutter");
        }
        else if (gameObject.name == "GoNight")
        {

            Nb.hangiLevel();

            //SceneManager.LoadScene("GecisSahnesi");
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
