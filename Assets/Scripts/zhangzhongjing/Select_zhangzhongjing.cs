using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_zhangzhongjing : MonoBehaviour
{
    public AudioSource click;
    public string sceneFrom;
    public string sceneTogoLuan;
    public string sceneTogoWei;
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

    public void Luanshilizhi()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoLuan));
    }
    public void Weirenyifeng()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoWei));
    }
    public void backToBowuguan()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoBowuguan));
    }
}
