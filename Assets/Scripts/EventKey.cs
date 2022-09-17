using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKey : MonoBehaviour
{
    [SerializeField] GameObject EventKeyGO;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        EventKeyGO.SetActive(false);

    }

    private void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            EventKeyGO.SetActive(false);
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
        if (collision.CompareTag("Player"))
        {
            active = false;
            EventKeyGO.SetActive(false);
        }
    }
}
