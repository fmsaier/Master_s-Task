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
        timeline = GetComponent<PlayableDirector>(); // ��ȡ�����ϵ� PlayableDirector ���
    }


    void Update()
    {
        if (WholePYP.PYPElement >= ElementNumber)
        {
            if (timeline != null)
            {
                timeline.Play(); // ���� Timeline
            }
        }
    }
}
