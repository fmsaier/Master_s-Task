using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dawnize{
public class processCtrl : MonoBehaviour
{
public GameObject home;
public GameObject cancerCeil;
private Vector3 positionOfHome;
float screenWidth;
float screenHeight;
Vector3 randomScreenPoint;
Vector3 randomWorldPoint;
Camera mainCamera;
public int[] enemiesAcount;
public float interval;

private void Start() {
    positionOfHome=home.transform.position;
    screenWidth=Screen.width;
    screenHeight=Screen.height;
    mainCamera=Camera.main;
}
IEnumerator ProcessCtrl(){
    //开场介绍
    //开始产怪
    for(int i=0;i<enemiesAcount.Length;i++){
        for(int j=0;j<enemiesAcount[i];j++){
            EnemyCreator();
            yield return new WaitForSeconds(interval);
        }
        yield return new WaitUntil(()=>enemyRecond.cancerCeils.Count==0);
        //每波次结束加科普        
    }
    //结束相关
}
void EnemyCreator(){
    randomScreenPoint=new Vector3(Random.Range(0,screenWidth),Random.Range(0,screenHeight),0);
    randomWorldPoint=mainCamera.ScreenToWorldPoint(randomScreenPoint);
    GameObject temp=Instantiate(cancerCeil,randomWorldPoint,Quaternion.identity);
    enemyRecond.cancerCeils.Add(temp);
}
}



}

