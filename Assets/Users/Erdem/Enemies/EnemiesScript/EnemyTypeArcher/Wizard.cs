using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    Rigidbody2D Rb;
    Animator WizardAnimaytor;
    Vector3 LocalScale;
    Controller Player;
    bool CanAttack = true;
    bool Right;

    [Header("İstatistikler")]
    [SerializeField] float MagicBallSpeed, RunSpeed,Farketmemenzili,AttackMenzili;

    [Header("alacakları")]
    [SerializeField] GameObject WizardEnerGyBall;
    [SerializeField] Transform WizardAttackPoint;

    void Start()
    {
        WizardAttackPoint = transform.Find("WizardattackPoint");
        Rb = GetComponent<Rigidbody2D>();
        WizardAnimaytor = GetComponent<Animator>();
        LocalScale = transform.localScale;
        Player = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Flip()
    {
        if (Player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(LocalScale.x, transform.localScale.y, transform.localScale.z);
            Right = false;
        }
        else
        {
            transform.localScale = new Vector3(LocalScale.x * -1, transform.localScale.y, transform.localScale.z);
            Right = true;
        }


    }

    void Attack()
    {

        CanAttack = false;
        WizardAnimaytor.Play("Attack");

    }

    void Movement()
    {

        if (Vector2.Distance(transform.position, Player.transform.position) < Farketmemenzili)
        {
            if(Vector2.Distance(transform.position, Player.transform.position) < AttackMenzili&&CanAttack)
            {
                
                Attack();

            }
            Flip();

            WizardAnimaytor.SetBool("Running", true);



        }
        else
        {
            WizardAnimaytor.SetBool("Running", false);
        }

    }


    void SendMagickaBall()
    {
      GameObject Go=  Instantiate(WizardEnerGyBall, WizardAttackPoint.position, Quaternion.identity);

        if (Right)
        {
            Go.GetComponent<oK>().Fırla(MagicBallSpeed);
        }
        else
        {
            Go.GetComponent<oK>().Fırla(-MagicBallSpeed);

        }
       
    }

    void AttackAgain()
    {
        StartCoroutine(AttackWaitTime());

    }

    IEnumerator AttackWaitTime()
    {

        yield return new WaitForSeconds(1.2f);
        CanAttack = true;
    }
 
}
