using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Controller : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    public Animator animator;
    Collider2D PlayerCollider;
    public float MovementSpeed = 5, DashSpeed = 10;
    public bool Moving, isGround, isDash, isAttacking, Attackable, isJumping, Movable;

    public Vector3 Size;

    [Header("Sesler")]
    [SerializeField] AudioSource Source;
    [SerializeField] GameObject ChildSfx;
    [SerializeField] AudioClip  Jumpsfx;
    [SerializeField] AudioClip Dashsfx;
  



    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        PlayerCollider = gameObject.GetComponent<Collider2D>();
        Size = transform.localScale;
        Source = GetComponent<AudioSource>();
        ChildSfx = GameObject.Find("SoundFx");
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
            Source.enabled = true;
        }
        else
        {
            Source.enabled = false;
            animator.SetBool("isMoving", false);
        }

        if (isGround)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("isGround", true);
        }
        else
        {
            animator.SetBool("isGround", false);
        }

        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Idle")
        {
            isAttacking = false;
            isDash = false;
            Movable = true;
        }

        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Falling")
        {
            isJumping = false;
        }

        if (!Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);
        }

        if (!Movable)
        {
            PlayerRB.velocity = new Vector2(0, 0);
        }
    }

    void KeyEvent()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDash)
        {
            Jump();
            ChildSfx.GetComponent<AudioSource>().PlayOneShot(Jumpsfx);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDash = true;
            Dash();
            ChildSfx.GetComponent<AudioSource>().PlayOneShot(Dashsfx);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch();
            transform.gameObject.layer = 9;

        }
        else
        {
            transform.gameObject.layer = 7;

        }


        if (!isDash && Movable)
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
                //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                gameObject.transform.localScale = new Vector3(Size.x, Size.y, Size.z);
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
                //gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                gameObject.transform.localScale = new Vector3(-Size.x, Size.y, Size.z);
            }
            else if (!(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
            {
                PlayerRB.velocity = new Vector2(0, PlayerRB.velocity.y);
            }
        }
    }

    void Jump()
    {
        if (isGround && !isJumping)
        {
            isJumping = true;
            animator.SetBool("Jumping", true);
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, 10);
        }
        else if (!isGround && isJumping)
        {
            isJumping = false;
            animator.SetBool("Jumping", true);
            animator.SetBool("Falling", false);
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, 10);
        }
    }

    void Falling()
    {
        if (animator.GetBool("Jumping") == true && PlayerRB.velocity.y <= 0)
        {
            animator.SetBool("Falling", true);
            animator.SetBool("Jumping", false);
        }

        if (animator.GetBool("Jumping") == false && PlayerRB.velocity.y < -0.1)
        {
            animator.SetBool("Falling", true);
        }
    }

    void Dash()
    {
        isDash = true;
        animator.Play("Dash");
        PlayerRB.velocity = new Vector2(DashSpeed * gameObject.transform.localScale.x, PlayerRB.velocity.y);
    }

    void Crouch()
    {
        animator.SetBool("isCrouch", true);
    }


}
