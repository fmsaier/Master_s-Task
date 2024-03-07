using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectQianyi : MonoBehaviour
{
    public AudioSource click;
    public string sceneFrom;
    public string sceneTogoWu;
    public string sceneTogoDu;
    public string sceneTogoPi;
    public string sceneTogoBowuguan;

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

    public void Wu()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoWu));
    }
    public void Du()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoDu));
    }
    public void Pi()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoPi));
    }
    public void backToBowuguan()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoBowuguan));
    }
}
