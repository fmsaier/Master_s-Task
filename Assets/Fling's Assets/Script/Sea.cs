using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merryfling
{
    public class Sea : MonoBehaviour
    {
        [Header("��ײ������Ϣ")]
        private const string goodFood = "GoodFood";
        private const string player = "Player";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("��");
            if(collision.tag == goodFood)
            {
                Destroy(collision.gameObject);//Destroy(collision)û�����ٵ���������Ϊ���ٶ��������collison.gameobject��������ײ��Ϣ
                Debug.Log("����");
            }
            if (collision.tag == player)
            {
                //TODO:ִ�������߼�
                Debug.Log("�������");
                Destroy(collision.gameObject);
            }
        }
    }
}