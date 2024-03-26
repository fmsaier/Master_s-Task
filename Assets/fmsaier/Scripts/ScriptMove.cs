using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：前序剧情人物控制
//***************************************** 
public class ScriptMove : MonoBehaviour
{
    private Transform sp1Trans;
    private float movePercent=1.6f;
    private Animator animator;

    void Start()
    {
        sp1Trans= GameObject.Find("Script1").transform;
        animator=GetComponent<Animator>();
        animator.Play("WalkScript");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, sp1Trans.position, movePercent*Time.deltaTime);
        if (Vector2.Distance(transform.position,sp1Trans.position)<=0.01f)
        {
            this.enabled=false;
        }
    } 
}
