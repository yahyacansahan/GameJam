using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WallTrigger : MonoBehaviour
{

 [SerializeField]   UnityEvent SideOFWall;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            SideOFWall.Invoke();


        }
    }

}
