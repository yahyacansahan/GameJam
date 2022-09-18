using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BomBoşNpc : MonoBehaviour
{
    [SerializeField] string Text = "";
    [SerializeField] TextMeshProUGUI TextOfWitch;
    [SerializeField] Canvas Canvas;
    void Start()
    {
        Canvas.gameObject.SetActive(false);
        TextOfWitch.text = Text;
        TextOfWitch.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TextOfWitch.text = Text;
            Canvas.gameObject.SetActive(true);
            TextOfWitch.gameObject.SetActive(true);
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TextOfWitch.gameObject.SetActive(false);
            Canvas.gameObject.SetActive(false);
        }
    }

}
