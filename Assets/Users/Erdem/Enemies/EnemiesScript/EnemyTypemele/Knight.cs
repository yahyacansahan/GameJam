using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D RbOfknight;
    Animator animator;
    Controller Player;
    Vector3 LocalScale;
   [SerializeField] bool CanAttack=true;
    [SerializeField] bool NightBorneScarred = false;

    [SerializeField] float Speed,attackMenzili,FightAramaMenzili;
    NightBorneMovement NightBorne;
    [SerializeField] LayerMask NightBorneLayer = 10;

    void Start()
    {
        RbOfknight = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player = FindObjectOfType<Controller>();
        LocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        Flip();
        Movement();
    
    }

    void Movement()
    {

        if (Physics2D.OverlapCircle(transform.position, 10f, NightBorneLayer))
        {
            NightBorne = FindObjectOfType<NightBorneMovement>();

            if (Vector2.Distance(NightBorne.transform.position, this.transform.position) < 10)
            {
                NightBorneScarred = true;
                if (NightBorne.transform.position.x > this.transform.position.x)
                {

                    RbOfknight.velocity = new Vector2(-Speed, 0);
                    animator.SetBool("running", true);

                }
                else
                {
                    RbOfknight.velocity = new Vector2(Speed, 0);
                    animator.SetBool("running", true);

                }


            }
            else
            {
                NightBorneScarred = false;
            }



        }else if (Vector2.Distance(Player.gameObject.transform.position, transform.position) < FightAramaMenzili && !NightBorneScarred)
        {
            if(Vector2.Distance(Player.gameObject.transform.position,transform.position)<FightAramaMenzili && Vector2.Distance(Player.gameObject.transform.position, transform.position) > attackMenzili)
            {
                 animator.SetBool("running", true);
                if (Player.gameObject.transform.position.x > transform.position.x)
                {
                    RbOfknight.velocity = new Vector2(Speed, 0);
                }
                else if(Player.gameObject.transform.position.x < transform.position.x)
                {
                    RbOfknight.velocity = new Vector2(-Speed, 0);

                }


            }else if (Vector2.Distance(Player.gameObject.transform.position, transform.position) < attackMenzili)
            {
                animator.SetBool("running", false);
                RbOfknight.velocity = (new Vector3(0, 0, 0));
                Attack();

            }

        }






        


    }

    void Attack()
    {
      
        animator.Play("Attack");

    }
    void AttackEnd()
    {

        if(Vector2.Distance(Player.transform.position, transform.position) < 3f)
        {
            Player.GetComponent<Combat>().TakeDamage(15f);

        }

        StartCoroutine(WaitForNextAtttack());

    }
    IEnumerator WaitForNextAtttack()
    {


        yield return new WaitForSeconds(1f);
        CanAttack = true;
    } 

    void Flip()
    {
        if (NightBorneScarred)
        {

            if (NightBorne.gameObject.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-LocalScale.x, LocalScale.y, LocalScale.z);
                RbOfknight.velocity = new Vector2(-Speed, RbOfknight.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(LocalScale.x , LocalScale.y, LocalScale.z);
                RbOfknight.velocity = new Vector2(Speed, RbOfknight.velocity.y);
            }


        }
        else if(CanAttack)
        {

            if (Player.gameObject.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(LocalScale.x, LocalScale.y, LocalScale.z);
               // RbOfknight.velocity = new Vector2(Speed, RbOfknight.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(LocalScale.x * -1, LocalScale.y, LocalScale.z);
              //  RbOfknight.velocity = new Vector2(-Speed, RbOfknight.velocity.y);
            }

        }
      

        

      

    }



}
