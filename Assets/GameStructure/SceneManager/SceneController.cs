using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Image loadingBar; // 进度条UI元素
    public float transitionDuration = 1.0f; // 过渡时间

    private bool isLoading = false;

    public void LoadScene(string sceneName)
    {
        if (!isLoading)
        {
            StartCoroutine(LoadSceneAsyncWithTransition(sceneName));
        }
    }
    
    private IEnumerator LoadSceneAsyncWithTransition(string sceneName)
    {
        isLoading = true;

        // 播放过渡动画或更新进度条
        float timer = 0f;
        while (timer < transitionDuration)
        {
            // 计算进度（0到1之间）
            float progress = timer / transitionDuration;

            // 更新进度条（假设进度条填充从左到右）
            loadingBar.fillAmount = progress;

            // 增加时间
            timer += Time.deltaTime;

            yield return null; // 等待一帧
        }

        // 最终设为1确保进度条填满
        loadingBar.fillAmount = 1.0f;

        // 异步加载新场景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 阻止加载新场景时自动切换
        asyncLoad.allowSceneActivation = false;

        // 等待场景加载完成
        while (!asyncLoad.isDone)
        {
            // 计算加载进度
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // 进度范围从0到0.9

            // 更新进度条
            loadingBar.fillAmount = progress;

            // 如果加载完成，激活新场景
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null; // 等待一帧
        }

        isLoading = false;
    }
}