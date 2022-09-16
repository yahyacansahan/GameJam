﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    Animator Animator;
    Controller Player;
    Vector3 LocalScale;
    bool CanAttack=true;
    bool Right = true;

    [Header("istatistikler")]
    [SerializeField] float RunSpeed;
    [SerializeField] float FarketmeMenzili;
    [SerializeField] float attackMenzili;

    [Header("ok")]
    [SerializeField] GameObject Ok;
    [SerializeField] Transform OkPozisyonu;
    [SerializeField] float OkunHızı;

   

    void Start()
    {
        Animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<Controller>();
        LocalScale = transform.localScale;
        OkPozisyonu = transform.Find("ArcherAttackPoint");
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Flip();


    }

    void Movement()
    {
        if (Vector2.Distance(Player.gameObject.transform.position, transform.position) < FarketmeMenzili)
        {
            if (CanAttack)
            {
                if (Right)
            {
                    Rb.velocity = new Vector3(-RunSpeed, 0, 0);

                }
                else
                {
                    Rb.velocity = new Vector3(RunSpeed, 0, 0);


                }


            }

            

            if (Vector2.Distance(Player.gameObject.transform.position, transform.position) < attackMenzili)
            {
                if (CanAttack)
                {
                    Attack();
                    Rb.velocity = new Vector3(0, 0, 0);
                    CanAttack = false;

                }

            }
            
            if (!CanAttack)
            {
                Animator.SetBool("Running", true);

            }



        }
        else
        {
            Animator.SetBool("Running", false);
        }



    }

    void Attack()
    {

        Animator.Play("Attack");

    }

    void OkFırlat()
    {

       GameObject ok= Instantiate(Ok, OkPozisyonu.position,Quaternion.identity);
        if (Right)
        {
            ok.GetComponent<oK>().Fırla(-OkunHızı);

        }
        else
        {
            ok.GetComponent<oK>().Fırla(OkunHızı);
        }
       
    }

    public void TekrarOkAt()
    {
        CanAttack = true;

    }


    void Flip()
    {
        if (Player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(LocalScale.x , transform.localScale.y, transform.localScale.z);
            Right = false;
        }
        else
        {
            transform.localScale = new Vector3(LocalScale.x * -1, transform.localScale.y, transform.localScale.z);
            Right = true;
        }

    }

}