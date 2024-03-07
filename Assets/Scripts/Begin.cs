using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    public AudioSource click;
    public string sceneFrom;
    public string sceneTogo;

    public void StartGame()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }

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

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }
}
