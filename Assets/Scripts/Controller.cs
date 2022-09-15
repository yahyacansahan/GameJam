using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    Animator animator;
    Collider2D PlayerCollider;
    public float MovementSpeed = 5, DashSpeed = 10;
    public bool Moving, isGround, isDash, isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        PlayerCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyEvent();
        Checker();
        Falling();
    }

    void Checker()
    {
        if ((PlayerRB.velocity.x < -0.3f || PlayerRB.velocity.x > 0.3f) && !animator.GetBool("Jumping"))
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (isGround)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("isGround", true);
        }

        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Idle")
        {
            isAttacking = false;
            isDash = false;
            PlayerCollider.isTrigger = false;
            PlayerRB.bodyType = RigidbodyType2D.Dynamic;
        }

        if (!Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);
        }
    }

    void KeyEvent()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack(KeyCode.Z);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Attack(KeyCode.X);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Attack(KeyCode.C);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDash = true;
            Dash();
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch();
        }

        if (!isDash)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !isAttacking)
            {
                if (animator.GetBool("isCrouch"))
                {
                    PlayerRB.velocity = new Vector2(MovementSpeed / 2, PlayerRB.velocity.y);
                }
                else
                {
                    PlayerRB.velocity = new Vector2(MovementSpeed, PlayerRB.velocity.y);
                }
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !isAttacking)
            {
                if (animator.GetBool("isCrouch"))
                {
                    PlayerRB.velocity = new Vector2(-MovementSpeed / 2, PlayerRB.velocity.y);
                }
                else
                {
                    PlayerRB.velocity = new Vector2(-MovementSpeed, PlayerRB.velocity.y);
                }
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (!(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
            {
                PlayerRB.velocity = new Vector2(0, PlayerRB.velocity.y);
            }
        }
    }

    void Attack(KeyCode keyCode)
    {
        isAttacking = true;

        if (keyCode == KeyCode.Z)
        {
            animator.Play("Attack1");
        }
        else if (keyCode == KeyCode.X)
        {
            animator.Play("Attack2");
        }
        else if (keyCode == KeyCode.C)
        {
            animator.Play("Attack3");
        }
    }

    void Jump()
    {
        Debug.Log("jump");
        animator.SetBool("Jumping", true);
        PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, 10);
    }

    void Falling()
    {
        if (animator.GetBool("Jumping") == true && PlayerRB.velocity.y <= 0)
        {
            animator.SetBool("Falling", true);
            animator.SetBool("Jumping", false);
        }

        if (animator.GetBool("Jumping") == false && PlayerRB.velocity.y < 0.2)
        {
            animator.SetBool("Falling", true);
        }
    }

    void Dash()
    {
        isDash = true;
        animator.Play("Dash");
        PlayerRB.bodyType = RigidbodyType2D.Kinematic;
        PlayerCollider.isTrigger = true;
        PlayerRB.velocity = new Vector2(DashSpeed * gameObject.transform.localScale.x, PlayerRB.velocity.y);
    }

    void Crouch()
    {
        animator.SetBool("isCrouch", true);
    }



}
