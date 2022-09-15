using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundTrigger : MonoBehaviour
{

 [SerializeField]   UnityEvent OnGround;
  [SerializeField]  UnityEvent OnAir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnGround.Invoke();


        }
        else
        {
            StartCoroutine(CayottteTime());
        }
    }
    IEnumerator CayottteTime()
    {


        yield return new WaitForSeconds(.2f);
        OnAir.Invoke();
    }

}
