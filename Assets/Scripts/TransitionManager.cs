using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public string startScene; // ��ʼ����

    public CanvasGroup fadeCanvasGroup; // ���Panels�ı���
    public float fadeDuration; // �����л���ʱ��
    private bool isFade; // �ж��Ƿ������л�����

    private void Start()
    {
        // ͨ��Э�̼��س�ʼ����
        StartCoroutine(TransitionToScene(string.Empty, startScene));
    }

    // �л�����
    public void Transition(string from, string to)
    {
        // ����������ڳ����л�����ôִ��Э��
        if (!isFade)
        {
            StartCoroutine(TransitionToScene(from, to));
        }
    }

    // Э�̷���
    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1); // �����л����ǰΪȫ��
                              // ��ִ��������ĲŻ�ִ����������
                              // �����Ҫͬʱִ�У����Խ�����Ĵ����޸�ΪstartCoroutine

        // ����е�һ���������Ż�ִ��ж�صĶ���������ֱ�Ӽ��ؼ���
        if (from != string.Empty)
        {
            yield return SceneManager.UnloadSceneAsync(from); // ж�س���
        }

        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); // �Լ���ķ�ʽ���س���

        // �����³���Ϊ�����
        // ��ʱ������һ�����������������Ϊ0��1��ͨ������-1�Ӷ��ҵ��¼��صĳ���
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        yield return Fade(0); // ����ִ����Ϻ�Ϊ͸��
    }

    /// <summary>
    /// ���뽥��Ч��
    /// </summary>
    /// <param name="targetAlpha">1�Ǻڣ�0��͸��</param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;

        fadeCanvasGroup.blocksRaycasts = true; // ��ӦPanels��CanvasGroup������

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        // �������ֵ�����ƣ���ô������ֵ��ΪĿ��ֵ
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null; // ����ִ��ѭ��
        }

        fadeCanvasGroup.blocksRaycasts = false; // ��ӦPanels��CanvasGroup������
        isFade = false;
    }
}
