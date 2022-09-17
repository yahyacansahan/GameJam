using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;
    [SerializeField] float Health = 100;
    Animator animator;
    public EnemyhealthBar healthbar;
    public bool isDead;
    [SerializeField] GameObject BloodParticle;
    [SerializeField] GameObject slashParticle;
    [SerializeField] GameObject ExpParticle;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        healthbar.SetHealth(Health, MaxHealth);
        animator.Play("TakeDamage");

        if (Health <= 0)
        {

            Die();


        }

    }

    public void Die()
    {
        isDead = true;
        animator.Play("Death");
        Destroy(this.gameObject,3f);
    }

    public void Destroy()
    {
         Instantiate(slashParticle,transform.position,Quaternion.identity);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Azazel")
        {
            Destroy();

        }
    }
}
