using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    Animator Animator;
    Vector2 Movement;
    Collider2D[] hitEnemies;
    [SerializeField] float Speed,Damage;
    [SerializeField] LayerMask EnemyLayer;
    TransFormer Transformt;
    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Transformt = FindObjectOfType<TransFormer>();

    }

    // Update is called once per frame
    void Update()
    {
       Movement= new Vector2(Input.GetAxis("Horizontal"), -2);

          
        if (Mathf.Abs(Input.GetAxis("Horizontal") )>.2f)
        {

            Animator.SetBool("Run", true);

        }
        else { Animator.SetBool("Run", false); 
        
        
        }

        Rb.velocity = Movement*Speed;

        if (Input.GetKey(KeyCode.X))
        {
            Animator.Play("Attack");

        }

        if (Input.GetAxis("Horizontal") > 0)
        {

            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.V))
        {

            Transformt.ShapeShift();
        }

    }


    void AttackEnd()
    {


        hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1.2f, EnemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.GetComponent<NewEnemy>().isDead)
            {

                enemy.GetComponent<NewEnemy>().TakeDamage((int)Damage);

            }
        }

    }

}

