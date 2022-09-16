using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    Controller controller;
    Bars bars;
    Collider2D[] hitEnemies;
    Transform AttackPoint;
    float Damage;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] GameObject FireBallGO;
    public bool Attackable, EnemyInCollider;
    TransFormer Trans;

    TransFormer Trans;

    void Start()
    {
        controller = gameObject.GetComponent<Controller>();
        AttackPoint = gameObject.GetComponent<Transform>();
        EnemyLayer = LayerMask.GetMask("Enemy");

        if (GameObject.Find("Bars"))
        {
            bars = GameObject.Find("Bars").GetComponent<Bars>();
        }

        Trans = FindObjectOfType<TransFormer>();
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        Attackable = true;
    }

    void Update()
    {
        KeyEvent();
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
        }
    }

    void AttackEvent(KeyCode keyCode)
    {
        if (!controller.animator.GetBool("Jumping") && !controller.isDash && bars.Stamina>Damage)
        {
            controller.Movable = false;
            controller.isAttacking = true;

            if (keyCode == KeyCode.Z)
            {
              //  controller.animator.Play("Attack1");
<<<<<<< Updated upstream
               // Damage = 10;
                Trans.ShapeShift();
                //Transform.ShapeShift();
=======
                //Damage = 10;
                Trans.ShapeShift();
>>>>>>> Stashed changes
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
        }
    }

    public void TakeDamage(float Damage)
    {
        bars.Health -= Damage;
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
                    bars.Stamina = 0;
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
        //GameOver penceresi açýlacak.
    }
}
