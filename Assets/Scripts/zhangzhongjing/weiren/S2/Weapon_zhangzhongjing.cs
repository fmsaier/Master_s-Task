using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_zhangzhongjing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject zhongcaoyaoPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shootzhongcaoyao();
        }
    }

    void Shootzhongcaoyao()
    {
        // �������ס�����Ķ����Լ�λ��
        Instantiate(zhongcaoyaoPrefab, firePoint.position, firePoint.rotation);
    }
}
