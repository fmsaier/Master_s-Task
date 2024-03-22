using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
namespace Dawnize{
public class enemy : MonoBehaviour
{
    private float timer;
    public GameObject fenlie;
    public float fenlieInterval;
    //消灭细胞的函数
public void destroyCancerCeil(){
    if(dataRecound.medicineAcount>0){
        dataRecound.medicineAcount--;
        dataRecound.ceilAcount--;
        Destroy(gameObject);
    }

   }
   private void Start() {
    timer=0;
   }
   private void Update() {
    timer+=Time.deltaTime;
    if(timer>=fenlieInterval){
        Instantiate(fenlie,transform.position,quaternion.identity);
        dataRecound.ceilAcount++;
        timer=0;
    }
   }
}

}