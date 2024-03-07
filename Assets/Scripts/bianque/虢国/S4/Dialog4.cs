using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog4 : MonoBehaviour
{
    public AudioSource click;
    public GameObject Task_1;
    public GameObject Dialog_zibao;
    public GameObject Chengjiu_1;
    public GameObject Dialog_1;
    public GameObject Dialog_2;

    [Header("�����л�")]
    public string sceneFrom;
    public string sceneTogo;

    public void showChengjiu_1()
    {
        click.Play();
        Task_1.SetActive(false);
        Dialog_zibao.SetActive(false);
        Chengjiu_1.SetActive(true);
    }
    public void hiddenChengjiu_1()
    {
        click.Play();
        Chengjiu_1.SetActive(false);
        Dialog_1.SetActive(true);
    }
    public void nextDialog()
    {
        click.Play();
        Dialog_1.SetActive(false);
        Dialog_2.SetActive(true);
    }
    public void backToStart()
    {
        click.Play();
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
