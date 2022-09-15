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
    public bool Attackable,EnemyInCollider;

    
    Transform SwordAttackPoint;

    
    
    void Start()
    {
        controller = gameObject.GetComponent<Controller>();
        AttackPoint = gameObject.GetComponent<Transform>();
        EnemyLayer = LayerMask.GetMask("Enemy");
        if (GameObject.Find("Bars"))
        {
            bars = GameObject.Find("Bars").GetComponent<Bars>();
            Attackable = true;
        }
        SwordAttackPoint = transform.Find("AttackPoint");
    }

    void Update()
    {
        KeyEvent();
    }

    void KeyEvent()
    {
        if(Attackable)
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
        } 
    }

    void Attack(KeyCode keyCode)
    {
        if (!controller.animator.GetBool("Jumping") && !controller.isDash)
        {
            controller.isAttacking = true;

            if (keyCode == KeyCode.Z)
            {
                controller.animator.Play("Attack1");
                Damage = 20;
            }
            else if (keyCode == KeyCode.X)
            {
                controller.animator.Play("Attack2");
                Damage = 20;
            }
            else if (keyCode == KeyCode.C)
            {
                controller.animator.Play("Attack3");
                Damage = 20;
            }

            hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, .2f, EnemyLayer);

            /**foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.GetComponent<EnemyHealthBar>().isDead)
                {
                    if (bars.Stamina >= 20)
                    {
                        enemy.GetComponent<EnemyHealthBar>().TakeDamage(Damage);
                        bars.Stamina -= Damage;
                    }
                    else
                    {
                        enemy.GetComponent<EnemyHealthBar>().TakeDamage(Damage * bars.Stamina / 20);
                        bars.Stamina = 0;
                    }
                }
            }**/
            bars.Stamina -= 30;
        }
    }

    void TakeDamage(float Damage)
    {
        bars.Health-= Damage;
    }
    public void AttackEnd()
    {
        hitEnemies = Physics2D.OverlapCircleAll(SwordAttackPoint.position, 1.2f, EnemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.GetComponent<NewEnemy>().isDead)
            {

                enemy.GetComponent<NewEnemy>().TakeDamage(15);

            }
        }

    }
}
