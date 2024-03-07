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

    // 协程方法
    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); // 以激活的方式加载场景
        // 设置新场景为激活场景
        // 此时场景中一共有两个场景，序号为0与1，通过数量-1从而找到新加载的场景
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        yield return SceneManager.UnloadSceneAsync(from); // 卸载场景      
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
