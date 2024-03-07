using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogQianyiDu : MonoBehaviour
{
    public AudioSource click;
    public GameObject dialogQueren;
    public GameObject dialogWrong;
    public GameObject Chengjiu;
    public GameObject Task;

    [Header("��ɫ")]
    public GameObject playerXin;
    public GameObject playerGan;
    public GameObject playerPi;
    public GameObject playerFei;
    public GameObject playerShen;

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

    public void Right_Xin()
    {
        click.Play();
        playerXin.SetActive(false);
        playerGan.SetActive(true);
        Time.timeScale = 1f;
        dialogQueren.SetActive(false);
    }
    public void Right_Gan()
    {
        click.Play();
        playerGan.SetActive(false);
        playerPi.SetActive(true);
        Time.timeScale = 1f;
        dialogQueren.SetActive(false);
    }
    public void Right_Pi()
    {
        click.Play();
        playerPi.SetActive(false);
        playerFei.SetActive(true);
        Time.timeScale = 1f;
        dialogQueren.SetActive(false);
    }
    public void Right_Fei()
    {
        click.Play();
        playerFei.SetActive(false);
        playerShen.SetActive(true);
        Time.timeScale = 1f;
        dialogQueren.SetActive(false);
    }
    public void Right_Shen()
    {
        click.Play();
        playerShen.SetActive(false);
        Task.SetActive(false);
        Chengjiu.SetActive(true);
        dialogQueren.SetActive(false);
    }
    public void Wrong()
    {
        click.Play();
        dialogQueren.SetActive(false);
        dialogWrong.SetActive(true);
    }
    public void afterWrong()
    {
        click.Play();
        dialogWrong.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GoOn()
    {
        click.Play();
        dialogQueren.SetActive(false);
        Time.timeScale = 1f;
    }
    public void backToStart()
    {
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }
}
