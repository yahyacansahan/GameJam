using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SahneGecirici : MonoBehaviour
{
    [SerializeField] string sahne;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           if( Input.GetKey(KeyCode.E)){
                SceneManager.LoadScene(sahne);

            }

        }
    }

}
