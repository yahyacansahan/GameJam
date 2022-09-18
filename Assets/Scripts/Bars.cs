using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    Slider HealthBar, StaminaBar, SupheBar;
    PlayerData playerData;
    [SerializeField] GameObject GameOverGO;
    Animator animator;
    public float Health, Stamina, Suphe;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("SupheBar"))
        {
            SupheBar = GameObject.Find("SupheBar").GetComponent<Slider>();
        }
        HealthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        StaminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();
        if (GameObject.Find("Player"))
        {
            animator = GameObject.Find("Player").GetComponent<Animator>();
        }

        Health = playerData.Health;
        HealthBar.maxValue = Health;
        Stamina = playerData.Stamina;
        StaminaBar.maxValue = Stamina;
        StaminaBar.value = Stamina;


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
        CalculateHealth();
    }

    void CalculateHealth()
    {
        if (Health > 0)
        {
            HealthBar.value = Health;
        }
        else
        {
          //  animator.Play("Death");
        }
    }

    public void CalculateSuphe()
    {
        Suphe = playerData.Suphe;

        if (Suphe <= 0)
        {
            Suphe = 0;
        }
        else if (Suphe >= 100)
        {
            Debug.Log("girdi");
            Suphe = 100;
            GameOverGO.SetActive(true);
        }
        SupheBar.value = Suphe;
    }
}
