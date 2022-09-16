using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oK : MonoBehaviour
{
   [SerializeField] float OkSpeed = 3f;
    Rigidbody2D Rbok;
   public float Damage;

    void Awake()
    {
        Rbok = GetComponent<Rigidbody2D>();
      
    }

    public void Fırla(float DEger)
    {
        if (DEger > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        Rbok.velocity = new Vector3(DEger, 0, 0);
        Destroy(this.gameObject, 6f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Combat>().TakeDamage(Damage);
            Destroy(this.gameObject, .1f);

        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);

        }
    }

}
