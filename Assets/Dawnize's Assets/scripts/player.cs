using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    void Update()
    {
        move();
    }
    void move(){
        //移动函数
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("medicine")){
            getMedicine(other.GetComponent<medicine>().thisKind);
            Destroy(other.gameObject);
        }
    }

    //不同medicine的效果
    void getMedicine(medicine.medicineKind kind){
        // switch(kind){
        //     case medicine.medicineKind.:
        // }
        
    }
}
