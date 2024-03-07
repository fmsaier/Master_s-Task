using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSunsimiao : MonoBehaviour
{
    public AudioSource click;
    public string sceneFrom;
    public string sceneTogoYangsheng;
    public string sceneTogoFuru;
    public string sceneTogoYaoji;
    public string sceneTogoYide;
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

    public void Yangsheng()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoYangsheng));
    }
    public void Furu()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoFuru));
    }
    public void Yaoji()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoYaoji));
    }
    public void Yide()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoYide));
    }
    public void backToBowuguan()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoBowuguan));
    }
}
