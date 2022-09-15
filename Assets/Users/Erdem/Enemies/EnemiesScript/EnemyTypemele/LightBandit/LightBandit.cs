using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBandit : MonoBehaviour
{

    [SerializeField] float Speed=3f;
    [SerializeField] float Farketmemenzili, Attackmenzili;

    Rigidbody2D Rb;
    PlayerMovement Player;
    Animator Animatorbandit;

    Vector3 LocalScale;


    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animatorbandit = GetComponent<Animator>();
        Player = FindObjectOfType<PlayerMovement>();
        LocalScale = transform.localScale;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        Flip();
        MovementOf_Lightbandit();

    }

    void MovementOf_Lightbandit()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < Farketmemenzili)
        {

            if (Player.transform.position.x > transform.position.x)
            {

                Rb.velocity = new Vector3(1*Speed,0,0);
            }
            else
            {

                Rb.velocity = new Vector3(-1 * Speed, 0, 0);
            }
            Animatorbandit.SetBool("Running", true);
        }
        else
        {
            Animatorbandit.SetBool("Running", false);

        }



    }

    void Flip()
    {

        if (Player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(LocalScale.x*-1,transform.localScale.y,transform.localScale.z) ;

        }
        else
        {
            transform.localScale = new Vector3(LocalScale.x , transform.localScale.y, transform.localScale.z);

        }


    }

}
