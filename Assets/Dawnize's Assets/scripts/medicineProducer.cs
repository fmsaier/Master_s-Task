using System.Collections;
using System.Collections.Generic;
using Dawnize;
using UnityEngine;
namespace Dawnize{
public class medicineProducer : MonoBehaviour
{
Vector2 randomScreenPoint;
Vector2 randomWorldPoint;
Camera mainCamera;
public GameObject[] medicine;
public int produceInterval;
float timeRecound;
private void Start() {
    mainCamera=Camera.main;
}
private void Update() {
    timeRecound+=Time.deltaTime;
    if(timeRecound>=produceInterval){
        produceMedicine();
        timeRecound=0;
    }
}
void produceMedicine(){
    int a=Random.Range(0,medicine.Length-1);
    randomScreenPoint=new Vector2(Random.Range(0,screenSize.ScreenWidth/2),Random.Range(0,screenSize.ScreenHeight));
    randomWorldPoint=mainCamera.ScreenToWorldPoint(randomScreenPoint);
    GameObject temp=Instantiate(medicine[a],randomWorldPoint,Quaternion.identity);
}
}
}

