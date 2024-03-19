using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dawnize{
public class enemy : MonoBehaviour
{//消灭细胞的函数
public void destroyCancerCeil(){
    enemyRecond.cancerCeils.Remove(gameObject);
    Destroy(gameObject);
   }
   private void Start() {
    //ceil生成动画
   }
}
}