using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteStart : MonoBehaviour
{
    public GameObject StartMemu;
    public GameObject Others;

    [Header("�����л�")]
    public string sceneFrom;
    public string sceneTogo;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Init()
    {
        Time.timeScale = 1f;
        StartMemu.SetActive(false);
        Others.SetActive(true);
    }
    public void gotoScene()
    {
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }
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
}
