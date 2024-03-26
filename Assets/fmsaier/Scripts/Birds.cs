using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：
//***************************************** 
public class Birds : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(-transform.right*4*Time.deltaTime);
    } 
}
