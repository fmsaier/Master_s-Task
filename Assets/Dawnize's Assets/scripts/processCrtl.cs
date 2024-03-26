using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Dawnize{
public class processCtrl : MonoBehaviour
{
public GameObject cancerCeil,pauseUI;
public static bool isTutorialOver;
Vector2 randomScreenPoint;
Vector2 randomWorldPoint;
Camera mainCamera;
public int[] enemiesAcount;
private Coroutine cc;
public float interval;
public GameObject PauseUIImage;
public static bool isHang;

private void Awake() {
    Time.timeScale=0;
    mainCamera=Camera.main;
    screenSize.ScreenWidth=Screen.width;
    screenSize.ScreenHeight=Screen.height;
    isTutorialOver=false;
    isHang=false;
}
private void Start() {
   cc= StartCoroutine(ceilCtrl());
}
IEnumerator ceilCtrl(){
    //开场介绍
    yield return new WaitUntil(()=>Time.timeScale>=0.9f);
    //开始产怪
    for(int i=0;i<enemiesAcount.Length;i++){
        for(int j=0;j<enemiesAcount[i];j++){
            EnemyCreator();
            yield return new WaitForSeconds(interval);
            yield return new WaitUntil(()=>isHang==false);
        }      
        yield return new WaitUntil(()=>dataRecound.ceilAcount==0);
        //每波次结束加科普        
    }
    SceneManager.LoadScene("victory");
    yield break;
    //结束相关
}
private void Update() {
    if(dataRecound.ceilAcount>=20){
        //失败
        StopCoroutine(cc);
        dataRecound.ceilAcount=0;
        SceneManager.LoadScene("lose");
    }
    if(Input.GetKeyDown(KeyCode.Escape)&&PauseUIImage.activeSelf==false&&isTutorialOver){
        PauseUIImage.SetActive(true);
        pauseUI.GetComponent<PauseUI>().pauseButtonUnvisual();
        isHang=true;
        Time.timeScale=0;
    }
    else if(Input.GetKeyDown(KeyCode.Escape)&&PauseUIImage.activeSelf==true&&isTutorialOver){
        PauseUIImage.SetActive(false);
        pauseUI.GetComponent<PauseUI>().pauseButtonVisual();
        isHang=false;
        Time.timeScale=1;
    }
    Debug.Log(Time.timeScale);
    Debug.Log(isHang);
}
void EnemyCreator(){
    randomScreenPoint=new Vector2(Random.Range(screenSize.ScreenWidth/2,screenSize.ScreenWidth),Random.Range(0,screenSize.ScreenHeight));
    randomWorldPoint=mainCamera.ScreenToWorldPoint(randomScreenPoint);
    Instantiate(cancerCeil,randomWorldPoint,Quaternion.identity);
    dataRecound.ceilAcount++;
}
}
}

