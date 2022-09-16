using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingThings : MonoBehaviour
{
    [SerializeField] GameObject LoadObject;
    [SerializeField] GameObject OffObject;


    public void LoadNewObje()
    {
        LoadObject.SetActive(true);
        OffObject.SetActive(false);
    }


}
