using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：检测玩家是否可以开启BOSS战
//***************************************** 
public class BossArea : MonoBehaviour
{
    private Gris gris;
    private LastScript lastScript;

    public bool isFirstLevel;
    private CameraPosMove cpm;
    private CameraCtroller cc;

    private void Start()
    {
        gris = GameObject.Find("Gris").GetComponent<Gris>();
        cc = Camera.main.GetComponent<CameraCtroller>();
        cpm = GameObject.Find("CameraTargetPos").GetComponent<CameraPosMove>();
        lastScript = GameObject.Find("BlackSky").GetComponent<LastScript>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="Gris")
        {
            if (gris.tearList.Count >= 5)
            {
                lastScript.StartLerp(1);
                this.enabled = false;
            }
            if (isFirstLevel)
            {
                //恢复到摄像机的默认位置
                cpm.SetPos(new Vector3(-13.4f, 7f, 10));
                cc.SetSize(5);
            }
            else
            {
                //恢复到摄像机的默认位置
                cpm.SetPos(new Vector3(14.6f, 7f, 10));
                cc.SetSize(5);
            }
        }
       
    }
}
