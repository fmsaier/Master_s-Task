using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dawnize{
public class processCtrl : MonoBehaviour
{
public GameObject cancerCeil;
private Vector3 positionOfHome;
Vector2 randomScreenPoint;
Vector2 randomWorldPoint;
Camera mainCamera;
public int[] enemiesAcount;
public float interval;

private void Awake() {
    mainCamera=Camera.main;
    screenSize.ScreenWidth=Screen.width;
    screenSize.ScreenHeight=Screen.height;
}
IEnumerator ProcessCtrl(){
    //开场介绍
    //开始产怪
    for(int i=0;i<enemiesAcount.Length;i++){
        for(int j=0;j<enemiesAcount[i];j++){
            EnemyCreator();
            yield return new WaitForSeconds(interval);
        }
        yield return new WaitUntil(()=>dataRecound.cancerCeils.Count==0);
        //每波次结束加科普        
    }
    //结束相关
}
void EnemyCreator(){
    randomScreenPoint=new Vector2(Random.Range(screenSize.ScreenWidth/2,screenSize.ScreenWidth),Random.Range(0,screenSize.ScreenHeight));
    randomWorldPoint=mainCamera.ScreenToWorldPoint(randomScreenPoint);
    GameObject temp=Instantiate(cancerCeil,randomWorldPoint,Quaternion.identity);
    dataRecound.cancerCeils.Add(temp);
}
}
}

