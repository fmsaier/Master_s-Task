using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：特效小花
//***************************************** 
public class Red : MonoBehaviour
{
    private SpriteRenderer[] srs;
    private float scaleSpeed;
    private SpriteRenderer sr;

    void Start()
    {
        srs = GetComponentsInChildren<SpriteRenderer>();
        scaleSpeed = 0.2f;
        sr = GameObject.Find("GradientBG").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.localScale += scaleSpeed*2 * Time.deltaTime * Vector3.one;        
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].color -= new Color(0,0,0,scaleSpeed*1.3f)*Time.deltaTime;
        }
        sr.color -= new Color(0, 0, 0, scaleSpeed*2) * Time.deltaTime;
        if (srs[0].color.a<=0)
        {
            Destroy(gameObject);
        }
    } 
}
