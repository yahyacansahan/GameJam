using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WoodCutterController : MonoBehaviour
{
    public Rigidbody2D WoodCutterRB;
    Animator animator;
    SaveSystem saveSystem;
    PlayerData playerData;
    [SerializeField] CuttingEvent cuttingEvent;
    public bool Cutting, canCutting, goVillage;
    [SerializeField] float MovementSpeed;
    [SerializeField] GameObject CuttingEventGO;
    // Start is called before the first frame update
    void Start()
    {
        WoodCutterRB = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        saveSystem = GameObject.Find("SaveSystem").GetComponent<SaveSystem>();
        playerData = GameObject.Find("SaveSystem").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        Checker();
        KeyEvent();
    }

    void Checker()
    {
        if ((WoodCutterRB.velocity.x < -0.3f || WoodCutterRB.velocity.x > 0.3f))
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void KeyEvent()
    {
        if (!Cutting)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                WoodCutterRB.velocity = new Vector2(MovementSpeed, WoodCutterRB.velocity.y);

                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                WoodCutterRB.velocity = new Vector2(-MovementSpeed, WoodCutterRB.velocity.y);

                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (!(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
            {
                WoodCutterRB.velocity = new Vector2(0, WoodCutterRB.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.E) )
            {
                if (canCutting && playerData.CuttingEvent == 0)
                {
                    CuttingEventGO.SetActive(true);
                    CuttingEventGO.GetComponent<CuttingEvent>().CutEvent();
                }
                else if (goVillage)
                {
                    SceneManager.LoadScene("Köyleveli");
                }
            }
        }
    }

    public void TreeAnimation()
    {
        cuttingEvent.TreeSmashAnimation();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Fishing")
        {
            canCutting = true;
        }
        if (collision.tag == "goVillage")
        {
            goVillage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fishing")
        {
            canCutting = false;
        }
        if (collision.gameObject.tag == "goVillage")
        {
            goVillage = false;
        }
    }
}
