using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NightBorneMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    Animator Animator;
    Vector2 Movement;
    Collider2D[] hitEnemies;
    [SerializeField] float Speed,Damage;
    [SerializeField] LayerMask EnemyLayer;
    TransFormer Transformt;
   public float NightBorneLifeTime = 100;
    public Slider NightBorneSlider;
    bool DamageCanTaken = true;
    [SerializeField] GameObject Bulut;
    [SerializeField] float FlooathSpeed = .2f;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Transformt = FindObjectOfType<TransFormer>();
        gameObject.SetActive(NightBorneSlider);
        NightBorneSlider.gameObject.SetActive(true);
        NightBorneLifeTime = 100;
        Bulut = GameObject.Find("NightBorne_Bulut");
    }

    // Update is called once per frame
    void Update()
    {
     

          
       


        if (Input.GetKey(KeyCode.Space))
        {

            Movement = new Vector2(Input.GetAxis("Horizontal"), +FlooathSpeed);
            Bulut.SetActive(true);
            NightBorneLifeTime -= Time.deltaTime * 10;

        }
        else
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), -1.5f);
            Bulut.SetActive(false);
        }



        if (Mathf.Abs(Input.GetAxis("Horizontal")) > .2f)
        {

            Animator.SetBool("Run", true);
            
        }
        else
        {
            Animator.SetBool("Run", false);
           

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
        else if(Input.GetAxis("Horizontal") < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {


        }

        if (Input.GetKey(KeyCode.V))
        {
            NightBorneSlider.gameObject.SetActive(false);
            Transformt.ShapeShift();
        }



    }
    private void FixedUpdate()
    {
        NightBorneLifeTime -= Time.deltaTime*5;
        NightBorneSlider.value = NightBorneLifeTime;


        if (NightBorneLifeTime < 0)
        {

            DamageCanTaken = false;
            Animator.Play("TurnBack");
        }
        
    }

    public void NightBorneTakeDamage(float Damage)
    {
        if (DamageCanTaken)
        {
            Animator.Play("TakeHit");
            NightBorneLifeTime -= Damage;
            if (NightBorneLifeTime < 0)
            {
                Animator.Play("TurnBack");
                DamageCanTaken = false;
            }

        } 

       
    }


    void ShapeShift()
    {
        Transformt.ShapeShift();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {

            NightBorneTakeDamage(15);
        }
        if (collision.gameObject.tag == "Arrow")
        {

            NightBorneTakeDamage(15);
        }
        if (collision.gameObject.tag == "FireTrap")
        {

            NightBorneTakeDamage(15);
        }
        if (collision.gameObject.tag == "Death")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}

