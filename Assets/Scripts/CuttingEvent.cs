using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingEvent : MonoBehaviour
{
    public Transform WoodCutter;
    SaveSystem saveSystem;
    PlayerData playerData;
    [SerializeField] RectTransform CatchArea;
    [SerializeField] Slider slider;
    [SerializeField] Animator animator, treeAnimator;
    [SerializeField] WoodCutterController controller;
    public int Good = 0, Bad = 0;
    bool increase, Cutting;
    // Start is called before the first frame update
    void Awake()
    {
        WoodCutter = GameObject.Find("WoodCutter").GetComponent<Transform>();
        animator = GameObject.Find("WoodCutter").GetComponent<Animator>();
        treeAnimator = GameObject.Find("CutTree").GetComponent<Animator>();
        controller = GameObject.Find("WoodCutter").GetComponent<WoodCutterController>();
        CatchArea = GameObject.Find("CatchArea").GetComponent<RectTransform>();
        slider = GameObject.Find("CuttingSlider").GetComponent<Slider>();
        saveSystem = GameObject.Find("SaveSystem").GetComponent<SaveSystem>();
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();
        controller.Cutting = true;
        saveSystem.Load();
        Bad = 0;
        Good = 0;
    }

    private void FixedUpdate()
    {
        SliderMove();
    }
    private void Update()
    {
        KeyEvent();
    }

    void KeyEvent()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Cutting)
        {
            ExitEvent();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Catch();
        }
    }

    void Catch()
    {
        if (slider.value * 130 / 100 > CatchArea.anchoredPosition.x - 15 - 10 && slider.value * 130 / 100 < CatchArea.anchoredPosition.x - 15 + 10)
        {
            animator.Play("Attack");
            Good++;
            RandomCatchArea();
        }
        else
        {
            Bad++;
        }

        if (Good >= 3 || Bad >= 2)
        {
            ExitEvent();
        }
    }

    public void TreeSmashAnimation()
    {
        treeAnimator.Play("WoodAttack");
    }

    void RandomCatchArea()
    {
        float rand = Random.Range(15, 145);
        CatchArea.anchoredPosition = new Vector3(rand, 0, 1);
    }

    void SliderMove()
    {
        if (slider.value >= 99)
        {
            increase = false;
        }
        else if (slider.value <= 1)
        {
            increase = true;
        }

        if (increase)
        {
            slider.value += 1 + (Good);
        }
        else
        {
            slider.value -= 1 + (Good);
        }
    }

    public void CutEvent()
    {
        Cutting = true;
        WoodCutter.transform.position = new Vector3(2.13f, -1.85f, 5);
        controller.WoodCutterRB.constraints = RigidbodyConstraints2D.FreezeAll;
        Camera.main.orthographicSize = 2.5f;
        Camera.main.transform.position = new Vector3(WoodCutter.position.x, WoodCutter.position.y + 0.6f, -10);
        animator.SetBool("Fishing", true);
    }

    public void ExitEvent()
    {
        if (Good >= 3)
        {
            if (playerData.Suphe - 30 < 0)
            {
                playerData.Suphe = 0;
            }
            else
            {
                playerData.Suphe -= 30;
            }
        }
        else if (Bad >= 2)
        {
            if (playerData.Suphe + 30 > 100)
            {
                //GameOver
            }
            else
            {
                playerData.Suphe += 30;
            }
        }
        Bad = 0;
        Good = 0;
        Cutting = false;
        Camera.main.orthographicSize = 5;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        controller.Cutting = false;
        controller.WoodCutterRB.constraints = RigidbodyConstraints2D.None;
        controller.WoodCutterRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.SetActive(false);
        saveSystem.Save();
    }
}
