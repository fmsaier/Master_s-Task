using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：眼泪跟随Gris移动的功能
//***************************************** 
public class TearPet : MonoBehaviour
{
    private Transform targetTrans;
    private float speed;
    private float shakeDistance;
    private float timer;
    private float timeVal;
    private bool startShake;

    void Start()
    {
        Transform grisTrans = GameObject.Find("Gris").transform;

        for (int i = 0; i < grisTrans.childCount; i++)
        {
            //找到没有被占据的位置
            if (grisTrans.GetChild(i).childCount<=0)
            {
                targetTrans = grisTrans.GetChild(i);
                GameObject go = new GameObject();
                go.transform.SetParent(targetTrans);
                break;
            }
        }
        speed = 3;
        shakeDistance = 0.02f;
        timeVal = 0.1f;
        grisTrans.GetComponent<Gris>().tearList.Add(this);
    }

    void FixedUpdate()
    {
        if (startShake)
        {
            PetShake();
        }
        else
        {
            PetMove();
        }       
    }

    private void PetMove()
    {
        if (Vector2.Distance(transform.position, targetTrans.position) > 0.01f)
        {
            transform.position = Vector2.Lerp(transform.position, targetTrans.position, Time.fixedDeltaTime * speed);
        }
        else
        {
            startShake = true;
        }
    } 

    private void PetShake()
    {
        if (Vector2.Distance(transform.position,targetTrans.position)>0.03f)
        {
            startShake = false;
        }
        else
        {
            if (timer >= timeVal)
            {
                timer = 0;
                transform.position = targetTrans.position + Mathf.PingPong(Time.time, shakeDistance) * Vector3.one;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

       
    }
}
