using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Dawnize
{
public class PauseUI : MonoBehaviour
{public GameObject pauseUI;
public GameObject pauseButton,ContinueButton;
public void setPauseUIUnvisual(){
    if(processCtrl.isTutorialOver){
    pauseUI.SetActive(false);
    pauseButtonVisual();
    processCtrl.isHang=false;
    Time.timeScale=1;
    }

}
public void backToMenu(){
SceneManager.LoadScene(1);
}
public void setCanvasVisual(){
    if(processCtrl.isTutorialOver){
    pauseUI.SetActive(true);
    processCtrl.isHang=true;
    Time.timeScale=0;
    }

}
public void pauseButtonVisual(){
    pauseButton.SetActive(true);
    ContinueButton.SetActive(false);
}public void pauseButtonUnvisual(){
    pauseButton.SetActive(false);
    ContinueButton.SetActive(true);
}
}
}

