using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azazel : MonoBehaviour
{
    Rigidbody2D Rb;
    public float Speed;
    Controller Player;
    void Start()
    {
        Player = FindObjectOfType<Controller>();
        Rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        
    }
    void Creation()
    {
        if (Player.transform.position.x > transform.position.x)
        {

            transform.GetComponent<SpriteRenderer>().flipX = true;
            Speed *= -1;
        }

    }

    void ilerle()
    {
        Rb.velocity = new Vector3(Speed, 0, 0);


    }

    void Dur()
    {
        Rb.velocity = new Vector3(0, 0, 0);

    }

    void YokOl()
    {

        Destroy(this.gameObject);

    }
}
