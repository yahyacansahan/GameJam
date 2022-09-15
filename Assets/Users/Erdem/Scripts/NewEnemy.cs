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
        
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        healthbar.SetHealth(Health, MaxHealth);
        if (Damage <= 0)
        {

            Die();
                
                }

    }

    public void Die()
    {
        animator.Play("Death");
        isDead = true;

    }

    public void Destroy()
    {
       // Instantiate();

    }
}
