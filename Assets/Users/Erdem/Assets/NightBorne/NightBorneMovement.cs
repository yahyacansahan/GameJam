using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Transformt = FindObjectOfType<TransFormer>();
        gameObject.SetActive(NightBorneSlider);
        NightBorneSlider.gameObject.SetActive(true);
        NightBorneLifeTime = 100;
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
            NightBorneSlider.gameObject.SetActive(false);
            Transformt.ShapeShift();
        }



    }
    private void FixedUpdate()
    {
        NightBorneLifeTime -= Time.deltaTime;
        NightBorneSlider.value = NightBorneLifeTime;
        
    }

    public void NightBorneTakeDamage(float Damage)
    {

        NightBorneLifeTime -= Damage;
        if (NightBorneLifeTime < 0)
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
    }

}

