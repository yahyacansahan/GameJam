using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingEvent : MonoBehaviour
{
    public Transform Fisherman, CamPos;
    [SerializeField] RectTransform CatchArea;
    [SerializeField] Slider slider;
    [SerializeField] Animator animator;
    [SerializeField] FishermanController controller;
    public int Good = 0, Bad = 0;
    bool increase, Fishing;
    // Start is called before the first frame update
    void Awake()
    {
        Fisherman = GameObject.Find("Fisherman").GetComponent<Transform>();
        animator = GameObject.Find("Fisherman").GetComponent<Animator>();
        controller = GameObject.Find("Fisherman").GetComponent<FishermanController>();
        CatchArea = GameObject.Find("CatchArea").GetComponent<RectTransform>();
        slider = GameObject.Find("FishingSlider").GetComponent<Slider>();
        controller.Fishing = true;
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
        if (Input.GetKeyDown(KeyCode.Escape) && Fishing)
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

    public void FishEvent()
    {
        Fishing = true;
        Fisherman.transform.position = new Vector3(4.65f, -2.59f, 5);
        controller.FishermanRB.constraints = RigidbodyConstraints2D.FreezeAll;
        Camera.main.orthographicSize = 2.5f;
        Camera.main.transform.position = new Vector3(Fisherman.position.x, Fisherman.position.y + 0.6f, 0);
        animator.SetBool("Fishing", true);
    }

    public void ExitEvent()
    {
        if (Good >= 3)
        {
            //ödül
        }
        else if (Bad >= 2)
        {
            //ceza 
        }
        Bad = 0;
        Good = 0;
        Fishing = false;
        Camera.main.orthographicSize = 5;
        Camera.main.transform.position = new Vector3(0, 0, 0);
        controller.Fishing = false;
        controller.FishermanRB.constraints = RigidbodyConstraints2D.None;
        controller.FishermanRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.SetActive(false);
    }
}
