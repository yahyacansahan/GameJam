using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SureliGecis : MonoBehaviour
{
    string girisYapilanKutu;
    //[SerializeField] string loadingSceneName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bekleBiraz());
    }

    IEnumerator bekleBiraz()
    {
        girisYapilanKutu = PlayerPrefs.GetString("girisYapildi");
        Debug.Log(PlayerPrefs.GetString("girisYapildi") + " " + PlayerPrefs.GetString(girisYapilanKutu));
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(PlayerPrefs.GetString(girisYapilanKutu));
    }
}
