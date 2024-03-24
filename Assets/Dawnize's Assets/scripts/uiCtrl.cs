using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dawnize{
    public class uiCtrl : MonoBehaviour
{
public GameObject another; 
public GameObject MedAccoundUI;
public void setSelfUnvisual(){
    gameObject.SetActive(false);
}
public void setAnotherActive(){
    another.SetActive(true);
} 
public void timeScaleBack(){
    Time.timeScale=1;
    MedAccoundUI.SetActive(true);
}
public void isTutorialOver()
{
    processCtrl.isTutorialOver=true;
} 
}
}


