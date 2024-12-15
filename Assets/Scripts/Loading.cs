using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scene
{
    Title,
    Game
}

public class Loading : Singleton<Loading>
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Image fillImage;

    [SerializeField]
    private float fakeLoadingTime = 1f;

    private void Awake() => Initialize(this);

    public void LoadScene(Scene targetScene)
    {
        canvas.enabled = true;

        StartCoroutine(LoadAsync(targetScene));
    }

    private IEnumerator LoadAsync(Scene targetScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)targetScene);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;

            if (operation.progress < 0.9f)
            {
                continue;
            }

            float timer = 0f;

            while (timer < fakeLoadingTime)
            {
                float amount = Mathf.Lerp(0.9f, 1f, timer / fakeLoadingTime);

                fillImage.fillAmount = amount;

                timer += Time.unscaledDeltaTime;

                yield return null;
            }

            canvas.enabled = false;

            operation.allowSceneActivation = true;

            yield break;
        }
    }
}
