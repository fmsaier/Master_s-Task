using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_huatuo : MonoBehaviour
{
    public Transform firePoint;
    public GameObject zhongcaoyaoPrefab;
    public GameObject mafeisanPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Shootzhongcaoyao();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Shootmafeisan();
        }
    }

    public void Shootzhongcaoyao()
    {
        // �������ס�����Ķ����Լ�λ��
        Instantiate(zhongcaoyaoPrefab, firePoint.position, firePoint.rotation);
    }
    public void Shootmafeisan()
    {
        // �������ס�����Ķ����Լ�λ��
        Instantiate(mafeisanPrefab, firePoint.position, firePoint.rotation);
    }
}
