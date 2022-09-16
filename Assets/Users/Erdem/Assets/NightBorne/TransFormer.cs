using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransFormer : MonoBehaviour
{
    [SerializeField] GameObject Go1, Go2;
    bool Situation = true;
    [SerializeField] CameraFollow Camera;
    [SerializeField] GameObject Blast;
    void Start()
    {
        Camera = FindObjectOfType<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShapeShift()
    {
        if (Situation)
        {
            Go1.SetActive(false);

            Go2.SetActive(true);
            Go2.transform.position = Camera.transform.position + Vector3.up * 2f;
            Instantiate(Blast, Camera.transform.position , Quaternion.identity);

            Situation = false;
            Camera.GetComponent<CameraFollow>().ShapeShiftCamea();

        }
        else
        {
            Go1.SetActive(true);
            Go1.transform.position = Camera.transform.position+Vector3.up*2f;
            Instantiate(Blast, Camera.transform.position + Vector3.up * 2f, Quaternion.identity);
            Go2.SetActive(false);
            Situation = true;
            Camera.GetComponent<CameraFollow>().ShapeShiftCamea();

        }
      

    }

}
