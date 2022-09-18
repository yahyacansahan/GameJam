using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDia : MonoBehaviour
{
    [SerializeField] LayerMask NpcLayer;
    [SerializeField] GameObject Ebutonu;
    [SerializeField] public bool Speak = false;
    bool NpcAraund = false;
    DialogueManager manager;
    public Conversation convo;

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        Ebutonu.SetActive(false);

    }


    void Update()
    {

    }

    public void EndTransmiting()
    {
        this.gameObject.GetComponent<KoyChar>().IsSpeak = false;

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Ebutonu.SetActive(true);

            if (Speak)
            {
                collision.gameObject.GetComponent<Tester>().StartConvo();
                Debug.Log("Başladı");

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Ebutonu.SetActive(true);

            if (Speak)
            {
                collision.gameObject.GetComponent<Tester>().StartConvo();

                Debug.Log("Başladı");
                DialogueManager.StartConversation(convo);
            }
       }


    }
    }