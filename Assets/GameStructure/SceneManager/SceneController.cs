using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Image loadingBar; // progress bar UI element
    public float transitionDuration = 1.0f; // progress bar fill duration

    private bool isLoading = false;

    public void LoadScene(string sceneName)
    {
        if (!IsSceneInBuildSettings(sceneName))
        {
            Debug.LogWarning("The Scene you are trying to load doesn't exist! Please double check!");
            return;
        }
        
        if (!isLoading)
        {
            StartCoroutine(LoadSceneAsyncWithTransition(sceneName));
        }
    }
    
    private IEnumerator LoadSceneAsyncWithTransition(string sceneName)
    {
        isLoading = true;

        // play transition animation here
        float timer = 0f;
        while (timer < transitionDuration)
        {
            // calculate progress ranges from 0 to 1
            float progress = timer / transitionDuration;

            // update progress bar (fill amount ranges from 0 to 1 assume the progress bar is a horizontal bar)
            loadingBar.fillAmount = progress;

            // add time
            timer += Time.deltaTime;

            yield return null; // wait for a frame
        }

        // ensure the progress bar is filled
        loadingBar.fillAmount = 1.0f;

        // load scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // prevent the scene from activating when loading is complete
        asyncLoad.allowSceneActivation = false;

        // wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            // calculate the progress
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // 0.9f is the maximum progress value

            // update progress bar
            loadingBar.fillAmount = progress;

            // if the loading is almost done, allow the scene to activate
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null; // wait for a frame
        }

        isLoading = false;
    }
    
    public static bool IsSceneInBuildSettings(string sceneName) //check if the scene exists. Return false if it doesn't
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameInBuild = System.IO.Path.GetFileNameWithoutExtension(scenePath);
    
            if (sceneNameInBuild.Equals(sceneName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}