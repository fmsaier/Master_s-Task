using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：改变摄像机的检测区域，颜色或者位置
//***************************************** 
public class CameraChangeArea : MonoBehaviour
{
    public Vector3 pos;
    public float size;
    public Color color;
   
    public bool isFirstLevel;
    private CameraPosMove cpm;
    private CameraCtroller cc;

    private void Start()
    {
        cc = Camera.main.GetComponent<CameraCtroller>();
        cpm = GameObject.Find("CameraTargetPos").GetComponent<CameraPosMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="Gris")
        {
            if (pos!=Vector3.zero)
            {
                cpm.SetPos(pos);
            }
            if (size!=0)
            {
                cc.SetSize(size);
            }
            if (color!=Color.clear)
            {
                cc.SetColor(color);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Gris")
        {
            if (isFirstLevel)
            {
                //恢复到摄像机的默认位置
                cpm.SetPos(new Vector3(-13.4f, 7f, 10));
                cc.SetSize(5);
            }
            else
            {
                //恢复到摄像机的默认位置
                cpm.SetPos(new Vector3(14.6f,7f,10));
                cc.SetSize(5);
            }
        }
    }
}
