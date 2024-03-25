using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDiCiWangPYP : MonoBehaviour
{
    public DiCiWangPYP DiCiWang;
    public NumberDisplayGame1PYP NumberDisplayGame1;

    private bool canDestroy = true; // 控制是否可以摧毁物体

    void Start()
    {
        DiCiWang = FindObjectOfType<DiCiWangPYP>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canDestroy && other.CompareTag("Player"))
        {
            canDestroy = false; // 取消碰撞检测，避免再次触发

            Transform firstChild = transform.GetChild(0);
            firstChild.gameObject.SetActive(true);

            AudioSource audioSource = GetComponentInChildren<AudioSource>();
            audioSource.playOnAwake = true;
            if (audioSource != null)
            {
                audioSource.Play();
            }

            NumberDisplayGame1.Number += 1;
            WholePYP.Game2PYP += 1;
            DiCiWang.SpawnPrefab();

            StartCoroutine(DelayedDestroy(0.02f)); // 启动协程延迟摧毁
        }
    }

    IEnumerator DelayedDestroy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // 等待指定时间
        Destroy(gameObject); // 延迟摧毁物体
    }
}