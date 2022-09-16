using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Transform PlayerTransform;
    Rigidbody2D FireBallRB;
    Combat combat;

    [SerializeField] float Speed, Damage,DestroySeconds;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        combat = GameObject.Find("Player").GetComponent<Combat>();
        FireBallRB = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, DestroySeconds);
        Move();
    }

    void Move()
    {
        FireBallRB.velocity = new Vector2(Speed * PlayerTransform.localScale.x, 0);
    }

    void DestroyGO()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            DestroyGO();
        }
        else if (collision.tag == "Enemy")
        {
            collision.GetComponent<NewEnemy>().TakeDamage(Damage);
            combat.Attack();
            DestroyGO();
        }
    }
}
