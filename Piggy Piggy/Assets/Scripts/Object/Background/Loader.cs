using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    private bool loadScene = false;
    public string LoadingSceneName;
    public Text loadingText;
    public Slider sliderBar;
	// Use this for initialization
	void Start () {
        sliderBar.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) && loadScene == false)
        {
            StartCoroutine("SomeDelay");
            loadScene = true;
            sliderBar.gameObject.SetActive(true);
            StartCoroutine(LoadNewScene(LoadingSceneName));
        }
	}
    IEnumerator SomeDelay()
    {
        yield return new WaitForSeconds(5);
    }
    IEnumerator LoadNewScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            yield return null;
        }
    }
}
