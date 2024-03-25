using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDiCiWangPYP : MonoBehaviour
{
    public DiCiWangPYP DiCiWang;
    public NumberDisplayGame1PYP NumberDisplayGame1;

    private bool canDestroy = true; // �����Ƿ���Դݻ�����

    void Start()
    {
        DiCiWang = FindObjectOfType<DiCiWangPYP>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canDestroy && other.CompareTag("Player"))
        {
            canDestroy = false; // ȡ����ײ��⣬�����ٴδ���

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

            StartCoroutine(DelayedDestroy(0.02f)); // ����Э���ӳٴݻ�
        }
    }

    IEnumerator DelayedDestroy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // �ȴ�ָ��ʱ��
        Destroy(gameObject); // �ӳٴݻ�����
    }
}