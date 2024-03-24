using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merryfling
{
    public class Sea : MonoBehaviour
    {
        [Header("碰撞物体信息")]
        private const string goodFood = "GoodFood";
        private const string player = "Player";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("进");
            if(collision.tag == goodFood)
            {
                Destroy(collision.gameObject);//Destroy(collision)没有销毁掉物体是因为销毁对象因该是collison.gameobject而不是碰撞信息
                Debug.Log("销毁");
            }
            if (collision.tag == player)
            {
                //TODO:执行死亡逻辑
                Debug.Log("玩家死亡");
                Destroy(collision.gameObject);
            }
        }
    }
}