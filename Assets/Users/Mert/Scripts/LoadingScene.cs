using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    private void Start()
    {
        LoadLevel("Level1ME");
    }

    public void LoadLevel(string name)
    {
        StartCoroutine(LoadTheScene(name));
    }

    IEnumerator LoadTheScene(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
