using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int CurrentDay;
    public float Health, Stamina;
    // Start is called before the first frame update
    void Awake()
    {
        Stamina = 100;
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float Damage)
    {
        Health -= Damage;
        Debug.Log("DamageYedim Ahhh");
    }


}
