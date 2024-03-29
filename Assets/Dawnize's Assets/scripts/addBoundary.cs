using System.Collections;
using System.Collections.Generic;
using Dawnize;
using Unity.Mathematics;
using UnityEngine;
namespace Dawnize{
public class addBoundary : MonoBehaviour
{
    public GameObject leftBoundary;
    public GameObject upDownBoundary;
    private Vector3 upPosition,downPosition,leftPosition,rightPosition;
    private Camera mainCamera;
    public GameObject HandleCanvas;
    void Start()
    {
        mainCamera=Camera.main;
        upPosition=mainCamera.ScreenToWorldPoint(new Vector2(screenSize.ScreenWidth/2,screenSize.ScreenHeight));
        downPosition=mainCamera.ScreenToWorldPoint(new Vector2(screenSize.ScreenWidth/2,0));
        leftPosition=mainCamera.ScreenToWorldPoint(new Vector2(0,screenSize.ScreenHeight/2));
        rightPosition=mainCamera.ScreenToWorldPoint(new Vector2(screenSize.ScreenWidth,screenSize.ScreenHeight/2));
        Instantiate(leftBoundary,leftPosition,quaternion.identity);
        Instantiate(upDownBoundary,upPosition,quaternion.identity);
        Instantiate(upDownBoundary,downPosition,quaternion.identity);
        Instantiate(leftBoundary,rightPosition,quaternion.identity);
        if(Application.platform==RuntimePlatform.Android){
            HandleCanvas.SetActive(true);
        }
    }
}
}

