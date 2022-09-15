using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NormalForm : MonoBehaviour
{
    public float normalSpeed;
    public float hypeSpeed;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) //hýzlanma için kodlar
        {
            speed = hypeSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        if (Input.GetKey(KeyCode.A)) //sola gidiþ
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D)) //saða gidiþ
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E)) //etkileþim tuþu
        {
            interaction();
        }
        
    }

    void interaction() //etkileþim kodu
    {
        Debug.Log("e ye bastýn");
    }
}
  