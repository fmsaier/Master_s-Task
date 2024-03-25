using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dawnize{
public class player : MonoBehaviour
{
    public float speed;
    private float xMin,xMax,yMax,yMin;
    private Camera mainCamera;
    Vector2 leftDown,rightUp;
    private bool isAndroid;
    public GameObject Handle;
    private void Start() {
        mainCamera=Camera.main;
        leftDown=mainCamera.ScreenToWorldPoint(new Vector2(0,0));
        rightUp=mainCamera.ScreenToWorldPoint(new Vector2(screenSize.ScreenWidth/2,screenSize.ScreenHeight));
        xMin=leftDown.x;
        xMax=rightUp.x;
        yMax=rightUp.y;
        yMin=leftDown.y;
        if(Application.platform==RuntimePlatform.Android){
            isAndroid=true;
        }
        else isAndroid=false;
    }
   void FixedUpdate() {
    if(isAndroid){
        move_android();
    }
    else if(!isAndroid){
        move_win();
    }
    }
    void move_win(){
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0)*speed);
    }
    void move_android(){
        float Posx=Handle.transform.localPosition.x;
        float Posy=Handle.transform.localPosition.y;
        transform.Translate(new Vector3(Posx/128f,Posy/128f,0)*speed);
    }






    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("medicine")){
            getMedicine(other.GetComponent<medicine>().thisKind);
            Destroy(other.gameObject);
        }
    }

    //不同medicine的效果
    void getMedicine(medicine.medicineKind kind){
        switch(kind){
            case medicine.medicineKind.normal:
                dataRecound.medicineAcount++;
                break;
            case medicine.medicineKind.unnormal:
                dataRecound.medicineAcount+=2;
                break;    
        }
        
    }
}
}

