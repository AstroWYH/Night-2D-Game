using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class transitionmgr : singleton<transitionmgr>
{
    public string startSceneName = string.Empty;
    private CanvasGroup fadeCanvasGroup;
    private bool isFade;

    protected override void Awake()
    {
        base.Awake();
        //Screen.SetResolution(1920, 1080, FullScreenMode.Windowed, 0);
        SceneManager.LoadScene("ui", LoadSceneMode.Additive);
    }

    private void Start()
    {
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
    }

    private void OnEnable()
    {
        eventhandler.TransitionEvent += OnTransitionEvent;
    }

    private void OnDisable()
    {
        eventhandler.TransitionEvent -= OnTransitionEvent;
    }

    private void OnTransitionEvent(string sceneToGo, Vector3 positionToGo)
    {
        if (!isFade)
            StartCoroutine(Transition(sceneToGo, positionToGo));
    }

    private IEnumerator Transition(string sceneName, Vector3 targetPosition)
    {
        eventhandler.CallBeforeSceneUnloadEvent();
        // note: 逐渐变黑；暂停，直到Fade()执行完再继续
        yield return Fade(1);

        // note: 暂停，直到UnloadSceneAsync卸载完再继续
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return LoadSceneSetActive(sceneName);
        //移动人物坐标
        eventhandler.CallMoveToPosition(targetPosition);
        eventhandler.CallAfterSceneLoadedEvent();
        // note: 逐渐变亮；暂停，直到Fade()执行完再继续
        yield return Fade(0);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;

        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / Settings.fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;
    }

    private IEnumerator LoadSceneSetActive(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

        SceneManager.SetActiveScene(newScene);
    }
}
