using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    private static int nextScene;
    [SerializeField] private Image progressBar;
    public static void LaodScene(int sceneNum)
    {
        nextScene = sceneNum;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProgress());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false; // 페이크 로딩

        float timer = 0f;

        while(!op.isDone)
        {
            yield return null;

            if(op.progress < 0.8f)
            {
                progressBar.fillAmount = op.progress;
            } else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.8f, 1f, timer);
                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }



    }
}
