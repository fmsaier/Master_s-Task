using SqR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarShow : MonoBehaviour
{
    public GameObject press;
    public LongPress longPress;
    void Start()
    {
        longPress = press.GetComponent<LongPress>();
    }

    void Update()
    {
        float x,show;
        x = longPress.pressTime / longPress.maxTime;
        if (x <= 1)
            show = x;
        else
            show = 1;
        gameObject.transform.localScale = new Vector3(show, 1, 1);
    }
}
