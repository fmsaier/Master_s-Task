using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dawnize{
public class processCtrl : MonoBehaviour
{
public GameObject cancerCeil;
public static bool isTutorialOver=false;
Vector2 randomScreenPoint;
Vector2 randomWorldPoint;
Camera mainCamera;
public int[] enemiesAcount;
public float interval;

private void Awake() {
    Time.timeScale=0;
    mainCamera=Camera.main;
    screenSize.ScreenWidth=Screen.width;
    screenSize.ScreenHeight=Screen.height;
}
private void Start() {
    StartCoroutine(ceilCtrl());
}
IEnumerator ceilCtrl(){
    //开场介绍
    yield return new WaitUntil(()=>Time.timeScale>=0.9f);
    //开始产怪
    for(int i=0;i<enemiesAcount.Length;i++){
        for(int j=0;j<enemiesAcount[i];j++){
            EnemyCreator();
            yield return new WaitForSeconds(interval);
        }      
        yield return new WaitUntil(()=>dataRecound.ceilAcount==0);
        //每波次结束加科普        
    }
    Debug.Log("成功");
    //结束相关
}
private void Update() {
    if(dataRecound.ceilAcount>=20){
        //失败
        Debug.Log("失败");
    }
}
void EnemyCreator(){
    randomScreenPoint=new Vector2(Random.Range(screenSize.ScreenWidth/2,screenSize.ScreenWidth),Random.Range(0,screenSize.ScreenHeight));
    randomWorldPoint=mainCamera.ScreenToWorldPoint(randomScreenPoint);
    Instantiate(cancerCeil,randomWorldPoint,Quaternion.identity);
    dataRecound.ceilAcount++;
}
}
}

