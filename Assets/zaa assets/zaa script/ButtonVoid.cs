using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonvoid : MonoBehaviour
{
    private int PicNum;
    public int picNum
    {
        get
        {
            return PicNum;
        }
        set
        {
            if (value <= 0)
            {
                value = 0;
            }
            if (value >= 2)
            {
                value = 2;
            }
            PicNum = value;
        }
    }

    private void Start()
    {
        picNum = 0;
    }
    public void Left()
    {
        picNum -= 1;
        CanvasVoid.instance.transform.GetChild(picNum).gameObject.SetActive(true);
        CanvasVoid.instance.transform.GetChild(picNum+1).gameObject.SetActive(false);
    }

    public void Right()
    {
        picNum += 1;
        CanvasVoid.instance.transform.GetChild(picNum).gameObject.SetActive(true);
        CanvasVoid.instance.transform.GetChild(picNum - 1).gameObject.SetActive(false);
    }
}
