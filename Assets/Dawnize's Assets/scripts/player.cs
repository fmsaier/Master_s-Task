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
    private void Start() {
        mainCamera=Camera.main;
        leftDown=mainCamera.ScreenToWorldPoint(new Vector2(0,0));
        rightUp=mainCamera.ScreenToWorldPoint(new Vector2(screenSize.ScreenWidth/2,screenSize.ScreenHeight));
        xMin=leftDown.x;
        xMax=rightUp.x;
        yMax=rightUp.y;
        yMin=leftDown.y;
    }
   void FixedUpdate() {
        move();
        Debug.Log(dataRecound.medicineAcount);
    }
    void move(){
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0)*speed);
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

