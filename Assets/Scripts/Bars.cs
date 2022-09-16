using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    Slider HealthBar, StaminaBar;
    public float Health = 100, Stamina;
    // Start is called before the first frame update
    void Start()
    {
      //  HealthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
       // StaminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
    }

    void FixedUpdate()
    {
      /*
        if (Stamina < 100)
        {
            Stamina += 0.1f;
            StaminaBar.value = Stamina;
        }
        else
        {
            Stamina = 100;
        }*/
    }

    void CalculateHealth()
    {
        if (Health > 0)
        {
            HealthBar.value = Health;
        }
        else
        {
            //gameOver penceresi açýlacak
        }
    }
}
