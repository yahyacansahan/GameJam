using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform takipEdilecekObje;
    Vector3 aradakiMesafe;

    private void Start()
    {
        aradakiMesafe = new Vector3(takipEdilecekObje.position.x - transform.position.x, takipEdilecekObje.position.y - takipEdilecekObje.position.y - transform.position.y,takipEdilecekObje.position.z - transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(takipEdilecekObje.position.x + aradakiMesafe.x, takipEdilecekObje.position.y + aradakiMesafe.y,takipEdilecekObje.position.z + transform.position.z);
    }
}
