using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Dawnize{
    public class uiCtrl : MonoBehaviour
{
public GameObject another;
public GameObject canvas; 
public GameObject MedAccoundUI;
public void setSelfUnvisual(){
    gameObject.SetActive(false);
}
public void setAnotherActive(){
    another.SetActive(true);
} 
public void timeScaleBack(){
    Time.timeScale=1;
    processCtrl.isHang=false;
    MedAccoundUI.SetActive(true);
}
public void isTutorialOver()
{
    processCtrl.isTutorialOver=true;
}
public void setCanvasUnvisual(){
    canvas.SetActive(false);
} 
public void again(){
    SceneManager.LoadScene("luzhou");
}
public void backToMenu(){
SceneManager.LoadScene(1);
}
}
}


