using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLinePYP : MonoBehaviour
{
    public int ElementNumber;
    private PlayableDirector timeline;

    void Start()
    {
        timeline = GetComponent<PlayableDirector>(); // 获取物体上的 PlayableDirector 组件
    }


    void Update()
    {
        if (WholePYP.PYPElement >= ElementNumber)
        {
            if (timeline != null)
            {
                timeline.Play(); // 播放 Timeline
            }
        }
    }
}
