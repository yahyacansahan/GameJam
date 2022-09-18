using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField] GameObject EventKeyGO;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        EventKeyGO = gameObject.transform.Find("EventKeyGO").gameObject;
        EventKeyGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        KeyEvent();
    }

    void KeyEvent()
    {
        if (Input.GetKeyDown(KeyCode.E) && active)
        {
            SceneManager.LoadScene("Köyleveli");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            active = true;
            EventKeyGO.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            active = false;
            EventKeyGO.SetActive(false);
        }
    }
}
