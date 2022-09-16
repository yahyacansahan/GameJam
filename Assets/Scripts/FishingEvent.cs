using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingEvent : MonoBehaviour
{
    public Transform Fisherman, CamPos, tempCamPos;
    [SerializeField] Camera cam;
    [SerializeField] Transform CatchArea;
    [SerializeField] Slider slider;
    [SerializeField] Animator animator;
    [SerializeField] FishermanController controller;
    public int Good = 0, Bad = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Fisherman = GameObject.Find("Fisherman").GetComponent<Transform>();
        animator = GameObject.Find("Fisherman").GetComponent<Animator>();
        controller = GameObject.Find("Fisherman").GetComponent<FishermanController>();
        CatchArea = GameObject.Find("CatchArea").GetComponent<Transform>();
        cam = Camera.main;
        CamPos = Camera.main.transform;
        slider = GameObject.Find("FishingSlider").GetComponent<Slider>();
        FishEvent();
        controller.Fishing = true;
    }

    private void FixedUpdate()
    {
        SliderMove();
        KeyEvent();
    }

    void KeyEvent()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        if (slider.value * 130 / 100 > CatchArea.position.x - 10 || slider.value * 130 / 100 < CatchArea.position.x + 10)
        {
            Good++;
            RandomCatchArea();
        }
        else
        {
            Bad++;
        }
    }

    void RandomCatchArea()
    {
        float rand = Random.Range(-63, 63);
        CatchArea.position = new Vector3(rand, CatchArea.position.y, CatchArea.position.z);
    }

    void SliderMove()
    {
        if (slider.value >= 100)
        {
            slider.value -= 0.2f;
        }
        else if (slider.value < 0)
        {
            slider.value -= 0.2f;
        }
    }

    public void FishEvent()
    {
        Fisherman.transform.position = new Vector3(4.65f, -2.59f, 5);
        controller.FishermanRB.constraints = RigidbodyConstraints2D.FreezeAll;
        cam.orthographicSize /= 2;
        tempCamPos = CamPos;
        Camera.main.transform.position = new Vector3(Fisherman.position.x, Fisherman.position.y + 0.6f, 0);
        animator.SetBool("Fishing", true);
    }

    public void ExitEvent()
    {
        cam.orthographicSize *= 2;
        CamPos = tempCamPos;
        controller.Fishing = false;
        controller.FishermanRB.constraints = RigidbodyConstraints2D.None;
        controller.FishermanRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.SetActive(false);
    }
}
