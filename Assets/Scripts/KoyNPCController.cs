using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoyNPCController : MonoBehaviour
{
    Rigidbody2D NpcRB;
    Animator NpcAnimator;
    Vector3 NpcSize;
    [SerializeField] float NpcSpeed;

    // Start is called before the first frame update
    void Start()
    {
        NpcRB = gameObject.GetComponent<Rigidbody2D>();
        NpcAnimator = gameObject.GetComponent<Animator>();
        NpcSize = transform.localScale;

        StartCoroutine(Walk());
    }

    private void FixedUpdate()
    {
        if (NpcRB.velocity.x < -0.1f)
        {
            gameObject.transform.localScale = new Vector3(NpcSize.x, NpcSize.y, NpcSize.z);
        }
        else if (NpcRB.velocity.x > 0.1f)
        {
            gameObject.transform.localScale = new Vector3(-NpcSize.x, NpcSize.y, NpcSize.z);
        }
    }

    IEnumerator Walk()
    {
        float rand = Random.Range(-1, 1);
        NpcAnimator.SetBool("Walk", true);
        if (rand < 0)
        {
            NpcRB.velocity = new Vector2(-NpcSpeed, 0);
        }
        else
        {
            NpcRB.velocity = new Vector2(NpcSpeed, 0);
        }
        float randWalkTime = Random.Range(2, 4);
        yield return new WaitForSeconds(randWalkTime);
        NpcAnimator.SetBool("Walk", false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        NpcRB.velocity = new Vector2(0, 0);
        float randWaitTime = Random.Range(2.5f, 5);
        yield return new WaitForSeconds(randWaitTime);
        StartCoroutine(Walk());
    }

}
