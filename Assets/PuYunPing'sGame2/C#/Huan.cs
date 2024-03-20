using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuanPYP : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private int Ci;
    public PlayerGame2PYP PlayerGame2;
    public NumberDisplayGame1PYP NumberDisplayGame1;
    private void Start()
    {
        Ci = 0;
        EnableRandomChildren(transform.GetChild(0).GetChild(0), 5);
        PlayerGame2 = GetComponent<PlayerGame2PYP>();
        NumberDisplayGame1 = FindObjectOfType<NumberDisplayGame1PYP>();
    }

    void Update()
    {
        float rotationAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationAmount);
    }

    public void PanDing()
    {
        Ci += 1;
        StartCoroutine(DisableThenEnable());
    }


    IEnumerator DisableThenEnable()
    {
        DisableAllChildren(transform.GetChild(0).GetChild(0));
        yield return new WaitForSeconds(0.1f);

        if (NumberDisplayGame1.Number >= 10)
        {
            EnableRandomChildren(transform.GetChild(0).GetChild(0), 10);
        }
        else
        {
            EnableRandomChildren(transform.GetChild(0).GetChild(0), 5);
        }
    }

    void DisableAllChildren(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }

    void EnableRandomChildren(Transform parent, int count)
    {
        // ��ȡ����������
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            children.Add(child);
        }

        // �������ָ��������������
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, children.Count);
            GameObject childObject = children[randomIndex].gameObject;

            // ����������
            childObject.SetActive(true);
            children.RemoveAt(randomIndex);
        }
    }
}