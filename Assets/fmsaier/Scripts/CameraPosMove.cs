using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：摄像机目标位置的移动
//***************************************** 
public class CameraPosMove : MonoBehaviour
{
    private Vector3 targetPos;
    private bool startPosLerp;
    private float lerpSpeed;

    void Start()
    {
        lerpSpeed = 1f;
    }

    void FixedUpdate()
    {
        //位置
        if (startPosLerp)
        {
            if (Vector3.Distance(transform.localPosition, targetPos) > 0.1f)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, lerpSpeed*10 * Time.fixedDeltaTime);
            }
            else
            {
                startPosLerp = false;
            }
        }
    }

    /// <summary>
    /// 设置插值位置
    /// </summary>
    public void SetPos(Vector3 pos)
    {
        startPosLerp = true;
        targetPos = pos;
    }
}
