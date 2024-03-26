using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：摄像机控制
//***************************************** 
public class CameraCtroller : MonoBehaviour
{
    private Vector3 targetPos;
    public bool startPosLerp;

    private float targetSize;
    private bool startSizeLerp;
    private Color targetColor;
    private bool startColorLerp;

    private float lerpSpeed;

    private Transform targetTrans;

    void Start()
    {
        lerpSpeed = 1;
        targetTrans = GameObject.Find("CameraTargetPos").transform;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            lerpSpeed = 0.5f;
        }
        else
        {
            lerpSpeed = 1;
        }
    }

    void FixedUpdate()
    {
        //位置
        if (startPosLerp)
        {
            if (Vector3.Distance(transform.position, targetTrans.position) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, targetTrans.position, lerpSpeed*20 * Time.fixedDeltaTime);
            }
        }

      
        //颜色
        if (startColorLerp)
        {
            if (!Color.Equals(Camera.main.backgroundColor ,targetColor))
            {
                Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, targetColor, lerpSpeed * Time.fixedDeltaTime);
            }
            else
            {
                startColorLerp = false;
            }
        }

        //视野
        if (startSizeLerp)
        {
            if (Mathf.Abs(Camera.main.orthographicSize - targetSize) > 0.01f)
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, lerpSpeed * Time.fixedDeltaTime);
            }
            else
            {
                startSizeLerp = false;
            }
        }
    }

    /// <summary>
    /// 设置摄像机的大小尺寸
    /// </summary>
    /// <param name="size"></param>
    public void SetSize(float size)
    {
        startSizeLerp = true;
        targetSize = size;
    }
    /// <summary>
    /// 设置背景颜色
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(Color color)
    {
        startColorLerp = true;
        targetColor = color;
    }
}
