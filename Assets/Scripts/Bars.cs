using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    Slider HealthBar, StaminaBar;
    PlayerData playerData;
    Animator animator;
    public float Health, Stamina;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        StaminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        animator = GameObject.Find("Player").GetComponent<Animator>();

        Health = playerData.Health;
        HealthBar.maxValue = Health;
        Stamina = playerData.Stamina;
        StaminaBar.maxValue = Stamina;
        StaminaBar.value = Stamina;

        CalculateHealth();
    }

    void FixedUpdate()
    {
        if (Stamina < 100)
        {
            Stamina += 0.1f;
            StaminaBar.value = Stamina;
        }
        else
        {
            Stamina = 100;
        }
    }

    void CalculateHealth()
    {
        if (Health > 0)
        {
            HealthBar.value = Health;
        }
        else
        {
            animator.Play("Death");
        }
    }
}
