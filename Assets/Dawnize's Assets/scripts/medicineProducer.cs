using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medicineProducer : MonoBehaviour
{
float screenWidth;
float screenHeight;
Vector3 randomScreenPoint;
Vector3 randomWorldPoint;
Camera mainCamera;
public GameObject[] medicine;
public int produceInterval;
float timeRecound;
private void Start() {
    screenWidth=Screen.width;
    screenHeight=Screen.height;
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
    randomScreenPoint=new Vector3(Random.Range(0,screenWidth/2),Random.Range(0,screenHeight),0);
    randomWorldPoint=mainCamera.ScreenToWorldPoint(randomScreenPoint);
    GameObject temp=Instantiate(medicine[a],randomWorldPoint,Quaternion.identity);
}
}
