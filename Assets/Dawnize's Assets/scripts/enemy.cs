using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dawnize{
public class enemy : MonoBehaviour
{
    private float timer;
    private float timer1;
    public GameObject fenlie;
    public float fenlieInterval;
    public bool isFenlie=false;
    Vector2 randomVec;
    //消灭细胞的函数
public void destroyCancerCeil(){
    if(dataRecound.medicineAcount>0){
        dataRecound.medicineAcount--;
        dataRecound.ceilAcount--;
        Destroy(transform.parent.gameObject);
    }

   }
   private void Start() {
    timer=0;
    randomVec=new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized;
   }
   private void Update() {
    timer+=Time.deltaTime;
    timer1+=Time.deltaTime;
    if(timer>=fenlieInterval){
        fenlieInterval+=3;
        GameObject temp= Instantiate(fenlie,transform.position,Quaternion.identity);
        temp.GetComponentInChildren<enemy>().isFenlie=true;
        dataRecound.ceilAcount++;
        timer=0;
    }
    if(isFenlie){
        transform.parent.Translate(randomVec*0.01f);
    }
    if(timer1>=0.5f){
        isFenlie=false;
    }
   }
}

}