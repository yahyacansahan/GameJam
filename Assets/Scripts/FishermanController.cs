using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishermanController : MonoBehaviour
{
    public Rigidbody2D FishermanRB;
    [SerializeField] GameObject FishingEventGO;
    Animator animator;
    [SerializeField] float MovementSpeed;
    public bool Fishing;

    // Start is called before the first frame update
    void Start()
    {
        FishermanRB = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyEvent();
        Checker();
    }

    void Checker()
    {
        if ((FishermanRB.velocity.x < -0.3f || FishermanRB.velocity.x > 0.3f) )
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void KeyEvent()
    {
        if(!Fishing)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {

                FishermanRB.velocity = new Vector2(MovementSpeed, FishermanRB.velocity.y);

                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                FishermanRB.velocity = new Vector2(-MovementSpeed, FishermanRB.velocity.y);

                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (!(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
            {
                FishermanRB.velocity = new Vector2(0, FishermanRB.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                FishingEventGO.SetActive(true);
            }
        }   
    }

}
