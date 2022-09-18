using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();

        if (GameObject.Find("SupheBar"))
        {
            SupheBar = GameObject.Find("SupheBar").GetComponent<Slider>();
        }
        if (GameObject.Find("HealthBar"))
        {
            HealthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
            Health = playerData.Health;
            HealthBar.maxValue = Health;
        }
        if (GameObject.Find("StaminaBar"))
        {
            StaminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
            Stamina = playerData.Stamina;
            StaminaBar.maxValue = Stamina;
            StaminaBar.value = Stamina;
        }
        if (GameObject.Find("Player"))
        {
            animator = GameObject.Find("Player").GetComponent<Animator>();
        }
        CalculateSuphe();
    }

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Level-1" || SceneManager.GetActiveScene().name == "Level-2" || SceneManager.GetActiveScene().name == "Level-3" || SceneManager.GetActiveScene().name == "Level-4" || SceneManager.GetActiveScene().name == "Level-5")
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
            StartCoroutine(GameOver());
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

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        GameOverGO.SetActive(true);
    }
}
