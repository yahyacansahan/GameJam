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
        if (Input.GetKey(KeyCode.LeftShift)) //h�zlanma i�in kodlar
        {
            speed = hypeSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        if (Input.GetKey(KeyCode.A)) //sola gidi�
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D)) //sa�a gidi�
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E)) //etkile�im tu�u
        {
            interaction();
        }
        
    }

    void interaction() //etkile�im kodu
    {
        Debug.Log("e ye bast�n");
    }
}
  