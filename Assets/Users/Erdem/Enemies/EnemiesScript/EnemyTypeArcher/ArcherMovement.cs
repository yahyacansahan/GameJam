using System.Collections;
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
    bool Attacking = false;

    [Header("istatistikler")]
    [SerializeField] float RunSpeed;
    [SerializeField] float FarketmeMenzili;
    [SerializeField] float attackMenzili;
    [SerializeField] float Hasar;

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
                    Rb.velocity = new Vector3(-RunSpeed, -1.5f, 0);

                }
                else
                {
                    Rb.velocity = new Vector3(RunSpeed, -1.5f, 0);


                }


            }

            

            if (Vector2.Distance(Player.gameObject.transform.position, transform.position) < attackMenzili)
            {
                if (CanAttack)
                {
                    Attack();
                    Rb.velocity = new Vector3(0, -1.5f, 0);
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
        Attacking = true;
        Animator.Play("Attack");
        StartCoroutine(attackbugSit());

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
        ok.GetComponent<oK>().Damage = Hasar;
        Attacking = false;
    }

    public void TekrarOkAt()
    {
        CanAttack = true;
       
    }

    IEnumerator attackbugSit()
    {


        yield return new WaitForSeconds(3f);
            if(Attacking == false && CanAttack == false)
        {

            CanAttack = true;
        }
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
