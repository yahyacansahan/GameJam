using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    Controller controller;
    public Bars bars;
    Collider2D[] hitEnemies;
    Collider2D[] littleOnes;
    Collider2D[] EndOFlayer;

    Transform AttackPoint;
    Transform CreationPoint;
    float Damage;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] LayerMask LittleOneslayer;
    LayerMask EndOF;
    [SerializeField] GameObject FireBallGO;
    public bool Attackable, EnemyInCollider;
    TransFormer Trans;
    public float Health, Stamina;


    [SerializeField] GameObject Azazel;
    [SerializeField] GameObject ChildSfx;
    [SerializeField] AudioClip Attacksfx;
    [SerializeField] AudioClip SpelllSfx;
    [SerializeField] AudioClip hitbysfx;


    void Start()
    {
        EndOF = LayerMask.GetMask("levelEnd");
        controller = gameObject.GetComponent<Controller>();
        AttackPoint = gameObject.GetComponent<Transform>();
        EnemyLayer = LayerMask.GetMask("Enemy");
        CreationPoint = transform.Find("CreatPointAzazel");
        LittleOneslayer = LayerMask.GetMask("LittleOnes");

        if (GameObject.Find("Bars"))
        {
            bars = GameObject.Find("Bars").GetComponent<Bars>();
        }

        Trans = FindObjectOfType<TransFormer>();
        Attackable = true;

        ChildSfx = GameObject.Find("SoundFx");
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
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                AttackEvent(KeyCode.B);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                AttackEvent(KeyCode.E);


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
                    ChildSfx.GetComponent<AudioSource>().PlayOneShot(SpelllSfx);
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
            }
            else if (keyCode == KeyCode.B)
            {
                if (Stamina > 50)
                {
                    ChildSfx.GetComponent<AudioSource>().PlayOneShot(SpelllSfx);
                    controller.animator.Play("Attack1");
                    CrateAzazel();
                    Stamina -= 50;
                }

            }
            else if (keyCode == KeyCode.E)
            {
                Absorbe();

            }
        }
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        bars.Health = this.Health;
        transform.GetComponent<Animator>().Play("TakeDamage");
        ChildSfx.GetComponent<AudioSource>().PlayOneShot(hitbysfx);
        controller.Movable = true;

    }

    public void CreateFireBall()
    {
        Instantiate(FireBallGO, new Vector3(gameObject.transform.position.x - 0.375f, gameObject.transform.position.y - 0.2f, 0), Quaternion.identity);
    }

    public void Attack()
    {
        ChildSfx.GetComponent<AudioSource>().PlayOneShot(Attacksfx);
        hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, 2.2f, EnemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.GetComponent<NewEnemy>().isDead)
            {
                if (bars.Stamina >= 20)
                {
                    enemy.GetComponent<NewEnemy>().TakeDamage(Damage);
                    Stamina -= Damage;
                    bars.Stamina -= Damage;
                }
                else
                {
                    enemy.GetComponent<NewEnemy>().TakeDamage(Damage * bars.Stamina / 20);
                    bars.Stamina = 0;
                }
            }
        }

        EndOFlayer = Physics2D.OverlapCircleAll(AttackPoint.position, .2f, EndOF);

        foreach (Collider2D EndObj in EndOFlayer)
        {
            EndObj.GetComponent<levelEndNpc>().LevelEnd();
        }
    }


    void Absorbe()
    {
        ChildSfx.GetComponent<AudioSource>().PlayOneShot(Attacksfx);
        littleOnes = Physics2D.OverlapCircleAll(AttackPoint.position, .2f, LittleOneslayer);
        {
            foreach (Collider2D little in littleOnes)
            {
                little.GetComponent<Kucukler>().Death();
                Health += 15;
                Stamina += 15;

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
      


    }

    public void CrateAzazel()
    {
        Instantiate(Azazel, CreationPoint.position, Quaternion.identity);

    }



}
