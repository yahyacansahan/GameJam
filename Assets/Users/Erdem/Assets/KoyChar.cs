using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoyChar : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] Animator Animator;
    [SerializeField] float WalkSpeed;
    public bool IsSpeak = false;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }


    void Update()
    {

        if (!IsSpeak)
        {

            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            Rb.velocity = Movement * WalkSpeed;


            if (Mathf.Abs(Rb.velocity.x) >= .3f)
            {
                Animator.SetBool("Walk", true);

            }
            else
            {

                Animator.SetBool("Walk", false);
            }

            if (Rb.velocity.x > .1f)
            {
                // transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                transform.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if(Rb.velocity.x < -.1f)
            {
                //  transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                transform.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            Rb.velocity = new Vector3(0, 0, 0);
            Animator.SetBool("Walk", false);
        }


    }
}
