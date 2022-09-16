using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemymaleaTTACK : MonoBehaviour
{
    Controller Adventurer;
    Rigidbody2D Rb;
    Animator Animator2d;
    [SerializeField] Transform FootTriggers;
    [SerializeField] bool İsOnGround;
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask PlayerLayer;

    [Header("Değerler")]
    [SerializeField] private float AttackMenzili;
    [SerializeField] private float FarketmeMenzili;
    [SerializeField] private float Speed;
    [SerializeField] private float AttackRadius = 1.2f;
    [SerializeField] private float AttackDamage = 30;
    //----------
  [SerializeField]  bool isAttack = false;
    Vector3 LocalScale;
    int AttackCounter = 0;
    int attackEndCounter = 0;
    private void Start()
    {
        Adventurer = FindObjectOfType<Controller>();
        Rb = GetComponent<Rigidbody2D>();
        LocalScale = this.transform.localScale;
        Animator2d = GetComponent<Animator>();
        FootTriggers = gameObject.transform.Find("GroundTriggerboss3");
        
        attackPoint = transform.Find("AttackBossPoint");
    }

    private void Update()
    {
        İsOnGround = Physics2D.OverlapCircle(FootTriggers.position, .2f, GroundLayer);
        Flip();
        MovementAndAnimation();

    }


    private void MovementAndAnimation()
    {
        


        if (Vector2.Distance(transform.position, Adventurer.transform.position) < FarketmeMenzili && !(Vector2.Distance(transform.position, Adventurer.transform.position) < AttackMenzili) && İsOnGround&& !isAttack)
        {
            if (Adventurer.transform.position.x > this.transform.position.x)
            {

                Rb.velocity = (new Vector3(Speed, 0, 0));


            }
            else
            {
                Rb.velocity = (new Vector3(-Speed, 0, 0));
            }


            Animator2d.SetBool("Running", true);
        }
        else if ((Vector2.Distance(transform.position, Adventurer.transform.position) < AttackMenzili)&& !isAttack)
        {
            Rb.velocity = (new Vector3(0, 0, 0));
            if (!isAttack)
            {
                Attack();

            }
        }
        else
        {
            Animator2d.SetBool("Running", false);
        }

    }


    private void Flip()
    {
        if (!isAttack)
        {

            if (Adventurer.transform.position.x > this.transform.position.x)
            {
                transform.localScale = new Vector3(LocalScale.x, LocalScale.y, LocalScale.z);

            }
            else
            {
                transform.localScale = new Vector3(LocalScale.x * -1, LocalScale.y, LocalScale.z);
            }


        }
    }

    private void Attack()
    {
        Rb.velocity = (new Vector3(0, 0, 0));
        isAttack = true;
        AttackCounter++;
        if (AttackCounter == 3)
        {
            Animator2d.Play("Attack2");

            AttackCounter = 0;

        }
        else
        {
            Animator2d.Play("Attack1");
        }

        

    }

    private void AttackEnd()
    {
        if (attackEndCounter == 1)
        {

            attackEndCounter = 0;
        }
        attackEndCounter++;

        if (Physics2D.OverlapCircle(attackPoint.transform.position, AttackRadius, PlayerLayer))
        {
          //  Adventurer.TakeDamage(AttackDamage);

        }

        StartCoroutine(Patlatıyim());

    }

    IEnumerator Patlatıyim()
    {


        yield return new WaitForSeconds(.5f);
        isAttack = false;
    }




}
