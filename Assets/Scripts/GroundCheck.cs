using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Collider2D GroundCollider;
    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        GroundCollider = gameObject.GetComponent<Collider2D>();
        controller = GameObject.Find("Player").GetComponent<Controller>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            controller.isGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            controller.isGround = false;
        }
    }
}
