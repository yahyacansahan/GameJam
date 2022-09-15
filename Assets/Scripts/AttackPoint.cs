using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    Combat combat;

    private void Start()
    {
        if(GameObject.Find("Player"))
        {
            combat = GameObject.Find("Player").GetComponent<Combat>();
        }      
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            combat.EnemyInCollider = true;
        }
        else
        {
            combat.EnemyInCollider = false;
        }
    }
}
