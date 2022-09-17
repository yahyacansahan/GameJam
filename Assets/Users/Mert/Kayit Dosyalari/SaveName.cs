using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public void ClickSaveButton(string hangikutu, string name)
    {
        PlayerPrefs.SetString(hangikutu, name);
        Debug.Log("Your level " + PlayerPrefs.GetString(hangikutu));
    }

    public void ResetingLevel(string hangikutu)
    {
        PlayerPrefs.SetString(hangikutu, "Level-1");
    }
}
