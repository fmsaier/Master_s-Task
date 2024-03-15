using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public AudioSource click;
    public GameObject Dialog_1;
    public GameObject Dialog_2;
    public GameObject Dialog_3;
    public GameObject Dialog_4;
    public GameObject Dialog_5;
    public GameObject Dialog_6;
    public GameObject Dialog_7;
    public GameObject Dialog_8;
    public GameObject Dialog_9;
    public GameObject Dialog_10;

    [Header("�����л�")]
    public string sceneFrom;
    public string sceneTogo;

    public void nextDialog_1()
    {
        click.Play();
        Dialog_1.SetActive(false);
        Dialog_2.SetActive(true);
    }
    public void nextDialog_2()
    {
        click.Play();
        Dialog_2.SetActive(false);
        Dialog_3.SetActive(true);
    }
    public void nextDialog_3()
    {
        click.Play();
        Dialog_3.SetActive(false);
        Dialog_4.SetActive(true);
    }
    public void nextDialog_4()
    {
        click.Play();
        Dialog_4.SetActive(false);
        Dialog_5.SetActive(true);
    }
    public void nextDialog_5()
    {
        click.Play();
        Dialog_5.SetActive(false);
        Dialog_6.SetActive(true);
    }
    public void nextDialog_6()
    {
        click.Play();
        Dialog_6.SetActive(false);
        Dialog_7.SetActive(true);
    }
    public void nextDialog_7()
    {
        click.Play();
        Dialog_7.SetActive(false);
        Dialog_8.SetActive(true);
    }
    public void nextDialog_8()
    {
        click.Play();
        Dialog_8.SetActive(false);
        Dialog_9.SetActive(true);
    }
    public void nextDialog_9()
    {
        click.Play();
        Dialog_9.SetActive(false);
        Dialog_10.SetActive(true);
    }
    public void nextScene()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }
    public GameObject destroy;
    public void DestroyIt()
    {
        if (destroy != null)
        {
            Destroy(destroy);
        }
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
