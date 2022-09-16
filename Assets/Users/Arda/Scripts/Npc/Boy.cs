using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    Rigidbody2D Rb;
    Animator Animator;

    [SerializeField] float Speed = 3f;

    bool MoveWait = true;
    Vector3 localSize;
    bool CanMove = false;
    [SerializeField] bool Diyalog = false;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        localSize = transform.localScale;
        Move();

    }

    void Move()
    {

        //Vector2.MoveTowards(transform.position, transform.right, Speed);
        Rb.velocity = new Vector2(Speed, 0);
        StartCoroutine(Timer());
        Animator.SetBool("Walk", true);
    }

    void WaitAndTurn()
    {
        Rb.velocity = new Vector2(0, 0);
        Animator.SetBool("Walk", false);
        CanMove = false;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        StartCoroutine(Timer());
        Speed *= -1 * Random.Range(.8f, 1.2f);

    }

    IEnumerator Timer()
    {

        if (Diyalog)
        {
            Dialoog();
            yield return new WaitForSeconds(.01f);
        }
        else
        {

            yield return new WaitForSeconds(5f);


            if (MoveWait)
            {
                WaitAndTurn();
                MoveWait = false;
            }
            else
            {
                Move();

                MoveWait = true;

            }



        }




    }

    void Dialoog()
    {

        Animator.SetBool("Walk", false);


    }

    void DialogEnd()
    {


        Diyalog = false;
        Invoke("Move", 1f);

    }

    // Update is called once per frame
    void Update()
    {


    }
}

