using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtkileşimSc : MonoBehaviour
{
    [SerializeField] LayerMask NpcLayer;
    [SerializeField] GameObject Ebutonu;
    [SerializeField] bool Speak = false;
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
        if (NpcAraund)
        {
            if (Input.GetKeyDown(KeyCode.E) && !Speak)
            {
                this.gameObject.GetComponent<KoyChar>().IsSpeak = true;
                Debug.Log("Dur kArdeş");

               

                Speak = true;


            }

            else if (Speak && Input.GetKeyDown(KeyCode.X))
            {
                this.gameObject.GetComponent<KoyChar>().IsSpeak = false;
                Debug.Log("yürü kardeş");
                Speak = false;


            }

        }
       

    }

    public void EndTransmiting()
    {
        this.gameObject.GetComponent<KoyChar>().IsSpeak = false;

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc")
        {
            Ebutonu.SetActive(true);

            if (Speak)
            {
                collision.gameObject.GetComponent<Tester>().StartConvo();
                Debug.Log("Başladı");

            }

            NpcAraund = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc")
        {
            Ebutonu.SetActive(true);

            if (Speak)
            {
                collision.gameObject.GetComponent<Tester>().StartConvo();
                
                Debug.Log("Başladı");
                DialogueManager.StartConversation(convo);
            }
            
            NpcAraund = true;
        }
       

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc")
        {
            Ebutonu.SetActive(false);
            NpcAraund = false;

        }
       
    }
}

