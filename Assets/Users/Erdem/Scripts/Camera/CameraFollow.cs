using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Controller hero;

    [SerializeField] public float SmoothSpeed = .125f;
    [SerializeField] Vector3 offset;

    void Start()
    {
        hero = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosistion = hero.transform.position + offset;
        Vector3 smoothedPosistion = Vector3.Lerp(transform.position, desiredPosistion, SmoothSpeed);
        transform.position = smoothedPosistion;

        // transform.LookAt(hero.transform.position);


    }
}
