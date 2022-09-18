using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SureliGecis : MonoBehaviour
{
    public PlayerData playerData;
    public SaveSystem system;
    //[SerializeField] string loadingSceneName;
    // Start is called before the first frame update
    void Start()
    {
        system.Load();
        StartCoroutine(bekleBiraz());
    }

    IEnumerator bekleBiraz()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Level-" + playerData.Level); ;
    }
}
