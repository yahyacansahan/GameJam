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
    bool IsAttack = false;
    bool Right;
    bool IsDead = false;

    [Header("İstatistikler")]
    [SerializeField] float MagicBallSpeed, RunSpeed,Farketmemenzili,AttackMenzili,damage;

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
        Flip();
        Movement();
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
        IsDead = GetComponent<NewEnemy>().isDead;
        CanAttack = false;
        WizardAnimaytor.Play("Attack");
        IsAttack = true;
        StartCoroutine(forBugs());

    }

    void Movement()
    {

        if (Vector2.Distance(transform.position, Player.transform.position) < Farketmemenzili && Vector2.Distance(transform.position, Player.transform.position) > AttackMenzili)
        {
            if (Right)
            {
                Rb.velocity= new Vector3(-RunSpeed,0,0);

            }
            else
            {

                Rb.velocity = new Vector3(RunSpeed, 0, 0);
            }



           


        }
        else if (Vector2.Distance(transform.position, Player.transform.position) < AttackMenzili && CanAttack&&!IsDead)
        {
            Rb.velocity = new Vector3(0, 0, 0);
            Attack();
            WizardAnimaytor.SetBool("Running", false);
        }
        Flip();

        WizardAnimaytor.SetBool("Running", true);

       

    }


    void SendMagickaBall()
    {
      GameObject Go=  Instantiate(WizardEnerGyBall, WizardAttackPoint.position, Quaternion.identity);
        IsAttack = true;
        if (Right)
        {
            Go.GetComponent<oK>().Fırla(-MagicBallSpeed);

        }
        else
        {
            Go.GetComponent<oK>().Fırla(MagicBallSpeed);

        }
        Go.GetComponent<oK>().Damage = damage;
    }

    void AttackAgain()
    {
        StartCoroutine(AttackWaitTime());

    }

    IEnumerator AttackWaitTime()
    {

        yield return new WaitForSeconds(1.4f);
        CanAttack = true;
    
    }
    IEnumerator forBugs()
    {

        yield return new WaitForSeconds(3f);

        if (CanAttack == false && IsAttack==true)
        {

            CanAttack = true;
        }

    }
 
}
