using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog_hautuo_mafeisan : MonoBehaviour
{
    public AudioSource click;

    public GameObject dialog_tishi;
    public GameObject Timeline;
    public GameObject Task;

    [Header("�����л�")]
    public string sceneFrom;
    public string sceneTogo;

    // Э�̷���
    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); // �Լ���ķ�ʽ���س���
        // �����³���Ϊ�����
        // ��ʱ������һ�����������������Ϊ0��1��ͨ������-1�Ӷ��ҵ��¼��صĳ���
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        yield return SceneManager.UnloadSceneAsync(from); // ж�س���      
    }

    public void Begin()
    {
        click.Play();
        dialog_tishi.SetActive(false);
        Timeline.SetActive(true);
        Task.SetActive(true);
    }
    public void again()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneFrom));
    }
    public void backToStart()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }
}
