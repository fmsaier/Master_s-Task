using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectBianque : MonoBehaviour
{
    public AudioSource click;
    public string sceneFrom;
    public string sceneTogoGuo;
    public string sceneTogoWei;
    public string sceneTogoJin;
    public string sceneTogoQi;
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

    public void Guo()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoGuo));
    }
    public void Wei()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoWei));
    }
    public void Jin()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoJin));
    }
    public void Qi()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoQi));
    }
    public void backToBowuguan()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoBowuguan));
    }
}
