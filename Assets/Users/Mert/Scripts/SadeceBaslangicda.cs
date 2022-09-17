using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadeceBaslangicda : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] SadeceBaslangicda baslangic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SonrakiAnimasyon()
    {
        StartCoroutine(acilisdakiAnimBekle());
    }

    IEnumerator acilisdakiAnimBekle()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("Acildi", false);
        baslangic.enabled = false;
    }
}
