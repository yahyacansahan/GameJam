using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField]  GameObject hero;
 [SerializeField]   GameObject NighT;

    [SerializeField] public float SmoothSpeed = .125f;
    [SerializeField] Vector3 offset;

    bool ShapeShift = false;
  

    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (ShapeShift)
        {
            Vector3 desiredPosistion = NighT.transform.position + offset;
            Vector3 smoothedPosistion = Vector3.Lerp(transform.position, desiredPosistion, SmoothSpeed);
            transform.position = smoothedPosistion;

        }
        else
        {
            Vector3 desiredPosistion = hero.transform.position + offset;
            Vector3 smoothedPosistion = Vector3.Lerp(transform.position, desiredPosistion, SmoothSpeed);
            transform.position = smoothedPosistion;
        }

        // transform.LookAt(hero.transform.position);


    }
    public void ShapeShiftCamea()
    {
        if (ShapeShift)
        {
            ShapeShift = false;
           

        }
        else
        {
           
            ShapeShift = true;
        }


    }

}
