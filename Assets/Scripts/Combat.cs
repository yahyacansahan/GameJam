using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    Controller controller;
   public Bars bars;
    Collider2D[] hitEnemies;
    Transform AttackPoint;
    Transform CreationPoint;
    float Damage;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] GameObject FireBallGO;
    public bool Attackable, EnemyInCollider;
    TransFormer Trans;
    public float Health, Stamina;


    [SerializeField] GameObject Azazel;


    void Start()
    {
        controller = gameObject.GetComponent<Controller>();
        AttackPoint = gameObject.GetComponent<Transform>();
        EnemyLayer = LayerMask.GetMask("Enemy");
        CreationPoint = transform.Find("CreatPointAzazel");

        if (GameObject.Find("Bars"))
        {
            bars = GameObject.Find("Bars").GetComponent<Bars>();
        }

        Trans = FindObjectOfType<TransFormer>();
        Attackable = true;
    }

    void Update()
    {
        KeyEvent();


        if (Stamina < 100)
        {

            Stamina += Time.deltaTime * 2f;
        }

        bars.Stamina = Stamina;
        bars.Health = Health;
    }

    void KeyEvent()
    {
        if (Attackable)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AttackEvent(KeyCode.Z);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                AttackEvent(KeyCode.X);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                AttackEvent(KeyCode.C);
            }else if (Input.GetKeyDown(KeyCode.B))
            {
                AttackEvent(KeyCode.B);
            }
        }
    }

    void AttackEvent(KeyCode keyCode)
    {
        if (!controller.animator.GetBool("Jumping") && !controller.isDash && bars.Stamina > Damage)
        {
            controller.Movable = false;
            controller.isAttacking = true;

            if (keyCode == KeyCode.Z)
            {
                controller.animator.Play("Attack1");

                if (Stamina > 70)
                {
                    Stamina -= 70;

                    Trans.ShapeShift();
                    
                }
               

            }
            else if (keyCode == KeyCode.X)
            {
                controller.animator.Play("Attack2");
                Damage = 10;
            }
            else if (keyCode == KeyCode.C)
            {
                controller.animator.Play("Attack3");
                Damage = 10;
            }else if (keyCode == KeyCode.B)
            {
                if (Stamina > 50)
                {
                    controller.animator.Play("Attack1");
                    CrateAzazel();
                    Stamina -= 50;
                }
            
            }
        }
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        bars.Health = this.Health;
        transform.GetComponent<Animator>().Play("TakeDamage");

        controller.Movable = true;

    }

    public void CreateFireBall()
    {
        Instantiate(FireBallGO, new Vector3(gameObject.transform.position.x - 0.375f, gameObject.transform.position.y - 0.2f, 0), Quaternion.identity);
    }

    public void Attack()
    {
        hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, .2f, EnemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.GetComponent<NewEnemy>().isDead)
            {
                if (bars.Stamina >= 20)
                {
                    enemy.GetComponent<NewEnemy>().TakeDamage(Damage);
                    bars.Stamina -= Damage;
                }
                else
                {
                    enemy.GetComponent<NewEnemy>().TakeDamage(Damage * bars.Stamina / 20);
                 //   bars.Stamina = 0;
                }
            }
        }
    }

    public void AttackEnd()
    {
        controller.Movable = true;
    }

    public void GameOver()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireTrap")
        {

            TakeDamage(10);
        }
        if (collision.gameObject.tag == "LittleOnes")
        {


        }


    }

    public void CrateAzazel()
    {
        Instantiate(Azazel, CreationPoint.position,Quaternion.identity);

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LittleOnes")
        {
            if (Input.GetKeyDown(KeyCode.E) && !collision.gameObject.GetComponent<Kucukler>().deadAlready)
            {
                
                Health += 5;
                Stamina += 5;
                collision.gameObject.GetComponent<Kucukler>().Death();
            }
          

        }
    }
}
